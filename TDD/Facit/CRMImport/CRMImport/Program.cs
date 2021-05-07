namespace CRMImport
{
    using System;
    using System.IO;

    internal static class Program
    {
        private static void Main()
        {
            const string filename = "json.txt";
            if (File.Exists(filename))
            {
                var imp = new ImportCMS();
                var people = ImportCMS.Import(File.ReadAllText(filename));
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.name} - {person.email}");
                }
            }
        }
    }
}