using System.Collections.Generic;
using System.Linq;
using EFLinq.Models;

namespace EFLinq.Database
{
    public static class Seeder
    {
        public static void Seed()
        {
            using (var db = new EFLinqContext())
            {
                if (db.Pets.Count() == 0)
                {
                    db.Pets.AddRange(new List<Pet>
                    {
                        new Pet{Name="Misse", Typ="Katt"},
                        new Pet{Name="Vovven", Typ="Hund"},
                        new Pet{Name="Nisse", Typ="Katt"},
                    });
                    db.SaveChanges();
                }

                if (db.People.Count() == 0)
                {
                    db.People.AddRange(new List<Person>
                    {
                        new Person{ Name="Martin",Pets=new List<Pet>{db.Pets.FirstOrDefault(p=>p.Name=="Misse")}},
                        new Person{ Name="Petrov", Pets=new List<Pet>{db.Pets.FirstOrDefault(p=>p.Name=="Vovven")} },
                        new Person{ Name="Johan", Pets=new List<Pet>{db.Pets.FirstOrDefault(p=>p.Name=="Nisse")} },
                    });
                    db.SaveChanges();
                }

                if (db.Home.Count() == 0)
                {
                    var petrov = db.People.FirstOrDefault(p => p.Name == "Petrov");
                    var martin = db.People.FirstOrDefault(p => p.Name == "Martin");
                    var Johan = db.People.FirstOrDefault(p => p.Name == "Johan");
                    db.Home.Add(new House { Address = "Västra gatan 5", Tenants = new List<Person> { petrov, Johan } });
                    db.Home.Add(new House { Address = "Södra gatan 5", Tenants = new List<Person> { martin, Johan } });
                    db.SaveChanges();
                }
            }
        }
    }
}
