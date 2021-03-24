using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaTajm.Interfaces;

namespace PizzaTajm
{
    public static class PizzaFactory
    {
        public static IPizzaTopping GetTopping(PizzaType pizzaType)
        {
            IPizzaTopping topping = new VeganTopings();

            if (pizzaType == PizzaType.Vego) topping = new VeganTopings();
            else if (pizzaType == PizzaType.Fruit) topping = new FruitTopings();

            return topping;
        }

        internal static IPizzaTopping GetGenerator(GeneratorEnum type)
        {
            IPizzaTopping generator = new SpicesGenerator();
            if (type == GeneratorEnum.Spice) generator = new SpicesGenerator();
            if (type == GeneratorEnum.Vegetable) generator = new VegetableGenerator();
            if (type == GeneratorEnum.Fruit) generator = new FruitTopings();

            return generator;
        }
    }
}
