using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SquareRootDigitalExpansion
{
    internal class Solution
    {
        public int Solve()
        {
            int sum = 0;

            for (int i = 1; i <= 100; i++)
            {
                int r = (int)Math.Sqrt(i);

                if (r * r != i)
                {
                    sum += GetDigits(i);
                }
            }

            return sum;
        }

        private int GetDigits(int n)
        {
            BigInteger scaled = n * BigInteger.Pow(10, 200);

            string root = NewtonBabylonian(scaled).ToString();

            string digits = root.Substring(0, 100);

            return digits.Sum(c => c - '0');
        }

        private BigInteger NewtonBabylonian(BigInteger n)
        {
            if (n == 0)
                return 0;

            BigInteger x = n;
            BigInteger y = (x + 1) / 2;

            while (y < x)
            {
                x = y;
                y = (x + n / x) / 2;
            }

            return x;
        }

    }
}
