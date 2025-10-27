using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricSelections
{
    internal class Solution
    {
        public long Solve()
        {
            int count = 0;
            for(int i=2;i<=100;i++)
            {
                long res = 0;
                int j = 1;
                while(res<1000000 && i>=j)
                {
                    long mul = 1;
                    for(int m=i;m>i-j;m--)
                    {
                        mul *= m;
                    }
                    res = mul / Fact(j);

                    if (res > 1000000)
                    {
                        if (i % 2 == 0)
                            count += (((i / 2) - j)*2)+1;
                        else 
                            count+= (((i+1) / 2) - j) * 2;
                    }

                    j++;

                }
            }
            return count;
        }

        public long Fact(int n) 
        {
            if (n == 0) return 1;
            if (n == 1)
                return 1;
            return n * Fact(n - 1);
        }


    }
}
