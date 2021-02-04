namespace TisdagsÖvningCSDB
{
    using System;
    using System.Data;

    internal static class Övning3
    {
        internal static void Run()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Population"
            };
            var list = db.GetDataTable("SELECT * FROM People WHERE age>30 AND age<50 Order by age");
            foreach (DataRow row in list.Rows)
            {
                Console.WriteLine($"{row["Name"].ToString().Trim()}, {row["Age"]} ");
            }
        }
    }
}