using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MeasureRepository :IRepository<Measure>
    {
        private readonly IContext _context;
        public MeasureRepository(IContext context)
        {
            _context = context;
        }
        //public async Task AddItemAsync(Measure item)
        //{
        //    await _context.Measures.AddAsync(item);
        //    await _context.save();
        //}
        public async Task<Measure> AddItemAsync(Measure item)
        {
            Measure measure = item;
            await _context.Measures.AddAsync(item);
            await this._context.save();
            return measure;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Measures.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<Measure>> GetAllAsync()
        {
            return await _context.Measures.ToListAsync();
        }

        public async Task<Measure> GetAsyncById(int id)
        {
            return await _context.Measures.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Measure> UpdateAsync(int id, Measure item)
        {
            var measure = await GetAsyncById(id);
            if (measure.Name != null) measure.Name = item.Name;

            await _context.save();
            return measure;
        }
    }
}
