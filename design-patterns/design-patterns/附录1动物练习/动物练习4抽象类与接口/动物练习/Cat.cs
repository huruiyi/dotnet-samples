namespace 动物练习
{
    internal class Cat : Animal
    {
        public Cat()
            : base()
        { }

        public Cat(string name) : base(name)
        {
        }

        protected override string getShoutSound()
        {
            return "喵";
        }
    }
}