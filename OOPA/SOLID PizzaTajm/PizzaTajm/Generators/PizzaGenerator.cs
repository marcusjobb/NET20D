using System;
using System.Collections.Generic;
using System.Linq;
using PizzaTajm.Database;
using PizzaTajm.Interfaces;

namespace PizzaTajm
{
    internal class PizzaGenerator
    {
        private PizzaType pizzaType;
        public int MaxIngredients { get; set; } = 2;
        public PizzaGenerator(PizzaType pizzaType, int maxIngredients)
        {
            this.pizzaType = pizzaType;
            MaxIngredients = maxIngredients;
        }

        public List<IStuff> MakePizza(List<IPizzaTopping> generators)
        {
            var ingredients = new List<IStuff>();
            //var generators = new List<IPizzaTopping>
            //{
            //    PizzaFactory.GetTopping(pizzaType),
            //    PizzaFactory.GetGenerator(GeneratorEnum.Spice),
            //    PizzaFactory.GetGenerator(GeneratorEnum.Vegetable),
            //    PizzaFactory.GetGenerator(GeneratorEnum.Fruit),
            //};

            using (var db = new PizzaTajmContext())
            {
                ingredients.Add(db.Doughs.OrderBy(d => Guid.NewGuid()).FirstOrDefault());
                foreach (var item in generators)
                {
                    item.Generate(MaxIngredients);
                    ingredients.AddRange(item.Ingredients);
                }
            }

            return ingredients;
        }

    }
}