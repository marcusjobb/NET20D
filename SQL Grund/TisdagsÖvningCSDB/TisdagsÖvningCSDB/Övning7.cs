namespace TisdagsÖvningCSDB
{
    internal static class Övning7
    {
        internal static void Run()
        {
            var db = new SQLDatabase();
            db.DatabaseName = "Humans";
            db.ExecuteSQL("DROP TABLE People");
            db.DatabaseName = "Master";

            // -------------------------------------------------------------------------------
            // Specialfix - https://stackoverflow.com/a/20569152/15032536
            db.ExecuteSQL(" alter database [Humans] set single_user with rollback immediate");
            // -------------------------------------------------------------------------------

            db.ExecuteSQL("DROP Database Humans");

            db.ExecuteSQL("CREATE Database Humans");
            db.DatabaseName = "Humans";

            db.ExecuteSQL(@"USE [Humans]
                            CREATE TABLE [dbo].[People](
	                            [ID] [int] IDENTITY(1,1) NOT NULL,
	                            [lastName] [nvarchar](255) NULL,
	                            [firstName] [nvarchar](255) NULL,
	                            [address] [nvarchar](255) NULL,
	                            [city] [nvarchar](255) NULL,
	                            [shoeSize] [int] NULL
                            ) ON [PRIMARY]");

            db.ExecuteSQL(@"ALTER TABLE People ADD age int;");

            db.ExecuteSQL(@"ALTER TABLE People DROP COLUMN shoeSize;");
        }

        internal static void Run2()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Humans"
            };
            db.DropTable("People");
            db.DropDatabase("Humans");

            db.CreateDatabase("Humans", true);

            db.CreateTable("People", @"
                            ID int NOT NULL Identity (1,1),
                            lastName varchar(255),
                            firstName varchar(255),
                            address varchar(255),
                            city varchar(255),
                            shoeSize int
                            ");
            db.AlterTable("People", "ADD age int;");
            db.AlterTableDrop(field: "shoeSize", name: "People");
        }
    }
}