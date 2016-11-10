using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于多态
{
    class Studnet : Person, ISpeak
    {
        public Studnet()
        {

        }
        private string _Course;
        public string Course
        {
            get { return _Course; }
            set { _Course = value; }
        }
        public Studnet(string name, string sex, int age, string course)
            : base(name, sex, age)
        {
            Course = course;
        }

        public void ShowStuInfo()
        {
            Console.WriteLine("(student)我叫：" + Name + "性别：" + Sex + "，爱好学科：" + Course);
        }

        public void Speak()
        {
            Console.WriteLine("学生会说话");
        }






        private string AA;
        public string _AA
        {
            get
            {
                return AA;
            }
            set
            {
                AA = value;
            }
        }
    }
}
