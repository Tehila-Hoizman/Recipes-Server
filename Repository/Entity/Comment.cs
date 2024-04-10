using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime commentDate { get; set; }
        public int replyToId { get; set; }

        [ForeignKey("UserId")]
        public virtual User editor { get; set; }
        public int UserId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe replyToRecipe { get; set; }
        public int RecipeId { get; set; }

        //public User editor { get; set; }
        //public Recipe replyToRecipe { get; set; }
    }
}
