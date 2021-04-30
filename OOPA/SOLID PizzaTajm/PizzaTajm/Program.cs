namespace PizzaTajm
{
    using System;
    using System.Collections.Generic;
    using PizzaTajm.Generators;
    using PizzaTajm.Interfaces;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        internal static void Main()
        {
            Seeder.Seed();

            var pizza = new PizzaGenerator(PizzaType.Vego,2);

            var lst = new List<IPizzaTopping>
            {
                new VegetableGenerator(),
                new FruitGenerator(),
                new SpicesGenerator(),
            };

            foreach (var ingredient in pizza.MakePizza(lst))
            {
                Console.WriteLine(ingredient.Name+ " - "+ ingredient.GetType().ToString().Replace("PizzaTajm.Models.",""));
            }
        }
    }
}
