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
    public class UserRepository : IRepository<User>
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }
        //public async Task AddItemAsync(User item)
        //{
        //    await _context.Users.AddAsync(item);
        //    await _context.save();
        //}
        public async Task<User> AddItemAsync(User item)
        {
            User user = item;
            await _context.Users.AddAsync(item);
            await this._context.save();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Users.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<User>> GetAllAsync()
        {
            //return await _context.Users.Include(u => u.FavoriteRecipes).ToListAsync();

            return await _context.Users.Include(u=>u.Followers).ToListAsync();
        }

        public async Task<User> GetAsyncById(int id)
        {
            //return await _context.Users.Include(u => u.FavoriteRecipes).FirstOrDefaultAsync(x => x.Id == id);

            return await _context.Users.Include(u=>u.Followers).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateAsync(int id, User item)
        {
            User user = await GetAsyncById(id);
            if (item.FirstName != null) user.FirstName = item.FirstName;
            if (item.LastName != null) user.LastName = item.LastName;
            if (item.Email != null) user.Email = item.Email;
            if (item.Password != null) user.Password = item.Password;
            if (item.Level != 0) user.Level = item.Level;
            if (item.WantNewsletter != 0) user.WantNewsletter = item.WantNewsletter;
            if (item.UrlImage != null&& item.UrlImage != "null") user.UrlImage = item.UrlImage;
            //if (item.FavoriteRecipes != null)
            //{
            //    foreach (var recipe in item.FavoriteRecipes)
            //    {
            //        user.FavoriteRecipes.Add(recipe);
            //    }
            //}
            await _context.save();

            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            // Implement the logic to retrieve the user by email and password
            // using the YourDataContext or any other necessary operations

            // Example implementation:

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            // Map User entity to UserDto using a mapping library like AutoMapper

            // Return the UserDto object
        }

    }
}
