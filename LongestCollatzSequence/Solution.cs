using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCollatzSequence
{
    public class Solution
    {
        public long Solve()
        {
            long longest = 0;
            long index = 0;
            for(int i= 1;i<1000000;i++)
            {
                long count = CollatzSequence(i);

                if (count > longest)
                {
                    longest = count;
                    index = i;
                }

            }
            return index;
        }


        static long CollatzSequence(long n)
        {
            long result = n;
            if (result <= 1) return 1;
            if (result % 2 == 0) return 1 + CollatzSequence(result / 2);
            return 1 + CollatzSequence(3 * result + 1);
        }
    }
}
