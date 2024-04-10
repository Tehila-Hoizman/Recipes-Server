using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using Service.Interfaces;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly SendEmailService emailService;

        public UserController(IUserService service,SendEmailService emailService)
        {
            this.service = service;
            this.emailService = emailService;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var user = await service.GetAsyncById(id);
            user.UrlImage = GetImage(user.UrlImage);
            return user;    
        }

        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<UserDto>> Get(string email,string password)
        {
            UserDto user = await service.GetUserByEmailAndPassword(email, password);

            if (user == null)
            {
                return NotFound("User not found");
            }
            user.UrlImage = GetImage(user.UrlImage);
            return user;
        }

        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            if (ImageUrl !="null"&& ImageUrl != "")
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


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] UserDto userDto)
        {
            try
            {
                if (userDto != null && userDto.FilelImage != null)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + userDto.FilelImage.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        userDto.FilelImage.CopyTo(fs);
                        fs.Close();
                    }
                    userDto.UrlImage = userDto.FilelImage.FileName;
                }
                return Ok(await service.AddItemAsync(userDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sendEmail")]
        public async Task<ActionResult> Post([FromBody]EmailDto emailDto)
        {
            emailService.SendMailToManager(emailDto);
           return Ok();
        }
        //[HttpPost("favorite/add")]
        //public async Task<ActionResult> Post([FromBody] FollowerDto followerDto)
        //{
        //    await service.AddFavorite(followerDto.RecipeId,followerDto.UserId);
        //    return Ok();
        //}

        //[HttpPost("favorite/remove/")]
        //public async Task<ActionResult> Post([FromBody] FollowerDto followerDto,int i)
        //{
        //    await service.RemoveFavorite(followerDto.RecipeId, followerDto.UserId);
        //    return Ok();
        //}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UserDto userDto)
        {
            try
            {
                if (userDto != null && userDto.FilelImage != null)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + userDto.FilelImage.FileName);
                    Console.WriteLine("myPath: " + myPath);

                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        userDto.FilelImage.CopyTo(fs);
                        fs.Close();
                    }
                    userDto.UrlImage = userDto.FilelImage.FileName;
                }
               return Ok( await service.UpdateAsync(id,userDto));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost("isEmailExist")]
        public async Task<bool> Post([FromBody] EmailDto emailDto,int i)
        {
            return await service.IsEmailExist(emailDto.Email);
        }
    }
}
