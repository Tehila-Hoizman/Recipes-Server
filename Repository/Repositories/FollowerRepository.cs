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
    public class FollowerRepository : IRepository<Follower>
    {
        private readonly IContext _context;
        public FollowerRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Follower> AddItemAsync(Follower item)
        {
            Follower follower  = item;
            await _context.Followers.AddAsync(item);
            await this._context.save();
            return follower;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Followers.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<Follower>> GetAllAsync()
        {
            return await _context.Followers.Include(f=>f.recipe).ToListAsync();
        }

        public async Task<Follower> GetAsyncById(int id)
        {
            return await _context.Followers.Include(f => f.recipe).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Follower> UpdateAsync(int id, Follower item)
        {
            var follower = await GetAsyncById(id);
            if (follower.RecipeId != null) follower.RecipeId = item.RecipeId;
            if (follower.UserId != 0) follower.UserId = item.UserId; ;

            await _context.save();
            return follower;
        }


    }
}
