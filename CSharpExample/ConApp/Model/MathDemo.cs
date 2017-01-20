namespace ConApp.Model
{
    public class MathDemo
    {
        public int Value;

        public int GetSquare()
        {
            return Value * Value;
        }

        public static int GetSquareOf(int x)
        {
            return x * x;
        }

        public static double GetPi()
        {
            return 3.14159;
        }
    }
}