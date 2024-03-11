namespace ConApp.Model
{
    public class ReflectionClass5
    {
        private int x;
        private int y;

        public ReflectionClass5(int i)
        {
            x = y + i;
        }

        public ReflectionClass5(int i, int j)
        {
            x = i;
            y = j;
        }

        public int sum()
        {
            return x + y;
        }
    }
}