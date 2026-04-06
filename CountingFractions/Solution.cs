using System;
using System.Collections.Generic;
using System.Text;

namespace CountingFractions
{
        internal class Solution
        {
            public long Solve()
            {
                int d = 1000000;
                long count = 0;

                //for(int i=2;i<=d;i++)
                //{
                //    for(int j=1;j<i;j++)
                //    {
                //        if (GCD(i, j) == 1)
                //        {
                //           // Console.WriteLine($"{j}/{i}");
                //            count++;
                //        }
                //    }
                //}

                for(int i = 2;i <= d; i++)
                {
                    count += Totient(i);
                }


                return count;
            }

            public int GCD(int a, int b)
            {
                if (b == 0) return a;
                return GCD(b, a % b);
            }

            int Totient(int n)
            {
                int result = n;
                int temp = n;

                for (int p = 2; p * p <= temp; p++)
                {
                    if (temp % p == 0)
                    {
                        while (temp % p == 0)
                            temp /= p;

                        result -= result / p;
                    }
                }

                if (temp > 1)
                    result -= result / temp;

                return result;
            }
        }
}
