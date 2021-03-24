using System;
using System.Collections.Generic;
using System.Linq;
using PizzaTajm.Database;
using PizzaTajm.Models;

namespace PizzaTajm
{
    internal class Seeder
    {
        internal static void Seed()
        {
            using (var db = new PizzaTajmContext())
            {
                if (db.Cheeses.Count() == 0)
                {
                    db.Cheeses.AddRange(new List<Cheese>
                        {
                            new Cheese{ Name="Grevé" },
                            new Cheese{ Name="Gouda" },
                            new Cheese{ Name="Mozzarella" },
                            new Cheese{ Name="Chévre" },
                        });
                }
                if (db.VeganCheeses.Count() == 0)
                {
                    db.VeganCheeses.AddRange(new List<VeganCheese>
                        {
                            new VeganCheese{ Name="Violife Prosociano"},
                            new VeganCheese { Name = "Violife block" },
                            new VeganCheese { Name = "Gondino" },
                            new VeganCheese { Name = "GreenVie Mozzarella" },
                            new VeganCheese { Name = "Follow your heart pizzaost" },
                            new VeganCheese { Name = "Kryddig pepper jack" },
                            new VeganCheese { Name = "Violife fetaost" },
                            new VeganCheese { Name = "Halloumi" },
                        });
                }
                if (db.Doughs.Count() == 0)
                {
                    db.Doughs.AddRange(new List<Dough>
                        {
                            new Dough { Name="Smal"},
                            new Dough { Name="Tjock"},
                        });
                }

                if (db.Meats.Count() == 0)
                {
                    db.Meats.AddRange(new List<Meat>
                        {
                            new Meat { Name="Kossa"},
                            new Meat { Name="Kyckling"},
                            new Meat { Name="Gris"},
                            new Meat { Name="Sill"},
                            new Meat { Name="Surströmming"},
                        });
                }

                if (db.Vegan.Count() == 0)
                {
                    db.Vegan.AddRange(new List<Vegan>
                        {
                            new Vegan{ Name="Tofu"},
                            new Vegan{ Name="Falafel"},
                            new Vegan{ Name="Omph"},
                        });
                }

                if (db.Vegetables.Count() == 0)
                {
                    db.Vegetables.AddRange(new List<Vegetable>
                        {
                            new Vegetable{ Name="Morötter"},
                            new Vegetable{ Name="Ärtor"},
                            new Vegetable{ Name="Selleri"},
                            new Vegetable{ Name="Tomat"},
                            new Vegetable{ Name="Ruccola"},
                            new Vegetable{ Name="Gurka"},
                        });
                }
                if (db.Fruits.Count() == 0)
                {
                    db.Fruits.AddRange(new List<Fruit>
                        {
                            new Fruit{ Name="Ananas"},
                            new Fruit{ Name="Päron"},
                            new Fruit{ Name="Äpple"},
                            new Fruit{ Name="Banan"},
                        });
                }
                if (!db.Spices.Any())
                {
                    db.Spices.AddRange(new List<Spice>
                        {
                            new Spice{ Name="Oregano"},
                            new Spice{ Name="Mynta"},
                            new Spice{ Name="Jordnötter"},
                            new Spice{ Name="Valnötter"},
                            new Spice{ Name="Nutella"},
                            new Spice{ Name="Chili"},
                        });
                }
                db.SaveChanges();
            }
        }
    }
}