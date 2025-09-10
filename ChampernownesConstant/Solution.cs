using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampernownesConstant
{
    internal class Solution
    {
        const int LIMIT = 1_000_000;
        public long Solve()
        {
            long mul=1;
            int n = 0;
            int pos = 0;
            int nextTarget = 1;

            while (pos<=LIMIT)
            {
                n++;
                
                string nStr = n.ToString();

                foreach(char c in nStr)
                {
                    pos++;
                    if (pos == nextTarget)
                    {
                        mul *= (c - '0');
                        nextTarget *= 10;
                    }
                    if (pos == LIMIT) break;
                }
             
            }
            return mul;
        }
    }
}
