namespace TisdagsÖvningCSDB
{
    using System;

    internal static class Övning9
    {
        internal static void Run()
        {
            var crud = new People();

            var marcus = new Person
            {
                FirstName = "Marcus",
                LastName = "Medina",
                Address = "Gula huset till vänster",
                City = "Onsala",
                Age = 50,
            };
            crud.Create(marcus);
            Console.WriteLine("Created person");

            var person = crud.Read("Marcus Medina");
            Print(person);

            person = crud.Read("Hounsom");
            Print(person);

            person = crud.Read("Marcus Medina");
            person.Address = "Tredje huset till vänster";
            crud.Update(person);

            Console.WriteLine("Updated person");
            person = crud.Read("Marcus Medina");
            Print(person);

            crud.Delete(person);
            Console.WriteLine("Deleted person");

            person = crud.Read("Marcus Medina");
            Print(person);

            var people = crud.List("Name LIKE %Robin%", "Age Desc", 100);
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