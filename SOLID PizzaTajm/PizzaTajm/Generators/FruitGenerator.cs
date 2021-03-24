using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaTajm.Database;
using PizzaTajm.Interfaces;

namespace PizzaTajm.Generators
{
    public class FruitGenerator:IPizzaTopping
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
