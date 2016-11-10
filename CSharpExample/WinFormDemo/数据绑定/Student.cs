namespace 数据绑定
{
    internal class Student
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Student(string name, string sex, int age, string address)
        {
            Name = name;
            Sex = sex;
            Age = age;
            Address = address;
        }
    }
}