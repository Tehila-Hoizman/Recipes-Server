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
    public class MeasureService : IService<MeasureDto>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Measure> repository;
        public MeasureService(IRepository<Measure> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<MeasureDto> AddItemAsync(MeasureDto item)
        {
            return mapper.Map<MeasureDto>(await repository.AddItemAsync(mapper.Map<Measure>(item)));

            //await repository.AddItemAsync(mapper.Map<Measure>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<MeasureDto> GetAsyncById(int id)
        {
            return mapper.Map<MeasureDto>(await repository.GetAsyncById(id));
        }

        public async Task<List<MeasureDto>> GetAllAsync()
        {
            return mapper.Map<List<MeasureDto>>(await repository.GetAllAsync());
        }

        public async Task<MeasureDto> UpdateAsync(int id, MeasureDto item)
        {
            return mapper.Map<MeasureDto>(await repository.UpdateAsync(id, mapper.Map<Measure>(item)));
        }
    }
}
