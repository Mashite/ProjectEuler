using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentagonNumbers
{
    internal class Solution
    {
        public int Solve()
        {
            List<int> pentagonals = new List<int>();
            pentagonals.Add(0);
            pentagonals.Add(1);
            pentagonals.Add(5);
            int max = 5;
            int i = 3, index = 4;
            int res = Pentagonal(i);
            pentagonals.Add(res);
            while (true)
            {
                while (res < pentagonals[i] * 2)
                {
                    res = Pentagonal(index);
                    index++;
                    pentagonals.Add(res);
                }

                for (int j = 1; j < i; j++)
                {
                    if (pentagonals.Contains(pentagonals[i] + pentagonals[j]) && pentagonals.Contains(Math.Abs(pentagonals[i] - pentagonals[j])))
                    {
                        return Math.Abs(pentagonals[i] - pentagonals[j]);
                    }
                }
                i++;
            }
        }

        public int Pentagonal(int n)
        {
            return n * (3 * n - 1) / 2;
        }
    }
}
