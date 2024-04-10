using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CategoryDto> service;

        public CategoryController(IService<CategoryDto> service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            var categories = await service.GetAllAsync();
            foreach (var category in categories)
            {
                foreach(var recipe in category.Recipes)
                {
                    recipe.UrlImage=GetImagRecipe(recipe.UrlImage);
                    recipe.UrlImageEditor = GetImage(recipe.UrlImageEditor);
                }
                category.UrlImage = GetImage(category.UrlImage);
            }
            return categories;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto != null && categoryDto.FilelImage != null)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + categoryDto.FilelImage.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        categoryDto.FilelImage.CopyTo(fs);
                        fs.Close();
                    }
                    categoryDto.UrlImage = categoryDto.FilelImage.FileName;
                }
                return Ok(await service.AddItemAsync(categoryDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
        public async Task Put(int id, [FromBody] CategoryDto c)
        {
            await service.UpdateAsync(id, c);
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
            if (ImageUrl!=null&&ImageUrl != "null" && ImageUrl != "")
            {
                var path = Path.Combine(Environment.CurrentDirectory + "/images/", ImageUrl);
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                string imageBase64 = Convert.ToBase64String(bytes);
                string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
                return image;
            }
            else
            {
                return "error";
            }
        }
        [HttpGet("getImageRecipe/{ImageUrl}")]
        public string GetImagRecipe(string ImageUrl)
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
    }

}
