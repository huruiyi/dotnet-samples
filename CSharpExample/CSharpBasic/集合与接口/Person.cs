namespace 集合与接口
{
    internal class Person
    {
        public string Name { get; set; }
        public char Sex { get; set; }

        public Person()
        {
        }

        public Person(string name, char sex)
        {
            Name = name;
            Sex = sex;
        }
    }
}