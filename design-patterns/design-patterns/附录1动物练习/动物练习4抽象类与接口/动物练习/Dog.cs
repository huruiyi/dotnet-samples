namespace 动物练习
{
    internal class Dog : Animal
    {
        public Dog()
            : base()
        { }

        public Dog(string name) : base(name)
        {
        }

        protected override string getShoutSound()
        {
            return "汪";
        }
    }
}