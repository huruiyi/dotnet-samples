namespace 动物练习
{
    internal class Dog : Animal
    {
        public Dog()
            : base()
        { }

        public Dog(string name)
            : base(name)
        { }

        public override string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
                result += "汪 ";

            return "我的名字叫" + name + " " + result;
        }
    }
}