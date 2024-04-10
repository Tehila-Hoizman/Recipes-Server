using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IService<RecipeDto> service;

        public RecipeController(IService<RecipeDto> service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<RecipeDto>> Get()
        {
            var recipe = await service.GetAllAsync();
            foreach (var r in recipe)
            {
                r.UrlImage=GetImage(r.UrlImage);
                r.UrlImageEditor=GetImageEditor(r.UrlImageEditor);
            }
            return recipe;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<RecipeDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] RecipeDto recipeDto)
        {
            try
            {
                if (recipeDto != null && recipeDto.FilelImage != null)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/recipies/" + recipeDto.FilelImage.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        recipeDto.FilelImage.CopyTo(fs);
                        fs.Close();
                    }
                    recipeDto.UrlImage = recipeDto.FilelImage.FileName;
                }
                return Ok(await service.AddItemAsync(recipeDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        // PUT api/<RoleController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] RecipeDto r)
        //{
        //    return Ok(await service.UpdateAsync(id, r));
        //}
        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id,[FromForm] RecipeDto recipeDto)
        {
            try
            {
                if (recipeDto != null && recipeDto.FilelImage != null)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/recipies/" + recipeDto.FilelImage.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        recipeDto.FilelImage.CopyTo(fs);
                        fs.Close();
                    }
                    recipeDto.UrlImage = recipeDto.FilelImage.FileName;
                }
                return Ok(await service.UpdateAsync(id,recipeDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }



        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            if (ImageUrl != "null" && ImageUrl != "")
            {
                var path = Path.Combine(Environment.CurrentDirectory + "/images/recipies/", ImageUrl);
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                string imageBase64 = Convert.ToBase64String(bytes);
                string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
                return image;
            }
            else
                return "error";
        }
        [HttpGet("getImageEditor/{ImageUrl}")]
        public string GetImageEditor(string ImageUrl)
        {
            if (ImageUrl != "null" && ImageUrl != "")
            {
                var path = Path.Combine(Environment.CurrentDirectory + "/images/", ImageUrl);
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                string imageBase64 = Convert.ToBase64String(bytes);
                string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
                return image;
            }
            else
                return "error";
        }
    }
}
