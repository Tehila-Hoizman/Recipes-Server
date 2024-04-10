using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IService<IngredientDto> service;

        public IngredientController(IService<IngredientDto> service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<IngredientDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IngredientDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IngredientDto ingredient)
        {
            return Ok( await service.AddItemAsync(ingredient));
        }

        //[HttpPost]
        //public async Task<ActionResult> Post([FromForm] UserDto userDto)
        //{

        //    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + userDto.FilelImage.FileName);
        //    Console.WriteLine("myPath: " + myPath);

        //    using (FileStream fs = new FileStream(myPath, FileMode.Create))
        //    {
        //        userDto.FilelImage.CopyTo(fs);
        //        fs.Close();
        //    }
        //    userDto.UrlImage = userDto.FilelImage.FileName;
        //    return Ok(await service.AddItemAsync(userDto));
        //}
        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] IngredientDto i)
        {
            await service.UpdateAsync(id, i);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
