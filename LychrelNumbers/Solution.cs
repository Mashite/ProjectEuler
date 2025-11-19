using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LychrelNumbers
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;
            for(int i=12;i<10000;i++)
            {
                BigInteger n = i;
                bool isLychrel = true;
                for (int j = 0; j < 50; j++)
                {
                    
                    BigInteger reversed = BigIntegerReverse(n);
                    
                    n = n + reversed;
                    if(IsPalindrome(n))
                    {
                        isLychrel = false;
                        break;
                    }
                }

                if (isLychrel)
                {
                    Console.WriteLine($"{i}");
                    count++;
                }
            }

            return count;
        }

        public BigInteger BigIntegerReverse(BigInteger n)
        {
            var s=n.ToString();
            var reversed = new string(s.Reverse().ToArray());
            return BigInteger.Parse(reversed);
        }

        private bool IsPalindrome(BigInteger n)
        {
            var s = n.ToString();
            int l = s.Length;
            for (int i = 0; i < l / 2; i++)
            {
                if (s[i] != s[l - 1 - i]) return false;
            }
            return true;
        }
    }
}
