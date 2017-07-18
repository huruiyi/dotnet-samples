using System;

namespace Singleton
{
    public class SinglePerson
    {
        private SinglePerson()
        {
        }

        private static SinglePerson _instance = null;

        public static SinglePerson GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SinglePerson();
                Console.WriteLine("创建成功" + DateTime.Now.ToString("yyyy-MM-dd:hhmmss"));
            }
            return _instance;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}