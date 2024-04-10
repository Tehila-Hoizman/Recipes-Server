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
    public class IngredientRepository :IRepository<Ingredient>
    {
        private readonly IContext _context;
        public IngredientRepository(IContext context)
        {
            _context = context;
        }
        //public async Task AddItemAsync(Ingredient item)
        //{
        //    await _context.Ingredients.AddAsync(item);
        //    await _context.save();
        //}
        public async Task<Ingredient> AddItemAsync(Ingredient item)
        {
            Ingredient ingredient = item;
            await _context.Ingredients.AddAsync(item);
            await this._context.save();
            return ingredient;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Ingredients.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetAsyncById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ingredient> UpdateAsync(int id, Ingredient item)
        {
            var ingredient = await GetAsyncById(id);
            if (ingredient.Name != null) ingredient.Name = item.Name;
            if (ingredient.Amount != null) ingredient.Amount = item.Amount;

            await _context.save();
            return ingredient;
        }
    }
}
