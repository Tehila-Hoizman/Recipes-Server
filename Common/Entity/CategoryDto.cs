using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? FilelImage { get; set; }
        public string? UrlImage { get; set; }
        public virtual ICollection<RecipeDto>? Recipes { get; set; }

    }
}
