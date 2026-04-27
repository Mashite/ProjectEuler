using System;
using System.Collections.Generic;
using System.Text;

namespace CoinPartitions
{
    internal class Solution
    {
        int[] P= new int[1000000];

        public int Solve()
        {
            P[0] = 1;

            for (int i = 1; ; i++)
            {
                int res = Count(i);

                if (res == 0)
                {
                    return i;
                }
            }
        }


        public int Count(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            if (P[n] != 0) return P[n];

            int total = 0;

            for (int j = 1; ; j++)
            {
                int sign = (j % 2 == 1) ? 1 : -1;

                int g1 = j * (3 * j - 1) / 2;
                int g2 = j * (3 * j + 1) / 2;

                if (g1 > n) break;

                total += sign * Count(n - g1);

                if (g2 <= n)
                    total += sign * Count(n - g2);

                total %= 1000000;

                if (total < 0)
                    total += 1000000;
            }

            P[n] = total;
            return P[n];
        }
    }
}
