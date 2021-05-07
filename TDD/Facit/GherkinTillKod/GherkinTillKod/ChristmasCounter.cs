using System;

namespace GherkinTillKod
{
    public class ChristmasCounter
    {
        /// <summary>
        /// Count days till Christmas
        /// </summary>
        /// <param name="today"></param>
        /// <returns></returns>
        public static int DaysTillChristmas(DateTime today)
        {
            var christmas = new DateTime(DateTime.Now.Year, 12, 24);
            return today.DayOfYear > christmas.DayOfYear || today.Year > christmas.Year
                ? 0
                : (new DateTime(DateTime.Now.Year, 12, 24) - today).Days;
        }
    }
}