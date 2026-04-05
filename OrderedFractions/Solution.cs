using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedFractions
{
    internal class Solution
    {
        public int Solve()
        {
            int maxn = 0;
            int maxd = 1;

            for (int j = 2; j <= 1000000; j++)
            {
                int i = ((3 * j) - 1) / 7;

                if (GCD(i, j) != 1)
                    continue;

                if ((long)i * maxd > (long)j * maxn)
                {
                    maxn = i;
                    maxd = j;
                }
            }

            return maxn;
        }

        public int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }
    }


}
