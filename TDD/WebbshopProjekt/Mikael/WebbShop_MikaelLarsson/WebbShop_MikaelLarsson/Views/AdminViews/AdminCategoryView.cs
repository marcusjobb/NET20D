namespace WebbShop_MikaelLarsson.Views.Admin
{
    using System;

    /// <summary>
    /// Klass för att skriva ut category-relaterad text från adminmenyn
    /// </summary>
   internal static class AdminCategoryView
    {
        /// <summary>
        /// Text för att lägga till ny kategori
        /// </summary>
        internal static void AddCategory()
        {
            Console.WriteLine("\nADD A NEW CATEGORY");
            Console.Write("Enter name of the new category: ");
        }

        /// <summary>
        /// Text för att välja kategori.
        /// </summary>
        internal static void ChooseCategory()
        {
            Console.Write("Enter ID number of category of choice:  ");
        }

        /// <summary>
        /// Text för att updatera category.
        /// </summary>
        internal static void UpdateCategory()
        {
            Console.WriteLine("\nUPDATE CATEGORY");
            Console.Write("Enter new name of the category: ");
        }
    }
}
