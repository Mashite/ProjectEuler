using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandigitalPrime
{
    internal class Solution
    {
        const int LIMIT = 7654322;
        bool[] isPrime = new bool[LIMIT];
        char[] digits = new char[] { '1', '2', '3', '4', '5', '6', '7' };
        public int Solve()
        {
            Sieve();

            int start = 7_654_321;
            int end = 1_234_567;
            int pow = 1_000_000;
            while (pow > 10)
            {
                for (int i = start; i >= end; i--)
                {
                    if (isPrime[i])
                        if (Check(i))
                            return i;
                }
                start = start % pow;
                end = end / 10;
                pow = pow / 10;
                Array.Resize(ref digits, digits.Length - 1);
            }                       

            return 0;
        }
        public void Sieve()
        {
            Array.Fill(isPrime, true);
            if (LIMIT > 0) isPrime[0] = false;
            if (LIMIT > 1) isPrime[1] = false;

            for (int i = 2; i * i < LIMIT; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i * i; j < LIMIT; j += i)
                {
                    isPrime[j] = false;
                }
            }

        }

        public bool Check(int n)
        {
            char[] str=n.ToString().ToCharArray();
            foreach (char c in digits)
                if (!str.Any(p => p == c)) return false;
            return true;
        }

    }

}
