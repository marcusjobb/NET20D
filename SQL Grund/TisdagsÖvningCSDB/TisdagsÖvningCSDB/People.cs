namespace TisdagsÖvningCSDB
{
    using System.Collections.Generic;
    using System.Data;

    public class People
    {
        public string DatabaseName { get; set; } = "Humans";

        public void Create(Person person)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };
            db.ExecuteSQL(@"
                INSERT INTO People (LastName, FirstName, Address, City, Age)
                VALUES(@LastName, @FirstName, @Address, @City, @Age)",
                ("@LastName", person.LastName),
                ("@FirstName", person.FirstName),
                ("@Address", person.Address),
                ("@City", person.City),
                ("@Age", person.Age.ToString())
                );
        }

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

        public Person Read(string name)
        {
            var db = new SQLDatabase
            {
                DatabaseName = DatabaseName
            };

            DataTable row;
            if (name.Contains(" "))
            {
                var names = name.Split(' ');
                row = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @fname AND lastName LIKE @lname",
                    ("@fname", names[0]),
                    ("@lname", names[^1])
                    );
            }
            else
            {
                row = db.GetDataTable("SELECT TOP 1 * from People Where firstName LIKE @name", ("@name", name));
                if (row.Rows.Count == 0)
                    row = db.GetDataTable("SELECT TOP 1 * from People Where lastName LIKE @name", ("@name", name));
            }

            if (row.Rows.Count == 0)
                return null;

            return GetPersonObject(row.Rows[0]);
        }

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

        public void Delete(Person person)
        {
            SQLDatabase db = null;
            db.ExecuteSQL("DELETE FROM People Where Id=@id",
                         ("@Id", person.Id.ToString())
                         );
        }

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