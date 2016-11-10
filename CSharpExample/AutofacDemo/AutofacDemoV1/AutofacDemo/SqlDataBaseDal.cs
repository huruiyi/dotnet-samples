using System;

namespace AutofacDemo
{
    public class SqlDataBaseDal : IDataBaseDal
    {
        public string Name
        {
            get { return "SQL Database"; }
        }

        public void Select(string commandText)
        {
            Console.WriteLine(commandText + " Select " + Name);
        }

        public void Delete(string commandText)
        {
            Console.WriteLine(commandText + " Delete " + Name);
        }

        public void Update(string commandText)
        {
            Console.WriteLine(commandText + " Update " + Name);
        }

        public void Insert(string commandText)
        {
            Console.WriteLine(commandText + " Insert " + Name);
        }
    }
}