using System;
using System.Collections.Generic;
using System.Text;

namespace CountingSummations
{
    internal class Soluton
    {
        private int[,] memo = new int[101, 100];

        public int Solve()
        {
            return Count(100, 99);
        }

        public int Count(int n, int m)
        {
            if (n == 0) return 1;
            if (n < 0 || m == 0) return 0;

            if (memo[n, m] != 0)
                return memo[n, m];

            memo[n, m] = Count(n - m, m) + Count(n, m - 1);

            return memo[n, m];
        }
    }
}
