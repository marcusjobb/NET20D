namespace EntityFramework01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EntityFramework01.Database;
    using EntityFramework01.Models;

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Filmdatabas())
            {
                db.Filmer.Add(new Film { TitelEng = "The Crow 2", TitelSwe="Kråkan 2", Betyg = 7 });

                //--------------------------------------
                // Create
                //--------------------------------------
                //db.Filmer.Add(new Film { TitelEng = "Elf", Betyg = 0 });


                //--------------------------------------
                // Create Many
                //--------------------------------------
                //db.AddRange(new Film[]
                //    {
                //       new Film { TitelEng = "Back to the future", Betyg = 10 },
                //       new Film { TitelEng = "Back to the future 2", Betyg = 9 },
                //       new Film { TitelEng = "Back to the future 3", Betyg = 10 },
                //       new Film { TitelEng = "Karate Kid", Betyg = 10 },
                //       new Film { TitelEng = "Karate Kid II", Betyg = 9 },
                //       new Film { TitelEng = "Karate Kid III", Betyg = 9 },
                //    }
                //);


                //--------------------------------------
                // Search without Linq
                //--------------------------------------
                //Film elf=null;
                //foreach (var f in db.Filmer)
                //{
                //    if (f.TitelEng=="Elf")
                //    {
                //        elf = f;
                //        break;
                //    }
                //}
                //--------------------------------------
                // search with linq and Update
                //--------------------------------------
                //var elf = db.Filmer.FirstOrDefault(f => f.TitelEng=="Elf");
                //if (elf != null) elf.Betyg = 1;
                //db.Update(elf);

                //--------------------------------------
                // Delete movie
                //--------------------------------------
                //var movie = db.Filmer.FirstOrDefault(f => f.TitelEng.StartsWith("F"));
                //db.Filmer.Remove(movie);

                //--------------------------------------
                // List movies
                //--------------------------------------
                foreach (var film in 
                    db.Filmer  //                     SELECT * FROM Filmer
                    .OrderByDescending(f=>f.Betyg) // Order By Betyg Desc,
                    .ThenBy(f=>f.TitelEng)         // TitelEng
                    .Take(5)                       // Top 5 (lite omvänt men OK) 
                    )
                {
                    //Console.WriteLine($"{film.TitelEng} {film.Betyg}");
                    Console.WriteLine(film);
                }

                //--------------------------------------
                // Always save changes when you're done
                //--------------------------------------
                db.SaveChanges();
            }

            


        }
    }
}
