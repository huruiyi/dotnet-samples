namespace AnimalLibrary
{
    public class Pig : Animal
    {
        public Pig(string name)
            : base(name)
        {
        }

        protected override string getShoutSound()
        {
            return "猪叫";
        }
    }
}