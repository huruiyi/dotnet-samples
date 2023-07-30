using System;

namespace ConApp
{
    public class DateTimeDemo
    {
        public static void Demo1()
        {
            DateTime dateToday = DateTime.Today;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(12);
            TimeSpan timeSpan = endTime.Subtract(startTime);
            Console.WriteLine(timeSpan.Days);

            long agoDateTicks = 636403425351377702;
            long dateNowTicks = DateTime.Now.Ticks;

            DateTime dateAgo = new DateTime(agoDateTicks);
            DateTime dateNow = new DateTime(dateNowTicks);
            Console.WriteLine(dateAgo.ToString());
            Console.WriteLine(dateNow.ToString());
        }
    }
}