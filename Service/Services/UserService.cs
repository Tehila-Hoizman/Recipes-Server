using AutoMapper;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;
        private readonly IRepository<Recipe> recipeRepository;
        public UserService(IRepository<User> repository, IMapper mapper, IRepository<Recipe> recipeRepository )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.recipeRepository = recipeRepository;
        }
        public async Task<UserDto> AddItemAsync(UserDto item)
        {

            return mapper.Map<UserDto>(await repository.AddItemAsync(mapper.Map<User>(item)));

            //await repository.AddItemAsync(mapper.Map<User>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<UserDto> GetAsyncById(int id)
        {
            return mapper.Map<UserDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return mapper.Map<List<UserDto>>(await repository.GetAllAsync());
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto item)
        {
            return mapper.Map<UserDto>(await repository.UpdateAsync(id, mapper.Map<User>(item)));

           
        }
        public async Task<UserDto> GetUserByEmailAndPassword(string email, string password)
        {

            List<User> users = await repository.GetAllAsync();
            
                User user =  users.FirstOrDefault(x => x.Email == email&&x.Password==password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
                return mapper.Map<UserDto>(user);

        }

  


        //public async Task AddFavorite(int r,int u)
        //{
        //    var recipe = await recipeRepository.GetAsyncById(r);
        //    var user = await repository.GetAsyncById(u);
        //    if (recipe.UsersLiked == null)
        //        recipe.UsersLiked = new HashSet<User>();
        //    recipe.UsersLiked.Add(user);
        //    await recipeRepository.UpdateAsync(r,recipe);
        //    //if(user.FavoriteRecipes==null)
        //    //user.FavoriteRecipes= new HashSet<Recipe>();
        //    //user.FavoriteRecipes.Add(recipe);
        //    //await repository.UpdateAsync(user.Id, user);
           
        //}
        //public async Task RemoveFavorite(int r, int u)
        //{
        //    var recipe = await recipeRepository.GetAsyncById(r);
        //    var user = await repository.GetAsyncById(u);

        //    var x = new HashSet<User>();
        //    if (recipe.UsersLiked != null)
        //    {
        //        foreach (var item in recipe.UsersLiked)
        //        {
        //            if (item.Id != user.Id)
        //                x.Add(item);
        //        }
        //    }
        //    recipe.UsersLiked = x;
        //    await recipeRepository.UpdateAsync(r, recipe);

        //}
        public async Task<bool> IsEmailExist(string email)
        {
            if(repository.GetAllAsync().Result.Find(x=>x.Email==email) != null)
                return true;
            return false;
        }


    }
}

