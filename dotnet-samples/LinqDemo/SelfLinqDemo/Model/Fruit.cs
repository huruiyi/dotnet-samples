namespace SelfLinqDemo.Model
{
    public class Fruit
    {
        public Fruit(int lifearg, string namearg, string colorarg)
        {
            Name = namearg;
            Color = colorarg;
            ShelfLife = lifearg;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int ShelfLife { get; set; }
    }
}