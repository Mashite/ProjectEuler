using System;
using System.Collections.Generic;
using System.Text;

namespace DigitFactorialChains
{
    internal class Solution
    {
        int[] factorials = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
        public int Solve()
        {
            int count = 0;
            for (int i = 69; i <= 1000000; i++)
            {
                HashSet<int> visited = new HashSet<int>();

                visited = Check(i, visited);
                if (visited.Count == 60)
                    count++;
            }
            return count;
        }

        public HashSet<int> Check(int n, HashSet<int> visited)
        {
            while (!visited.Contains(n))
            {
                visited.Add(n);
                n = Next(n);
            }
            return visited;
        }

        public int Next(int n)
        {

            if (n == 0) return 1;

            int sum = 0;

            while (n > 0)
            {
                sum += factorials[n % 10];
                n /= 10;
            }

            return sum;

        }
    }
}
