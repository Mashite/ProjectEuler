using System;
using System.Collections.Generic;
using System.Text;

namespace CountingSummations
{
    internal class Soluton
    {
        private int[,] memo = new int[11, 10];

        public int Solve()
        {
            return Count(10, 9);
        }

        public int Count(int n, int m)
        {
            Console.WriteLine($"({n}, {m})");
            if (n == 0) { Console.WriteLine($"Count 1"); return 1; }
            if (n < 0 || m == 0) return 0;

            if (memo[n, m] != 0)
                return memo[n, m];

            memo[n, m] = Count(n - m, m) + Count(n, m - 1);

            return memo[n, m];
        }
    }
}
