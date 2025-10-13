using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePermutations
{
    internal class Solution
    {
        const int LIMIT = 10000;
        bool[] isPrime = new bool[LIMIT];
        public string Solve()
        {
            Sieve();
            for (int i = 1000; i < LIMIT / 3; i++)
            {

                if (!isPrime[i]) continue;
                for (int j = 1; j < LIMIT / 3; j++)
                {
                    int m = i + j;
                    int p = i + 2 * j;

                    if (!isPrime[m] || !isPrime[p]) continue;
                    if (!SameDigits(i, m) || !SameDigits(i, p)) continue;

                    string concat = $"{i}{m}{p}";
                    Console.WriteLine(concat);
                }
            }
            return "";
        }

        public void Sieve()
        {
            Array.Fill(isPrime, true);
            if (LIMIT > 0) isPrime[0] = false;
            if (LIMIT > 1) isPrime[1] = false;

            for (int i = 2; i * i < LIMIT; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i*i; j < LIMIT; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        static bool SameDigits(int a, int b)
        {
            var sa = a.ToString().OrderBy(c => c);
            var sb = b.ToString().OrderBy(c => c);
            return sa.SequenceEqual(sb);
        }
    }
}
