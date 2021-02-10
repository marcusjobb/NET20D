// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------
namespace FamilyTree
{
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        private static void Main()
        {
            var db = new PersonCrud();
            db.CreateDatabase("MyFamily");
            db.CreateTable();
            db.ExecuteSQL("Delete from family");
            var mother = db.CreatePerson("Shmi", "Skywalker");
            var father = db.CreatePerson("The Force", "");
            var anakin = db.CreatePerson("Anakin", "Skywalker", mother, father);
            father = anakin;
            mother = db.CreatePerson("Padme", "Amidala");
            var luke = db.CreatePerson("Luke", "Skywalker", mother, father);
            var leia = db.CreatePerson("Leia", "Skywalker", mother, father); // adopted to Organa

            father = luke;
            mother = db.CreatePerson("Mara", "Jade");
            var child = db.CreatePerson("Ben", "Skywalker", mother, luke);

            var sibilings = db.GetHalfSiblings(anakin);

            Console.WriteLine("Siblings:");
            foreach (DataRow item in sibilings.Rows)
            {
                Console.WriteLine($"{item["firstName"]} {item["lastName"]}");
            }

            // TODO: GetSiblings/GetHalfSiblings är kanske inte bra namn då den visar barnen och 
            //       inte syskonen. Man kanske bör döpa om det till GetChildren...

            // Godkänt:
            // TODO: Lägg till födelsedatum och dödsdatum i tabellen
            //       Uppdatera CRUD till att hantera den datan
            // TODO: Uppdatera mammans efternamn exempelvis
            // TODO: Uppdatera person, sätt ID på föräldrarna
            // TODO: Radera en person
            // TODO: Visa föräldrars namn
            // TODO: Visa syskonens namn
            // TODO: Visa namnlista där förnamn börjar på viss bokstav
            // TODO: Visa efternamn där förnamn börjar på viss bokstav
            // TODO: Radera person (Exempelvis: Om det är Star Wars familj, radera Jar Jar Binks!)
            // TODO: Visa eventuella barn (varför inte)
            //       Alternativt
            //       Visa mormor och morfar
            //       Visa farmor och farfars namn

            // Väl godkänd
            // Lägg till födelsestad/dödstad i tabell och CRUD
            // TODO: Lägg till födelsestad/dödsstad (och land) i tabell och CRUD
            // TODO: Lista personer enligt födelsestad
            // TODO: XML kommentera alla metoder

            // Ninja
            // TODO: Lista kusiner, exempelvis sök MotherId --> Mother --> Children --> Children
            // TODO: Visa far och morbröder
            // TODO: Om du har en personklass, skapa en metod som hämtar moder/fader-objekt

            // SRC: https://drive.google.com/file/d/13VBDfsQkon_Ox5O5bmOeR-MNXXt3bwAC/view
        }
    }
}
