using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SingularIntegerRightTriangles
{
    internal class Solution
    {
        public int Solve()
        {
             int limit = 1500000;
    int[] counts = new int[limit + 1];

    for (int m = 2; 2 * m * (m + 1) <= limit; m++)
    {
        for (int n = 1; n < m; n++)
        {
            if (((m - n) % 2 == 0) || GCD(m, n) != 1)
                continue;

            int a = m * m - n * n;
            int b = 2 * m * n;
            int c = m * m + n * n;
            int p = a + b + c;

            for (int k = p; k <= limit; k += p)
                counts[k]++;
        }
    }

    int answer = 0;
    for (int i = 0; i <= limit; i++)
    {
        if (counts[i] == 1)
            answer++;
    }

    return answer;

        }

        public int GCD(int m, int n)
        {
            if (n == 0) return m;
            return GCD(n, m % n);
        }

    }
}
