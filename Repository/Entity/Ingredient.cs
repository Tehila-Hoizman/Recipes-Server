using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Ingredient
    {
        public int Id { get; set; }//id
        public string Name { get; set; }//שם מוצר
        [ForeignKey("MeasureId")]
        public virtual Measure Measure { get; set; }//מידה
        public int MeasureId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }//לאיזה מתכון שייך
        public int RecipeId { get; set; }
        public double Amount { get; set; }//כמות


    }
}
