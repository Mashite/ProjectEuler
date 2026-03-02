using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DiophantineEquation
{
    internal class Solution
    {
        public int Solve()
        {
            BigInteger biggest = 0;
            int bigD = 0;
            for (int D = 2; D <= 1000; D++)
            {
                if (IsSquare(D)) continue;

                List<BigInteger> a = GetPeriod(D);
                BigInteger p_nm1 = 1, p_nm2 = 0;
                BigInteger q_nm1 = 0, q_nm2 = 1;
                BigInteger a0 = a[0];
      
                a.RemoveAt(0);
                for (int n = 0; ; n++)
                {
                    BigInteger an = n == 0 ? a0 : a[(n - 1) % a.Count];
                    BigInteger p_nm = an * p_nm1 + p_nm2;
                    BigInteger q_nm = an * q_nm1 + q_nm2;

                    if (p_nm * p_nm - D * q_nm * q_nm == 1)
                    {
                        if (p_nm > biggest)
                        {
                            biggest = p_nm;
                            bigD = D;
                        }
                        break;
                    }
                    p_nm2 = p_nm1;
                    q_nm2 = q_nm1;
                    p_nm1 = p_nm;
                    q_nm1 = q_nm;

                }

            }
            return bigD;

        }

        public bool IsSquare(int n)
        {
            int root = (int)Math.Sqrt(n);
            return root * root == n;
        }



        public List<BigInteger> GetPeriod(int n)
        {
            List<BigInteger> periods = new List<BigInteger>();
            int a0 = (int)Math.Sqrt(n);
            periods.Add(a0);
            BigInteger ak = a0;
            BigInteger dk = 1;
            BigInteger mk = 0;
            while ((a0 * 2) != ak)
            {
                mk = dk * ak - mk;
                dk = (n - mk * mk) / dk;
                ak = (a0 + mk) / dk;
                periods.Add(ak);
            }
            return periods;
        }
    }
}
