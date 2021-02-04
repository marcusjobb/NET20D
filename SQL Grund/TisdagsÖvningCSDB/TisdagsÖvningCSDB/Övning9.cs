﻿namespace TisdagsÖvningCSDB
{
    using System;

    internal static class Övning9
    {
        internal static void Run()
        {
            var crud = new People();

            crud.Create(new Person
            {
                FirstName = "Marcus",
                LastName = "Medina",
                Address = "Gula huset till vänster",
                City = "Onsala",
                Age = 50,
            });
            Console.WriteLine("Created person");
            var person = crud.Read("Marcus Medina");
            Print(person);

            person = crud.Read("Phillip");
            Print(person);

            person = crud.Read("Marcus Medina");
            person.Address = "Tredje huset till vänster";
            crud.Update(person);

            Console.WriteLine("Updated person");
            person = crud.Read("Marcus Medina");
            Print(person);

            Console.WriteLine("Deleted person");
            crud.Delete(person);

            person = crud.Read("Marcus Medina");
            Print(person);

            var people = crud.List();
            foreach (var p in people)
            {
                Print(p);
            }
        }

        private static void Print(Person person)
        {
            if (person != null)
                Console.WriteLine($"{person.FirstName} {person.LastName}, är {person.Age} år och bor i {person.Address}, {person.City}");
            else
                Console.WriteLine("Person not found");
        }
    }
}