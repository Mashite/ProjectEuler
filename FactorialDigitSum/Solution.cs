using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FactorialDigitSum
{
    public class Solution
    {
        public BigInteger Solve(BigInteger n)
        {
            if (n == 1 ) return 1;   
            return n* Solve(n-1);
        }
    }
}
