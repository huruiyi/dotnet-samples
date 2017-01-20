namespace ConApp.Model
{
    public class PointRef  // <= Renamed and retyped.
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}