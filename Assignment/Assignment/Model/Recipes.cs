using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Recipes
    {
        public Recipes()
        {
            recipes = new List<Recipe>();
        }
        public List<Recipe> recipes { get; set; }
    }
}
