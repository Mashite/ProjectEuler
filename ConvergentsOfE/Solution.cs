using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConvergentsOfE
{
    internal class Solution
    {
        public BigInteger Solve()
        {
            List<int> constants = new List<int>();
            constants.Add(2);
            int k = 1;
            for (int i=1;i<100;i++)
            {
                if(i%3==2)
                {
                    constants.Add(k*2);
                    k++;
                }
                else
                    constants.Add(1);
            }
   
            BigInteger numerator = 1;
            BigInteger denominator = constants[99];
            for (int i = 98; i>=0; i--)
            {
                BigInteger temp = numerator;
                numerator = denominator;
                denominator = constants[i] * denominator + temp;              
            }

            return SumOfDigits(denominator);
        }

        public int SumOfDigits(BigInteger n)
        {
            int sum = 0;
            while(n>0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            return sum;
        }

    }
}
