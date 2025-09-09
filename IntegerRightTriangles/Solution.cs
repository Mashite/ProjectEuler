using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerRightTriangles
{
    internal class Solution
    {
        int max = 0;
        int num = 1;
        public int Solve()
        {
            for(int i = 1;i<=1000;i++)
            {
                int res=Check(i);
                if (res > max)
                {
                    max = res;
                    num = i;
                }
            }
            return num;
        }

        public int Check(int p)
        {
            int count = 0;
            for(int c= (p/2);c>p/4;c-- )
            {
                for(int a=c-1;a>c/2;a--)
                {
                    int b = p-(c+a);

                    if (((a * a) + (b * b)) == c * c)
                       count++;

                }
            }
            return count;
        }
    }
}
