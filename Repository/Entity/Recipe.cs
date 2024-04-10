using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public enum eDifficulty { empty, hard, medium, easy }

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int DurationOfPreparation { get; set; }
        public eDifficulty LevelOfDifficulty { get; set; }

        //public int LevelOfDifficulty { get; set; }
        public int NumOfPieces { get; set; }
        public DateTime UploadTime { get; set; }

        //[ForeignKey("CategoriesIdList")]
        //public virtual ICollection<Category> Categories { get; set; }
        //public List<int> CategoriesIdList { get; set; }

        [ForeignKey("EditorId")]
        public virtual User Editor { get; set; }

        public int EditorId { get; set; }

        //public List<string>? UrlImages { get; set; }
        public string? UrlImage { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Comment> CommentsToRecipe { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        //public virtual ICollection<User>? UsersLiked { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }

    }
}
