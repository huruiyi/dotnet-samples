using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new AdventureWorksTests().RunTests();
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------------");
                while (ex != null)
                {
                    Console.WriteLine($"{ex.GetType()}\n{ex.Message}\n------------------------");
                    ex = ex.InnerException;
                }
            }
            finally
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
