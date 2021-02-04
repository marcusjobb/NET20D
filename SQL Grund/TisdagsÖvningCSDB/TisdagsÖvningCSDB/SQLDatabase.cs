namespace TisdagsÖvningCSDB
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// SQL-Server Database helper
    /// </summary>
    public class SQLDatabase
    {
        /// <summary>
        /// A template for the connection string
        /// </summary>
        internal string ConnectionString { get; set; } = @"Data Source=.\SQLExpress;Integrated Security=true;database={0}";
        // The name of the database to use
        internal string DatabaseName { get; set; } = "population";

        // TODO: Gör en metod för sp_spaceUsed

        /// <summary>
        /// Import an SQL-file and execute it's content
        /// </summary>
        /// <param name="filename">file name</param>
        internal void ImportSQL(string filename)
        {
            if (File.Exists(filename))
            {
                var sql = File.ReadAllText(filename);
                ExecuteSQL(sql);
            }
        }

        /// <summary>
        /// Create a Database
        /// </summary>
        /// <param name="name">Name of the database</param>
        /// <param name="OpenNewDatabase">Use the new database after creation</param>
        internal void CreateDatabase(string name, bool OpenNewDatabase = false)
        {
            ExecuteSQL("CREATE DATABASE " + name);
            if (OpenNewDatabase) DatabaseName = name;
        }

        /// <summary>
        /// Gets a datatable from the Database
        /// </summary>
        /// <param name="sqlString">The string to execute</param>
        /// <param name="parameters">The parameters to send (Tuple)</param>
        /// <returns></returns>
        internal DataTable GetDataTable(string sqlString, params (string, string)[] parameters)
        {
            var dt = new DataTable();
            var connString = string.Format(ConnectionString, DatabaseName);
            try
            {
                using (var cnn = new SqlConnection(connString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand(sqlString, cnn))
                    {
                        SetParameters(parameters, command);

                        try
                        {
                            using (var adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return dt;
        }

        /// <summary>
        /// Just a method to add parameters to a SQLCommand
        /// </summary>
        /// <param name="parameters">Tuple list of parameters</param>
        /// <param name="command">The SqlCommand</param>
        private static void SetParameters((string, string)[] parameters, SqlCommand command)
        {
            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Item1, item.Item2);
            }
        }

        /// <summary>
        /// Executes DROP Database
        /// </summary>
        /// <param name="name">Database name</param>
        internal void DropDatabase(string name)
        {
            DatabaseName = "Master";

            // Database is being used issue - https://stackoverflow.com/a/20569152/15032536
            ExecuteSQL(" alter database [" + name + "] set single_user with rollback immediate");

            ExecuteSQL("DROP DATABASE " + name);
        }

        /// <summary>
        /// Executes DROP TABÖE
        /// </summary>
        /// <param name="name">The name of the table</param>
        internal void DropTable(string name)
        {
            ExecuteSQL($"DROP TABLE {name};");
        }

        /// <summary>
        /// Alters a table
        /// </summary>
        /// <param name="name">Table name</param>
        /// <param name="fields">Fields to add or delete, commaseparated</param>
        internal void AlterTable(string name, string fields)
        {
            ExecuteSQL($"ALTER TABLE {name} {fields};");
        }

        /// <summary>
        /// Alter table, Add fields
        /// </summary>
        /// <param name="name">Table name</param>
        /// <param name="fields">Fields to add or delete, commaseparated</param>
        internal void AlterTableAdd(string name, string fields)
        {
            ExecuteSQL($"ALTER TABLE {name} ADD {fields};");
        }

        /// <summary>
        /// Alter table, DROP fields
        /// </summary>
        /// <param name="name">Table name</param>
        /// <param name="fields">Fields to add or delete, commaseparated</param>
        internal void AlterTableDrop(string name, string field)
        {
            ExecuteSQL($"ALTER TABLE {name} DROP COLUMN {field};");
        }

        /// <summary>
        /// Executes CREATE TABLE
        /// </summary>
        /// <param name="name">Table name</param>
        /// <param name="fields">Fields to add to the table</param>
        internal void CreateTable(string name, string fields)
        {
            ExecuteSQL($"CREATE TABLE {name} ({fields});");
        }

        /// <summary>
        /// Gets a list of the available databases in the server
        /// </summary>
        /// <returns>A string List of the tables</returns>
        internal List<string> GetDatabases()
        {
            var list = new List<string>();
            var files = GetDataTable("SELECT name FROM sys.databases");
            foreach (DataRow row in files.Rows)
            {
                list.Add($"{row["name"].ToString().Trim()}");
            }
            return list;
        }
        /// <summary>
        /// Verifies if a database exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal bool DoesDatabaseExist(string name)
        {
            var theDB = GetDataTable("SELECT name FROM sys.databases Where name = @name", ("@name", name));
            return theDB?.Rows.Count > 0;
        }

        /// <summary>
        /// Executes SQL code
        /// </summary>
        /// <param name="sqlString">The SQL String</param>
        /// <param name="parameters">Tuples with parameters</param>
        /// <returns></returns>
        internal long ExecuteSQL(string sqlString, params (string, string)[] parameters)
        {
            long rowsAffected = 0;
            try
            {
                var connString = string.Format(ConnectionString, DatabaseName);
                using (var cnn = new SqlConnection(connString))
                {
                    cnn.Open();
                    using (var command = new SqlCommand(sqlString, cnn))
                    {
                        SetParameters(parameters, command);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return rowsAffected;
        }

        /// <summary>
        /// Gets a list of the files used by the database
        /// </summary>
        /// <returns>A list with strings</returns>
        internal List<string> GetDatabaseFiles()
        {
            var list = new List<string>();
            var files = GetDataTable("SELECT physical_name, size FROM sys.database_files");
            foreach (DataRow row in files.Rows)
            {
                list.Add($"{row["physical_name"].ToString().Trim()}");
            }
            return list;
        }
    }
}