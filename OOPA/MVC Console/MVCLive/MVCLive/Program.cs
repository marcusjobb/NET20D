namespace MVCLive
{
    using MVCLive.Controllers;

    internal static class Program
    {
        private static void Main()
        {
            /*
             *  Models - POCO - Plain Old Class Object
             *  View - all output
             *  ViewModel - förenklad Model som innehåller bara nödvändig information
             *  Controller = all logik
             */

            /* model: BookId, Title, Author { Id, Name}, Category {Id, Name}
             *          |       |                   |                   |
             *          |       |                   |                   |
             * ViewModel: Id,  Title, AuthorID,   Author,           Category
             */

            var home = new Home();
            home.Start();
        }
    }
}