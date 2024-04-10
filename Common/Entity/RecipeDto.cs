using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public enum eDifficulty { empty, hard, medium, easy }

    public class RecipeDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Instructions { get; set; }
        public int? DurationOfPreparation { get; set; }
        public eDifficulty LevelOfDifficulty { get; set; }

        //public int LevelOfDifficulty { get; set; }
        public int NumOfPieces { get; set; }
        //public List<int>? CategoriesIdList { get; set; }
        public int EditorId { get; set; }
        public string? EditorName { get; set; }
        public string? UrlImageEditor { get; set; }

        public DateTime? UploadTime { get; set; }
        //public List<IFormFile>? FilelImages { get; set; }
        //public List<string>? UrlImages { get; set; }
        public IFormFile? FilelImage { get; set; }
        public string? UrlImage { get; set; }
        public virtual ICollection<int>? CategoriesId { get; set; }

        //public virtual ICollection<int>? UsersId { get; set; }

    }
}
