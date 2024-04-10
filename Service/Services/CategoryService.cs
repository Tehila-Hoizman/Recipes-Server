using AutoMapper;
using Common.Entity; 
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Entity;

namespace Service.Services
{
    public class CategoryService :IService <CategoryDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Category> repository;
        private readonly IRepository<User> repositoryUser;

        public CategoryService(IRepository<Category> repository, IMapper mapper, IRepository<User> repositoryUser)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryUser = repositoryUser;
        }
        public async Task<CategoryDto> AddItemAsync(CategoryDto item)
        {
            return mapper.Map<CategoryDto>(await repository.AddItemAsync(mapper.Map<Category>(item)));

            //await repository.AddItemAsync(mapper.Map<Category>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<CategoryDto> GetAsyncById(int id)
        {
            return mapper.Map<CategoryDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = mapper.Map<List<CategoryDto>>(await repository.GetAllAsync());
            foreach (var category in categories)
            {
                foreach (var recipe in category.Recipes)
                {
                    UserDto user = mapper.Map<UserDto>(await repositoryUser.GetAsyncById(recipe.EditorId));

                    recipe.EditorName = user.FirstName + " " + user.LastName;
                    recipe.UrlImageEditor = user.UrlImage;
                }
            }
            return categories;
            
        }

        public async Task<CategoryDto> UpdateAsync(int id, CategoryDto item)
        {
            return mapper.Map<CategoryDto>(await repository.UpdateAsync(id, mapper.Map<Category>(item)));

        }
    }
}
