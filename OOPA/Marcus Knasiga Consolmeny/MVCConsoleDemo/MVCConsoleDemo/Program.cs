namespace MVCConsoleDemo
{
    internal static class Program
    {
        private static void Main()
        {
            var start = new Controllers.Start();
            start.PrepareGame();
            start.ShowMenu();

            var con = new Controllers.HomeMenu();
        }
    }
}