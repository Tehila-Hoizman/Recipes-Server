using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class IngredientDto
    {
        public int? Id { get; set; }//id
        public string Name { get; set; }//שם מוצר
        public double Amount { get; set; }//כמות
        public int MeasureId { get; set; }
        public int RecipeId { get; set; }

    }
}
