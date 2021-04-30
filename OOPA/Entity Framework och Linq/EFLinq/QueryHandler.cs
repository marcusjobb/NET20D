using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFLinq.Database;
using Microsoft.EntityFrameworkCore;

namespace EFLinq
{
    public class QueryHandler
    {
        private readonly EFLinqContext db = new EFLinqContext();
        internal void ListAllPeopleAndAnimals()
        {
            Console.WriteLine("Alla adresser, personer och djur");
            var everything = db.Home.Include(t => t.Tenants).ThenInclude(p => p.Pets);
            foreach (var house in everything)
            {
                Console.WriteLine(house.Address + ":");
                if (house.Tenants != null)
                {
                    foreach (var person in house?.Tenants)
                    {
                        Console.Write("  " + person.Name);
                        if (person.Pets != null)
                        {
                            foreach (var pet in person?.Pets)
                            {
                                Console.Write(" - " + pet.Name + ", " + pet.Typ);
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine(new string('-', 100));
        }

        internal void ListAllPetOwners()
        {
            Console.WriteLine("Alla djurägare");
            var pets = db.People.Include("Pets").Where(p => p.Pets.Count() > 0);
            foreach (var person in pets)
            {
                Console.WriteLine(person.Name);
                foreach (var pet in person.Pets)
                {
                    Console.WriteLine("   " + pet.Name);
                }
            }
        }

        internal void ListAllHouseWithPetType(string type)
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Alla hus där det bor en {type}");
            // Lista alla adresser där det bor en hund
            var dogOwners = db.Home.Where(t => t.Tenants.Any(p => p.Pets.Any(p => p.Typ==type)));

            foreach (var adr in dogOwners)
            {
                Console.WriteLine(adr.Address);
                //ListResidentsAt(adr.Address);
            }
            Console.WriteLine(new string('-', 100));

        }

        internal void ListResidentsAt(string address)
        {
            Console.WriteLine($"Alla som bor på {address}");
            var House = db.Home.Include("Tenants").Where(a => a.Address.Contains(address));
            if (House != null)
            {
                foreach (var house in House)
                {
                    foreach (var tenant in house.Tenants)
                    {
                        Console.WriteLine(tenant.Name);
                    }
                }
            }
        }
    }
}
