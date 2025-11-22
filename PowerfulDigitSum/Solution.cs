using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulDigitSum
{
    internal class Solution
    {
        public int Solve()
        {
            int max = 0;
            for(int i=2;i<100;i++)
            {
                for(int j=1;j<100;j++)
                {
                    BigInteger pow= BigInteger.Pow(i,j);
                    int sum= pow.ToString()
                                 .Select(n => n-'0')
                                 .Sum();
                    if (sum>=max)
                    {
                        max = sum;
                        Console.WriteLine($"{i} {j} {pow} {sum}");
                    }
                }
            }
                return max;
        }
    }
}
