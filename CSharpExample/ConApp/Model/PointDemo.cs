namespace ConApp.Model
{
    public struct PointDemo
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}