namespace TisdagsÖvningCSDB
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class People
    {
        public string DatabaseName { get; set; } = "Humans";

        /// <summary>
        /// Skapar en person i databasen
        /// </summary>
        /// <param name="person"></param>
        public void Create(Person person)
        {
            var db = new SQLDatabase();
            try
            {
                var connString = string.Format(db.ConnectionString, DatabaseName);
                using (var cnn = new SqlConnection(connString))
                {
                    cnn.Open();
                    var sql = "INSERT INTO People (LastName, FirstName, Address, City, Age) VALUES(@LastName, @FirstName, @Address, @City, @Age)";
                    using (var command = new SqlCommand(sql, cnn))
                    {
                        command.Parameters.AddWithValue("@LastName", person.LastName);
                        command.Parameters.AddWithValue("@FirstName", person.FirstName);
                        command.Parameters.AddWithValue("@Address", person.Address);
                        command.Parameters.AddWithValue("@City", person.City);
                        command.Parameters.AddWithValue("@Age", person.Age);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Läser en person ur databasen
        /// </summary>
        /// <param name="id">Id på personen</param>
        /// <returns>Ett Person objekt</returns>
        public Person Read(int id)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            var row = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @id", ("@id", id.ToString()));
            if (row.Rows.Count == 0)
                return null;

            return GetPersonObject(row.Rows[0]);
        }

        /// <summary>
        /// Hämtar en person ur databasen
        /// (att skicka in en person för att söka en person är lite som att refresha Personobjektet från databasen)
        /// </summary>
        /// <param name="person">Person objekt vi söker</param>
        /// <returns>Person objekt</returns>
        public Person Read(Person person)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            var row = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @id", ("@id", person.Id.ToString()));
            if (row.Rows.Count == 0)
                return null;

            return GetPersonObject(row.Rows[0]);
        }

        /// <summary>
        /// Söker person baserat på namn
        /// </summary>
        /// <param name="name">Namn på personen</param>
        /// <returns>Person objekt</returns>
        public Person Read(string name)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };

            DataTable dt;
            if (name.Contains(" "))
            {
                var names = name.Split(' ');
                dt = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @fname AND lastName LIKE @lname",
                    ("@fname", names[0]),
                    ("@lname", names[^1])
                    );
            }
            else
            {
                dt = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @name OR lastName LIKE @name ", ("@name", name));
            }

            if (dt.Rows.Count == 0)
                return null;

            return GetPersonObject(dt.Rows[0]);
        }

        /// <summary>
        /// Omvandlar från en DataRow till Person
        /// </summary>
        /// <param name="row">DataRow från databasen</param>
        /// <returns>PersonObjekt</returns>
        private static Person GetPersonObject(DataRow row)
        {
            return new Person
            {
                Address = row["Address"].ToString(),
                Age = (int)row["age"],
                City = row["city"].ToString(),
                FirstName = row["firstName"].ToString(),
                LastName = row["lastName"].ToString(),
                Id = (int)row["Id"]
            };
        }

        /// <summary>
        /// Uppdaterar person i databasen baserat på PersonObjekt
        /// </summary>
        /// <param name="person">PersonObjekt</param>
        public void Update(Person person)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            db.ExecuteSQL(@"
                Update People SET
                lastName=@LastName, FirstName=@FirstName, Address=@Address, City=@City, Age=@Age
                WHERE Id = @id",
                ("@LastName", person.LastName),
                ("@FirstName", person.FirstName),
                ("@Address", person.Address),
                ("@City", person.City),
                ("@Age", person.Age.ToString()),
                ("@Id", person.Id.ToString())
                );
        }

        /// <summary>
        /// Raderar person ur databasen, baserat på personobjektets Id
        /// </summary>
        /// <param name="person">Personobjekt</param>
        public void Delete(Person person)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            db.ExecuteSQL("DELETE FROM People Where Id=@id",
                         ("@Id", person.Id.ToString())
                         );
        }

        /// <summary>
        /// Raderar person ur databasen, baserat på namn
        /// </summary>
        /// <param name="person">Personens namn</param>
        public void Delete(string name)
        {
            var person = Read(name);
            if (person != null) Delete(person);
        }

        /// <summary>
        /// Hämtar en lista på personer
        /// </summary>
        /// <param name="filter">exempel name LIKE %Pekka%</param>
        /// <param name="orderBy"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public List<Person> List(string filter = "", string orderBy = "lastName", int max = 10)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            var sql = "SELECT";
            if (max > 0) sql += " TOP " + max.ToString();
            sql += "* From People";
            if (filter != "") sql += "WHERE " + filter;
            if (orderBy != "") sql += " ORDER BY " + orderBy;
            var data = db.GetDataTable(sql);
            var lst = new List<Person>();
            foreach (DataRow row in data.Rows)
            {
                lst.Add(GetPersonObject(row));
            }
            return lst;
        }
    }
}