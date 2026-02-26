using System;
using System.Collections.Generic;
using System.Text;

namespace OddPeriodSquareRoots
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;
            for (int n=1;n<=10000;n++)
            {
                if(IsSquare(n))continue;
                if(GetPeriod(n)%2 !=0)
                {
                    count++;
                }
            }
            return count;
        }


        public bool IsSquare(int n)
        {
            int root = (int)Math.Sqrt(n);
            return root * root == n;
        }

        public int GetPeriod(int n)
        {
            int period = 0;
            int a0=(int)Math.Sqrt(n);

            int ak=0;
            int dk=1;
            int mk = 0;
            while((a0*2)!=ak)
            {
                mk=dk*ak-mk;
                dk=(n-mk*mk)/dk;
                ak=(a0+mk)/dk;
                period++;
            }
            return period;
        }

        //public int Solve()
        //{
        //    int count = 0;
        //    for (int n = 1; n <= 10000; n++)
        //    {
        //        if (IsSquare(n))
        //            continue;
        //        if (GetPeriod(n) % 2 == 1)
        //            count++;
        //    }
        //    return count;
        //}
        //private bool IsSquare(int n)
        //{
        //    int root = (int)Math.Sqrt(n);
        //    return root * root == n;
        //}
        //private int GetPeriod(int n)
        //{
        //    int m = 0;
        //    int d = 1;
        //    int a0 = (int)Math.Sqrt(n);
        //    int a = a0;
        //    int period = 0;
        //    while (a != 2 * a0)
        //    {
        //        m = d * a - m;
        //        d = (n - m * m) / d;
        //        a = (a0 + m) / d;
        //        period++;
        //    }
        //    return period;
        //}
    }
}
