﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaTajm.Database;
using PizzaTajm.Interfaces;
using PizzaTajm.Models;

namespace PizzaTajm
{
    public class VeganTopings : IPizzaTopping
    {
        public List<IStuff> Ingredients { get; set; } 
        public void Generate(int max)
        {
            Ingredients = new List<IStuff>();
            using (var db = new PizzaTajmContext())
            {
                Ingredients.AddRange(db.Vegan.OrderBy(i => Guid.NewGuid()).Take(max));
                Ingredients.AddRange(db.VeganCheeses.OrderBy(i => Guid.NewGuid()).Take(max));            
            }
        }

    }
}
