using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public string? Content { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? ReplyToId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UrlImageUser { get; set; }

        public int? RecipeId { get; set; }
    }
}
