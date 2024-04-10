using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerService service;

        public FollowerController(IFollowerService service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<FollowerDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<FollowerDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task Post([FromBody] FollowerDto follower)
        {
            await service.AddItemAsync(follower);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FollowerDto f)
        {
            await service.UpdateAsync(id, f);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
        [HttpDelete("{userId}/{recipeId}")]
        public async Task Delete(int recipeId, int userId)
        {
            await service.DeleteByRecipeUser(userId, recipeId);
        }
    }
}
