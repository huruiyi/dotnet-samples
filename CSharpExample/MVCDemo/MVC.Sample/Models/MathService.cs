namespace MVC.Sample.Models
{
    public class MathService : IMathService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}