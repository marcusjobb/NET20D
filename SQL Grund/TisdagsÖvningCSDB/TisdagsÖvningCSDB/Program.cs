using System.Data.SqlClient;

namespace TisdagsÖvningCSDB
{
    internal static class Program
    {
        private static void Main()
        {
            //Övning3.Run();
            //Övning4.Run();
            //Övning4.Run2();
            //Övning6.Run();
            //Övning6.Run2();
            //Övning7.Run();
            //Övning7.Run2();
            //Övning8.Run();
            //Övning9.Run();


            DatabaseName = "School";
            AddStudent("James Willis", 13);
            AddStudent("Bruce Woods", 14);
            AddStudent("Robert'); DROP TABLE Students;--", 13);
            AddStudent("Peter Wayne", 14);
            AddStudent("Bruce Parker", 13);
            AddStudent("Clark Stark", 13);
            AddStudent("Tony Kent", 13);
        }

        internal static string ConnectionString { get; set; } = @"Data Source=.\SQLExpress;Integrated Security=true;database={0}";
        internal static string DatabaseName { get; set; } = "School";

        internal static void AddStudent(string name, int age)
        {
            var sql = $"INSERT INTO Students (age,name) VALUES(@age,@name);";
            var connString = string.Format(ConnectionString, DatabaseName);
            var cnn = new SqlConnection(connString);
            cnn.Open();
            var command = new SqlCommand(sql, cnn);
            command.Parameters.AddWithValue("@age", age);       // Lägg in parameter 
            command.Parameters.AddWithValue("@name", name);     // Lägg in parameter 
            command.ExecuteNonQuery();
        }

    }
}