using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitCancellingFractions
{
    public class Solution
    {
        public int Solve()
        {
            int numerator1;
            int numerator2;
            int denominator1;
            int denominator2;
            int ip = 1;
            int jp = 1;

            List<int> list = new List<int>();

            for (int i = 1; i < 10; i++)
            {
                for (int j = i+1; j < 10; j++)
                {
                    for (int k = i+1; k < 10; k++)
                    {
                        for (int l = 1; l < 10; l++)
                        {
                            if(i == j || k == l)
                            {
                                continue;
                            }
                            numerator1 = i * 10 + j;
                            denominator1 = k * 10 + l;
                            if ( numerator1<denominator1  && (i==k || j==k))
                            {
                                numerator1 = i * 10 + j;
                                denominator1 = k * 10 + l;
                                numerator2 = i;
                                denominator2 = l;
                                if (((decimal)numerator1 / denominator1) ==((decimal)numerator2 / denominator2))
                                {
                                    ip *= numerator2;
                                    jp *= denominator2;
                                }
                            }
                        }
                    }
                }
            }
            jp = jp / GCD(ip, jp);
            return jp;
        }
        public int GCD(int n, int m)
        {
            if (m == 0)
            {
                return n;
            }
            else
            {
                return GCD(m, n % m);
            }
        }
    }

   

}
