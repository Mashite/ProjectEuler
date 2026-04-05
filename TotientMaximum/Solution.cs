using System;
using System.Collections.Generic;
using System.Text;

namespace TotientMaximum
{
    internal class Solution
    {
        bool[] primes = new bool[1_000_000];
        public int Solve()
        {
            Array.Fill(primes, true);
            Sieve();
            double maxRatio = 0;
            int bestN = 0;

            for (int i = 2; i < 1_000_000; i++)
            {
                if(primes[i])continue;
                int phi = Totient(i);
                double ratio = (double)i / phi;

                if (ratio > maxRatio)
                {
                    maxRatio = ratio;
                    bestN = i;
                }
            }

            return bestN;
        }


        void Sieve()
        {
            primes[0] = false;
            primes[1] = false;
            for (int i = 2; i*i < primes.Length; i++)
            {
                if (!primes[i]) continue;
                for (int j = i * i; j <primes.Length; j+=i)
                {
                    primes[j] = false;
                }
            }
        }
        int Totient(int n)
        {
            int result = n;
            int temp = n;

            for (int p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            if (temp > 1)
                result -= result / temp;

            return result;
        }
    }

}


