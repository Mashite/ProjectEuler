using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruncatablePrimes
{
    internal class Solution
    {
        const int LIMIT = 1_000_000;
        bool[] isPrime = new bool[LIMIT];
        HashSet<int> trunctable = new HashSet<int>();

        public int Solve()
        {
            Sieve();
            for (int i = 23; i < LIMIT; i++)
            {
                if (!isPrime[i]) continue;
                if (IsTruncatable(i))
                    trunctable.Add(i);
            }
            return trunctable.Sum();
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

        public bool IsTruncatable(int n)
        {
            if (!DigitsCheck(n)) return false;

            for (int i = 10; i < n ; i *= 10)
            {
                int suffix = n % i;
                if (!isPrime[suffix]) return false;
            }

            for (int i = 10; i < n ; i *= 10)
            {
                int prefix = n / i;
                if (!isPrime[prefix]) return false;

            }

            return true;
        }

        public bool DigitsCheck(int n)
        {
            int last = n % 10;
            if (last == 2 || last == 5)
                return false;

            while (n >= 10)
            {
                n = n / 10;
                int d = n % 10;
                if (last == 2 || last == 5)
                    return false;
            }

            return true;
        }
    }
}
