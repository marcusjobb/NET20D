using System;
using System.Linq;
using EFLinq.Database;
using Microsoft.EntityFrameworkCore;

namespace EFLinq
{
    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        internal static void Main()
        {
            //Seeder.Seed();
            var qh = new QueryHandler();
            
            qh.ListAllPeopleAndAnimals();

            //qh.ListAllPetOwners();

            //qh.ListResidentsAt("Södra");

            qh.ListAllHouseWithPetType("Katt");

        }
    }
}
