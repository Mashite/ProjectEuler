using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctPrimesFactors
{
    internal class Solution
    {
        public const int LIMIT = 1_000_000;
        public bool[] isPrime = new bool[LIMIT];
        public List<int> primes = new List<int>();

        public int Solve()
        {
            Sieve();

            int count = 0;
            for (int i = 210; i < LIMIT; i++)
            {
                if (primes.Contains(i))
                {
                    count = 0; continue;
                }

                int distinct = 0;
                int d = i;
                foreach (int p in primes)
                {
                    if (d == 1) break;
                    if (d % p == 0)
                    {
                        distinct++;
                        while (d % p == 0)
                        {
                            d = d / p;
                        }
                    }
                }
                if (distinct == 4)
                { count++;
                    if (count == 4) return i - 3; 
                }
                else count = 0;
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
                    isPrime[j] = false;
            }

            for (int i = 2; i < LIMIT; i++)
                if (isPrime[i]) primes.Add(i);
        }


    }
}
