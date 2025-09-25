using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangularPentagonalHexagonal
{
    internal class Solution
    {
        public long Solve()
        {
            long n = 144;
            while (true)
            {
                long h = n * (2 * n - 1);
                if (IsPentagonal(h))
                    return h;                            
                n++;
            }
        }       

        public bool IsPentagonal(long x)
        {
            long check = 1 + (24 * x);
            long sqrt=(long)Math.Sqrt ( check );

            if (sqrt * sqrt == check)
                return (1 + sqrt) % 6 == 0;
            return false;
        }

        public bool IsTriangeular(long x)
        {
            long check = 1 + (8 * x);
            long sqrt = (long)Math.Sqrt(check);

            if (sqrt * sqrt == check)
            {
                long n = (-1 + sqrt) / 2;
                return n > 0;
            }
            return false;
        }

        public bool IsHexagonal(long x)
        {

            long check=1 +(8*x);
            long sqrt=(long)Math.Sqrt( check );

            if (sqrt * sqrt == check)
            {
                long n = (1 + sqrt) / 4;
                return n > 0;
            }
            return false;
        }
    }
}
