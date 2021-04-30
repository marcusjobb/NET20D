namespace TisdagsÖvningCSDB
{
    using System;
    using System.Linq;
    using System.Data;

    internal static class Övning6
    {
        internal static void Run()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Master"
            };
            var list = db.GetDataTable("SELECT name FROM sys.databases");
            foreach (DataRow row in list.Rows)
            {
                Console.WriteLine($"{row["name"].ToString().Trim()}");
            }
        }

        internal static void Run2()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Master"
            };
            var list = db.GetDatabases();
            list.Sort();
            foreach (var row in list)
            {
                Console.WriteLine($"{row}");
            }
        }
    }
}