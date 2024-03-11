namespace 动物练习
{
    internal class Sheep : Animal
    {
        public Sheep(string name)
            : base(name)
        {
        }

        protected override string getShoutSound()
        {
            return "咩";
        }
    }
}