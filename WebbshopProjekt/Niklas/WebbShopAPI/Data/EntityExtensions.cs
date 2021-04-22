using Microsoft.EntityFrameworkCore;

namespace WebbShopAPI.Data
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Removes the table content if needed.
        /// </summary>
        /// <typeparam name="T">Set name.</typeparam>
        /// <param name="dbSet">DB-set.</param>
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
