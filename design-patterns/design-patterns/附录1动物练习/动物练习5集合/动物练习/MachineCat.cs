namespace 动物练习
{
    internal class MachineCat : Cat, IChange
    {
        public MachineCat()
            : base()
        {
        }

        public MachineCat(string name)
            : base(name)
        {
        }

        public string ChangeThing(string thing)
        {
            return base.Shout() + " 我可变出：" + thing;
        }
    }
}