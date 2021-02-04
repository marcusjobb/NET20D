namespace TisdagsÖvningCSDB
{
    using System;
    using System.Data;

    internal static class Övning4
    {
        internal static void Run()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Population"
            };
            var list = db.GetDataTable("SELECT physical_name, size FROM sys.database_files");
            foreach (DataRow row in list.Rows)
            {
                Console.WriteLine($"{row["physical_name"].ToString().Trim()}, {row["size"]} ");
            }
        }

        internal static void Run2()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Population"
            };
            var list = db.GetDatabaseFiles();
            foreach (var row in list)
            {
                Console.WriteLine($"{row}");
            }
        }
    }
}