
using System.Numerics;

namespace Digit1000FibonacciNumber
{
    public class Solution
    {
        public int Solve()
        {
            BigInteger f1 = 1;
            BigInteger f2 = 1;
            BigInteger f3=0;
            int i = 2;
            while(f3.ToString().Length<1000)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
                i++;
            }
            return i;
        }
        public long Fibonacci(long f)
        {
            if (f == 1 || f==2)
                return 1;
            return Fibonacci(f-1) + Fibonacci(f - 2);
        }
    }
}
