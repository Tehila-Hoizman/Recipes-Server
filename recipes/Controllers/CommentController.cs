using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<CommentDto>> Get()
        {
            var comments = await service.GetAllAsync();
            foreach (var comment in comments)
            {
                comment.UrlImageUser = GetImageEditor(comment.UrlImageUser);
            }
            return comments;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<CommentDto> Get(int id)
        {
            return await service.GetAsyncById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CommentDto comment)
        {
            return Ok(await service.AddItemAsync(comment));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CommentDto c)
        {
            await service.UpdateAsync(id, c);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
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
