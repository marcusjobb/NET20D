namespace TisdagsÖvningCSDB
{
    internal static class Övning8
    {
        internal static void Run()
        {
            var db = new SQLDatabase
            {
                DatabaseName = "Humans"
            };
            db.ExecuteSQL(@"
                insert into People (firstname, lastname, address, city) values ('Venita', 'Bolsteridge', '43488 Arrowood Court', 'Changmao');
                insert into People (firstname, lastname, address, city) values ('Burk', 'Kinlock', '7038 Eastwood Alley', 'Ti-n-Essako');
                insert into People (firstname, lastname, address, city) values ('Nert', 'Puttock', '7058 Coolidge Road', 'Rzgów');
                insert into People (firstname, lastname, address, city) values ('Filippa', 'Furmedge', '29782 Sutteridge Hill', 'Lyaskovets');
                insert into People (firstname, lastname, address, city) values ('Standford', 'Luna', '1189 Stone Corner Street', 'Outapi');
                insert into People (firstname, lastname, address, city) values ('Claudianus', 'Spirit', '87 Union Way', 'Kanluran');
                insert into People (firstname, lastname, address, city) values ('Noell', 'Knappitt', '48 Pearson Alley', 'Panzhuang');
                insert into People (firstname, lastname, address, city) values ('Appolonia', 'Cheine', '43106 Village Green Plaza', 'Ordino');
                insert into People (firstname, lastname, address, city) values ('Phillip', 'Hounsom', '00375 Lukken Trail', 'Munturkaju');
                insert into People (firstname, lastname, address, city) values ('Georgy', 'Fulstow', '7358 Lerdahl Point', 'Évreux');
                insert into People (firstname, lastname, address, city) values ('Enriqueta', 'Oleszczak', '33 Menomonie Plaza', 'Paris La Défense');
                insert into People (firstname, lastname, address, city) values ('Alexine', 'Venmore', '517 Forest Drive', 'Nanyanchuan');
                insert into People (firstname, lastname, address, city) values ('Rhett', 'Kitchenman', '83242 Service Hill', 'Magoúla');
                insert into People (firstname, lastname, address, city) values ('Rodie', 'Ginity', '711 Sycamore Way', 'Czerwonak');
                insert into People (firstname, lastname, address, city) values ('Morly', 'Hepher', '8 Talmadge Center', 'Qinlan');
                insert into People (firstname, lastname, address, city) values ('Chrissy', 'Thies', '191 Village Hill', 'Iwata');
                insert into People (firstname, lastname, address, city) values ('Jaquith', 'Spalls', '610 Spaight Place', 'Sondo');
                insert into People (firstname, lastname, address, city) values ('Briny', 'Geall', '95160 Sycamore Junction', 'Liuji');
                insert into People (firstname, lastname, address, city) values ('Alva', 'Maha', '51078 Commercial Center', 'Tampa');
                insert into People (firstname, lastname, address, city) values ('Kaylil', 'Daouse', '6 Fairview Road', 'Maguan');
                insert into People (firstname, lastname, address, city) values ('Ethelbert', 'Crome', '79 Prairieview Trail', 'Voskopojë');
                insert into People (firstname, lastname, address, city) values ('Chris', 'Lorryman', '11529 Anhalt Court', 'Bastia');
                UPDATE People SET age = ABS(CHECKSUM(NEWID()) % 115);");

        }
    }
}