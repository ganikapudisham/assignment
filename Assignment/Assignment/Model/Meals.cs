﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Meals
    {
        public Meals()
        {
            meals = new List<Meal>();
        }
        public List<Meal> meals { get; set; }
    }
}
