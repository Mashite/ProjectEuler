using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeSummations
{
    internal class Solution
    {
        private int[,] memo = new int[101, 100];
        bool[] isPrime = new bool[100];
        List<int> primes = new List<int>();
        public int Solve()
        {
            Sieve();

            for (int i = 10; i < 100; i++)
            {
                int j = primes.Where(p => p < i).LastOrDefault();
                int res = Count(i, j);
                memo = new int[101, 100];
                if (res > 5000)
                {
                    Console.WriteLine(res);
                    break;
                }
            }

            return 0;
        }


        public int Count(int n, int m)
        {
            if (n == 0) return 1; 
            if (n < 0 || m == 0) return 0;
            if (memo[n, m] != 0)
                return memo[n, m];
            int j = primes.Where(p => p < m).LastOrDefault();            
            memo[n, m] = Count(n - m, m) + Count(n, j);
            return memo[n, m];
        }

        void Sieve()
        {
            Array.Fill(isPrime, true);
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i < 100; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                    for (int j = i * 2; j < 100; j += i)
                        isPrime[j] = false;
                    
                }
            }

            for (int i = 0; i < isPrime.Length; i++)
                if (isPrime[i]) primes.Add(i);
        }

    }
}