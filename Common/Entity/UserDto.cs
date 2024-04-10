using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Common.Entity
{
    public enum eNewsletter { empty, yes, no }

    public class UserDto
    {
        
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Level { get; set; }
        public eNewsletter? WantNewsletter { get; set; }
        public IFormFile? FilelImage { get; set; }
        public string? UrlImage { get; set; }
        //public virtual ICollection<int>? FavoriteRecipes { get; set; }

        public virtual ICollection<FollowerDto>? Followers { get; set; }


    }
}
