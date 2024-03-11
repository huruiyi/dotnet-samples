namespace ConApp.Model
{
    internal class VolatileDef
    {
        public volatile int i;

        public void Test(int _i)
        {
            i = _i;
        }
    }
}