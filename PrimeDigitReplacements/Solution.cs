using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeDigitReplacements
{
    internal class Solution
    {
        const int LIMIT = 1000000;
        public bool[] isPrime = new bool[LIMIT];
        public List<int> primes = new List<int>();
        public int Solve()
        {
            Sieve();

            for (int i = 0; i < primes.Count; i++)
            {
                int p = primes[i];
                if (primes[i] < 10000) continue;

                string s = p.ToString();
                var distinct = new HashSet<char>(s);
                foreach (char c in distinct)
                {
                    int count = 0;

                    for (int j = 0; j <= 9; j++)
                    {
                        string sub = s.Replace(c, (char)('0' + j));
                        if (s[0] == c && j == 0) continue;
                        if (isPrime[Convert.ToInt32(sub)])
                            count++;
                        if (count == 8)
                            return p;
                    }
                }
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

            for (int i = 13; i < LIMIT; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }

        }


    }


}
