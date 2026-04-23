using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CountingFractionsInARange
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;

            for (int i = 5; i <= 12000; i++)
            {
                for (int j = i / 3 + 1; j <= i / 2; j++)
                {
                    if(GCD(i, j) == 1)
                    {
                        count++;
                        //Console.WriteLine($"{j}/{i}");
                    }
                }
            }
            return count;
        }

        public int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }
    }
}
