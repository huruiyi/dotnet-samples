using System;

namespace PredicateDelegate
{
    public class PersonA
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        public virtual void SayHi()
        {
            Console.WriteLine("大家好，我是{0}先生（女士）,今年{1}岁", Name, Age);
        }
    }
}