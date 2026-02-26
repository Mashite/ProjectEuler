using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PowerfulDigitCounts
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;

            for (int n = 1; n <= 9; n++)        
            {
                for (int k = 1; ; k++)
                {
                    BigInteger value = BigInteger.Pow(n, k);
                    int digits = value.ToString().Length;

                    if (digits == k)
                    {
                        Console.WriteLine($"{value}, {digits}, {k} ");
                        count++;
                    }

                    if (digits < k)
                        break;
                }
            }

            return count;
        }


        public int DigitsCount(int n)
        {
            int count = 1;
            while(n>=10)
            {
                count++;
                n /= 10;
            }
            return count;
        }
        
    }
}
