using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralPrimes
{
    internal class Solution
    {
        const int LIMIT = 1_000_000;
        public bool[] isPrime = new bool[LIMIT];
        public List<int> primes = new List<int>();

        public int Solve()
        {
            Primes();
            int level = 2;
            int diagonalValue = 1;
            int diagonalCount = 1;
            int primeCount = 0;

            do
            {
                for (int i = 0; i < 4; i++)
                {
                    diagonalValue = diagonalValue + level;
                    if (diagonalValue < LIMIT && isPrime[diagonalValue])
                        primeCount++;
                    else if (diagonalValue > LIMIT && IsPrime(diagonalValue))
                        primeCount++;
                    diagonalCount++;
                }

                level += 2;
            }
            while (primeCount * 10 >= diagonalCount);
            return level-1;
        }

        public void Primes()
        {
            Array.Fill(isPrime, true);
            if (LIMIT > 0) isPrime[0] = false;
            if (LIMIT > 1) isPrime[1] = false;

            for (int i = 2; i * i < LIMIT ; i++)
            {
                if (!isPrime[i]) continue;

                for (int j = i * 2; j < LIMIT; j = j + i)
                    isPrime[j] = false;
            }

            for (int i = 2; i < LIMIT; i++)
                if (isPrime[i])
                    primes.Add(i);

        }


        bool IsPrime(long n)
        {
            if (n < 2) return false;

            foreach (var p in primes)
            {
                long pp = (long)p * p;
                if (pp > n) break;
                if (n % p == 0) return false;
            }
            return true;
        }
    }
}
