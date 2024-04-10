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
    public class RecipeRepository :IRepository<Recipe>
    {
        private readonly IContext _context;
        public RecipeRepository(IContext context)
        {
            _context = context;
        }
        //public async Task AddItemAsync(Recipe item)
        //{
        //    await _context.Recipes.AddAsync(item);
        //    await _context.save();
        //}
        public async Task<Recipe> AddItemAsync(Recipe item)
        {
            Recipe recipe = item;
            await _context.Recipes.AddAsync(item);
            await this._context.save();
            return recipe;
        }


        public async Task DeleteAsync(int id)
        {
            _context.Recipes.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {

            return await this._context.Recipes.ToListAsync();

            //return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetAsyncById(int id)
        {
            //return await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            //return await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Recipe> UpdateAsync(int id, Recipe item)
        {
            var recipe = await GetAsyncById(id);
            if (item.Name != null) recipe.Name = item.Name;
            if (item.Description != null) recipe.Description = item.Description;
            if (item.Instructions != null) recipe.Instructions = item.Instructions;
            if (item.DurationOfPreparation != 0) recipe.DurationOfPreparation = item.DurationOfPreparation;
            if (item.LevelOfDifficulty != 0) recipe.LevelOfDifficulty = item.LevelOfDifficulty;
            if (item.NumOfPieces != 0) recipe.NumOfPieces = item.NumOfPieces;
            if (item.UploadTime != DateTime.MinValue) recipe.UploadTime = item.UploadTime;
            if (item.UrlImage != null && item.UrlImage != "null") recipe.UrlImage = item.UrlImage;
            //recipe.UsersLiked = item.UsersLiked;
            recipe.Categories= item.Categories;

            await _context.save();
            return recipe;
        }
    }
}
