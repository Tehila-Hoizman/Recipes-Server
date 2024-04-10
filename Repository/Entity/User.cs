using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public enum eNewsletter { empty, yes, no }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public eNewsletter WantNewsletter { get; set; }
        //public string? image { get; set; }
        public string? UrlImage { get; set; }
        //public virtual ICollection<Recipe> FavoriteRecipes { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }

        public virtual ICollection<Recipe> RecipesEditedByTheUser { get; set; }
        //public virtual ICollection<Comment> CommentsOfUser { get; set; }

        //public virtual ICollection<Comment> CommentsEditedByTheUser { get; set; }

    }
}
