using System;
using System.Diagnostics;
using System.Text;

namespace FileWatcher
{
    public class EventsLog
    {
        public EventsLog()
        {
            EventLog sample = new EventLog();

            EventLogEntryCollection myCollection = sample.Entries;
            foreach (EventLogEntry ele in myCollection)
            {
                EventLogTraceListener e = new EventLogTraceListener();

                Console.WriteLine("Category:" + ele.Category);
                Console.WriteLine("CategoryNumber:" + ele.CategoryNumber);
                Console.WriteLine("Data:" + Encoding.Default.GetString(ele.Data));
                Console.WriteLine("EntryType:" + ele.EntryType);
                Console.WriteLine("Message:" + ele.Message);

                Console.WriteLine("Source:" + ele.Source);
                Console.WriteLine("InstanceId:" + ele.InstanceId);
                Console.WriteLine("MachineName:" + ele.MachineName);

                Console.WriteLine("Source:" + ele.Source);
                Console.WriteLine("TimeGenerated:" + ele.TimeGenerated);
                Console.WriteLine("UserName:" + ele.UserName);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}