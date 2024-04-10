using AutoMapper;
using Common.Entity;
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
    public class IngredientService : IService<IngredientDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Ingredient> repository;
        public IngredientService(IRepository<Ingredient> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IngredientDto> AddItemAsync(IngredientDto item)
        {
            return mapper.Map<IngredientDto>(await repository.AddItemAsync(mapper.Map<Ingredient>(item)));

            //await repository.AddItemAsync(mapper.Map<Ingredient>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IngredientDto> GetAsyncById(int id)
        {
            return mapper.Map<IngredientDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<IngredientDto>> GetAllAsync()

        {
            return mapper.Map<List<IngredientDto>>(await repository.GetAllAsync());
        }

        public async Task<IngredientDto> UpdateAsync(int id, IngredientDto item)
        {
            return mapper.Map<IngredientDto>(await repository.UpdateAsync(id, mapper.Map<Ingredient>(item)));

        }

    }
}
