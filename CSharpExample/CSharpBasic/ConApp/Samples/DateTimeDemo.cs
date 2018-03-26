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
        }
    }
}