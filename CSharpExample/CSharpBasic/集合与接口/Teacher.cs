using System;

namespace 集合与接口
{
    internal class Teacher : Person
    {
        private int teacAge;

        public int TeacAge
        {
            get { return teacAge; }
            set { teacAge = value; }
        }

        public Teacher()
        {
        }

        public Teacher(string name, char sex, int teacage)
            : base(name, sex)
        {
            this.teacAge = teacage;
        }

        public void Show()
        {
            Console.WriteLine("我叫{0}，性别{1}，已教学{2}年", Name, Sex, teacAge); ;
        }
    }
}