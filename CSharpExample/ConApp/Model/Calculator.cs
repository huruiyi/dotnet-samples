namespace ConApp.Model
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public static dynamic GetCalculator()
        {
            return new Calculator();
        }
    }
}