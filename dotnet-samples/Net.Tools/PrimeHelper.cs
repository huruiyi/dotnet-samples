using System;
using System.Collections;

namespace Net.Tools
{
    internal class PrimeHelper
    {
        private long min;
        private long max;

        public PrimeHelper() : this(2, 100)
        {
        }

        public PrimeHelper(long minimum, long maximum)
        {
            if (min < 2)
                min = 2;
            else
                min = minimum;
            max = maximum;
        }

        public IEnumerator GetEnumerator()
        {
            for (long i = min; i <= max; i++)
            {
                bool isPrime = true;
                for (long j = 2; j <= (long)Math.Floor(Math.Sqrt(i)); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    yield return i;
            }
        }

        public static void IsPrime()
        {
            for (int num = 0; num < 2000; num++)
            {
                for (int i = 2; i <= (int)Math.Sqrt(num); i++)
                {
                    if (num % i != 0)
                    {
                        Console.WriteLine("{0}是素数", num);
                    }
                }
            }
        }
    }
}