using AutoMapper;
using Common.Entity;
using Repository.Entity;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RecipeService : IService<RecipeDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Recipe> repository;
        private readonly IRepository<User> repositoryU;
        private readonly IRepository<Category> repositoryc;

        public RecipeService(IRepository<Recipe> repository, IMapper mapper, IRepository<User> repositoryU, IRepository<Category> repositoryc)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryU = repositoryU;
            this.repositoryc = repositoryc;
        }
        public async Task<RecipeDto> AddItemAsync(RecipeDto item)
        {
            Recipe r = mapper.Map<Recipe>(item);
            r.Categories = new HashSet<Category>();
            if(item.CategoriesId != null) { 
            foreach (var c in item.CategoriesId)
            {
                var category = await repositoryc.GetAsyncById(c);
                if (category != null)
                {
                    r.Categories.Add(category);
                }
            }
            }

            return mapper.Map<RecipeDto>(await repository.AddItemAsync(r));

            //await repository.AddItemAsync(mapper.Map<Recipe>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<RecipeDto> GetAsyncById(int id)
        {
           
            return mapper.Map<RecipeDto>(await repository.GetAsyncById(id));
        }
        public async Task<List<RecipeDto>> GetAllAsync()
        {
            List<RecipeDto> r = mapper.Map<List<RecipeDto>>(await repository.GetAllAsync());
            foreach (var item in r)
            {
                UserDto user =mapper.Map<UserDto>(await repositoryU.GetAsyncById(item.EditorId));

                item.EditorName = user.FirstName+" "+user.LastName;
                item.UrlImageEditor = user.UrlImage;
            }
            return r;
        }
        //public async Task<List<RecipeDto>> GetAllAsync()
        //{
        //    return mapper.Map<List<RecipeDto>>(await repository.GetAllAsync());
        //}

        public async Task<RecipeDto> UpdateAsync(int id, RecipeDto item)
        {
            Recipe r = mapper.Map<Recipe>(item);
            r.Categories = new HashSet<Category>();
            if (item.CategoriesId != null)
            {
                foreach (var c in item.CategoriesId)
                {
                    var category = await repositoryc.GetAsyncById(c);
                    if (category != null)
                    {
                        r.Categories.Add(category);
                    }
                }
            }
            //r.UsersLiked = new HashSet<User>();
            //if (item.UsersId != null)
            //{
            //    foreach (var u in item.UsersId)
            //    {
            //        var user = await repositoryU.GetAsyncById(u);
            //        if (user != null)
            //        {
            //            r.UsersLiked.Add(user);
            //        }
            //    }
            //}
            return mapper.Map<RecipeDto>(await repository.UpdateAsync(id,r));

            //return mapper.Map<RecipeDto>(await repository.UpdateAsync(id, mapper.Map<Recipe>(item)));

        }
    }
}
