using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IService<MeasureDto> service;

        public MeasureController(IService<MeasureDto> service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<MeasureDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<MeasureDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task Post([FromBody] MeasureDto measure)
        {
            await service.AddItemAsync(measure);
        }



        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] MeasureDto m)
        {
            await service.UpdateAsync(id, m);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
