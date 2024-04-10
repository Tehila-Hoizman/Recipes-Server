using AutoMapper;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FollowerService :IFollowerService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Follower> repository;
        public readonly IRepository<User> repositoryU;
        public readonly IRepository<Recipe> repositoryR;
        public FollowerService(IRepository<Follower> repository, IMapper mapper, IRepository<User> repositoryU,IRepository<Recipe> repositoryR)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryU = repositoryU;
            this.repositoryR = repositoryR;

        }

        public async Task<FollowerDto> AddItemAsync(FollowerDto item)
        {
            Follower f = mapper.Map<Follower>(repository.GetAsyncById(item.Id).Result);
            Recipe r = mapper.Map<Recipe>(repositoryR.GetAsyncById(item.RecipeId).Result);
            User u = repositoryU.GetAsyncById(item.UserId).Result;
            //if(u.Followers==null)
            //u.Followers = new HashSet<Follower>();
            //u.Followers.Add(mapper.Map<Follower>(item));
            //await repositoryU.UpdateAsync(item.UserId, u);

            return mapper.Map<FollowerDto>(await repository.AddItemAsync(mapper.Map<Follower>(item)));

            //await repository.AddItemAsync(mapper.Map<Ingredient>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<FollowerDto> GetAsyncById(int id)
        {
            return mapper.Map<FollowerDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<FollowerDto>> GetAllAsync()
        {
            return mapper.Map<List<FollowerDto>>(await repository.GetAllAsync());
        }


        public async Task<FollowerDto> UpdateAsync(int id, FollowerDto item)
        {
            return mapper.Map<FollowerDto>(await repository.UpdateAsync(id, mapper.Map<Follower>(item)));

        }
        public async Task DeleteByRecipeUser(int userId, int recipeId)
        {
        Follower f =repository.GetAllAsync().Result.Where(x => x.UserId == userId && x.RecipeId == recipeId).FirstOrDefault();
            User u = repositoryU.GetAsyncById(userId).Result;
            if (u.Followers != null)
            u.Followers.Remove(mapper.Map<Follower>(f));
            await repositoryU.UpdateAsync(userId, u);
            await repository.DeleteAsync(f.Id);
        }

    }
}
