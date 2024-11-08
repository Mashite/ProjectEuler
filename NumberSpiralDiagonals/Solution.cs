using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSpiralDiagonals
{
    public class Solution
    {
        public int Solve()
        {
            int count = 1;
            int sum = 1;
            for (int i = 2;i<=1001;i=i+2)
            {
                for(int j=1;j<=4;j++)
                {
                    count += i;
                    sum += count;
                }                 
            }
            return sum;
        }
    }
}
