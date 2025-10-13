using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfPowers
{
    internal class Solution
    {
        public int Solve()
        {
            double sum = 10405071317;
            for (int i = 11; i < 1000; i++)
            {
                double p = (i * i) % Math.Pow(10, 10);
                for (int j=3;j<=i;j++)
                {
                    p = (p * i) % Math.Pow(10, 10);
                }
                sum=  (sum+p)%Math.Pow(10, 10);
            }

            return sum;
        }
    }
}
