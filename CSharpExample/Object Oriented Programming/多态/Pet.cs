namespace 多态
{
    internal abstract class Pet
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Love { get; set; }

        public abstract void Print();

        public abstract void ToHospital();
    }
}