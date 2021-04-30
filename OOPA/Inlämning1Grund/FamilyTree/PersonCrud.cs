// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------

namespace FamilyTree
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;

    /// <summary>
    /// Defines the <see cref="PersonCrud" />.
    /// </summary>
    internal class PersonCrud
    {
        /// <summary>
        /// Defines the connString.
        /// </summary>
        private string connString = @"Data Source=.\SQLExpress;Integrated Security=true;database={0}";

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        public string database { get; set; } = "MyFamily";

        /// <summary>
        /// The Create method.
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/>.</param>
        /// <param name="lastName">The lastName<see cref="string"/>.</param>
        public void Create(string firstName, string lastName)
        {
            /*
             * Does pretty much the same as  
             * Insert Into family (firstName,lastName) VALUES('Jason','Vorhees');
             */
            var sql = "Insert Into family (firstName,lastName) VALUES(@firstname,@lastname);";
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// The Create method.
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/>.</param>
        /// <param name="lastName">The lastName<see cref="string"/>.</param>
        /// <param name="mother">The mother<see cref="int"/>.</param>
        /// <param name="father">The father<see cref="int"/>.</param>
        public void Create(string firstName, string lastName, int mother, int father)
        {
            var sql = "Insert Into family (firstName,lastName,mother,father) VALUES(@firstname,@lastname,@mother,@father);";
            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@mother", mother);
            cmd.Parameters.AddWithValue("@father", father);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// The CreateDatabase method.
        /// </summary>
        public void CreateDatabase(string databaseName)
        {
            /*
             *  quick and dirty
             *  tries to create database, if it fails it assumes the database
             *  already exists
             */
            string sql = $"CREATE DATABASE {databaseName}";
            database = "Master";
            try
            {
                ExecuteSQL(sql);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            database = databaseName;
        }

        /// <summary>
        /// Creates a person in the database
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/>.</param>
        /// <param name="lastName">The lastName<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CreatePerson(string firstName, string lastName)
        {
            var personId = GetPersonId(firstName, lastName);
            if (personId == 0)
            {
                Create(firstName, lastName);
                personId = GetPersonId(firstName, lastName);
            }
            return personId;
        }

        /// <summary>
        /// Creates a person in the database
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/>.</param>
        /// <param name="lastName">The lastName<see cref="string"/>.</param>
        /// <param name="mother">The mother<see cref="int"/>.</param>
        /// <param name="father">The father<see cref="int"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CreatePerson(string firstName, string lastName, int mother, int father)
        {
            var personId = GetPersonId(firstName, lastName);
            if (personId == 0)
            {
                Create(firstName, lastName, mother, father);
                personId = GetPersonId(firstName, lastName);
            }
            return personId;
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        public void CreateTable()
        {
            /*
             *  quick and dirty
             *  tries to create a table, if it fails it assumes the table
             *  already exists
             */
            string sql = @"
                        CREATE TABLE [dbo].[family](
                        [id] [int] IDENTITY(1,1) NOT NULL,
                        [firstName] [nvarchar](50) NULL,
                        [lastName] [nvarchar](50) NULL,
                        [mother] [int] NULL,
                        [father] [int] NULL
                        ) ON [PRIMARY]
                        ";
            try
            {
                ExecuteSQL(sql);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// The common ExecuteSQL method.
        /// </summary>
        /// <param name="sql">The sql<see cref="string"/>.</param>
        public void ExecuteSQL(string sql)
        {
            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// The GetHalfSiblings.
        /// </summary>
        /// <param name="parent">The parent Id<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetHalfSiblings(int parent)
        {
            /*
             *  looks for mother or father with the parent Id
             */

            var sql = @"
                SELECT * FROM family Where
                mother= @parent OR
                father = @parent
                ";

            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@parent", parent);
            var dt = new DataTable();
            var adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>
        /// The GetPersonId, gets the Id to a person.
        /// </summary>
        /// <param name="firstName">The firstName<see cref="string"/>.</param>
        /// <param name="lastName">The lastName<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetPersonId(string firstName, string lastName)
        {
            var sql = "SELECT TOP 1 Id from family Where firstName=@firstname and lastName=@lastname;";
            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            var dt = new DataTable();
            var adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            conn.Close();

            if (dt.Rows.Count == 0) return 0;

            var row = dt.Rows[0];
            var id = (int)row["Id"];
            return id;
        }

        /// <summary>
        /// The GetSiblings.
        /// </summary>
        /// <param name="motherId">The motherId<see cref="int"/>.</param>
        /// <param name="fatherId">The fatherId<see cref="int"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSiblings(int motherId, int fatherId)
        {
            var sql = @"
                SELECT * FROM family Where
                mother= @mother AND
                father = @father;
                ";

            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@mother", motherId);
            cmd.Parameters.AddWithValue("@father", fatherId);
            var dt = new DataTable();
            var adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            conn.Close();
            return dt;
        }

        /// <summary>
        /// The GetSiblings.
        /// </summary>
        /// <param name="motherFirstName">The motherFirstName<see cref="string"/>.</param>
        /// <param name="motherLastName">The motherLastName<see cref="string"/>.</param>
        /// <param name="fatherFirstName">The fatherFirstName<see cref="string"/>.</param>
        /// <param name="fatherLastName">The fatherLastName<see cref="string"/>.</param>
        /// <returns>The <see cref="DataTable"/>.</returns>
        public DataTable GetSiblings(string motherFirstName, string motherLastName, string fatherFirstName, string fatherLastName)
        {
            var sql = @"
                SELECT * FROM family Where
                mother= (SELECT Id From family where firstName=@motherfirst and lastName=@motherlast) AND
                father = (SELECT Id From family where firstName=@fatherfirst and lastName=@fatherlast);
                ";

            var conn = new SqlConnection(string.Format(connString, database));
            conn.Open();
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@motherfirst", motherFirstName);
            cmd.Parameters.AddWithValue("@motherlast", motherLastName);
            cmd.Parameters.AddWithValue("@fatherfirst", fatherFirstName);
            cmd.Parameters.AddWithValue("@fatherlast", fatherLastName);
            var dt = new DataTable();
            var adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
