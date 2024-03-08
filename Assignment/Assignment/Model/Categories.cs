using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Categories
    {
        public Categories()
        {
            categories = new List<Category>();
        }
        public List<Category> categories { get; set; }
    }
}
