using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe recipe { get; set; }
        //public int Id { get; set; }
        //public User follower { get; set; }
        //public int followerAfterId { get; set; }
        //public bool isUser {  get; set; }
    }
}
