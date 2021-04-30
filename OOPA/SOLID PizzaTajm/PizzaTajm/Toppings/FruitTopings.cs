using System;
using System.Collections.Generic;
using System.Linq;
using PizzaTajm.Database;
using PizzaTajm.Interfaces;

namespace PizzaTajm
{
    internal class FruitTopings : IPizzaTopping
    {
        public List<IStuff> Ingredients { get; set; }
        public void Generate(int max)
        {
            Ingredients = new List<IStuff>();
            using (var db = new PizzaTajmContext())
            {
                Ingredients.AddRange(db.Fruits.OrderBy(i => Guid.NewGuid()).Take(max));
            }
        }
    }
}