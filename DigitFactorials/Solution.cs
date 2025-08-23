using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFactorials
{
    internal class Solution
    {
        public int Solve()
        {
            List<int> facts = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                facts.Add(Factorial(i));
            }

            Stopwatch stopwatch = new Stopwatch();

            // Start measuring
            stopwatch.Start();
            int sum = 0;
            for (int i = 20; i < 100000 ; i++)
            {
                if (i == FactorialDigitSum(i))
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }
            stopwatch.Stop();

            // Show elapsed time
            Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Elapsed Ticks: {stopwatch.ElapsedTicks}");
            Console.WriteLine($"Elapsed Time (more precise): {stopwatch.Elapsed}");
            return sum;
        }

        private int Factorial(int n)
        {
            if(n==1 || n==0)
                return 1;
            if(n == 2)
                return 2;
            return n * Factorial(n - 1);
        }  
        
        private int FactorialDigitSum(int n)
        {
            int num = n;
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                int fact= Factorial(digit);
                if (fact > num)
                    return 0; // If factorial of digit is greater than n, it cannot be a valid sum
                sum += fact;
                n /= 10;
            }
            return sum;
        }
    }
}
