using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticPrimes
{
    public class Solution
    {
        List<int> primes = new List<int>();
        public int Solve()
        {
            List<int> primes1000 = Primes(1000);
            primes = Primes(1000);
            int max = 0;
            int maxA = 0;
            int maxB = 0;
            for (int a = -999; a < 1000; a++)
            {
                foreach (int b in primes1000)
                {
                    int n = 0;
                    bool isPrime = true;
                    while (isPrime)
                    {
                        int result = (n * n) + (a * n) + b;
                        isPrime = IsPrime(result);
                        n++;
                    }

                    if (max < n)
                    {
                        max = n;
                        maxA = a;
                        maxB = b;
                    }
                }
            }

            return maxA*maxB;
        }
        public List<int> Primes(long k)
        {
            List<int> primes = new List<int>();
            primes.Add(2);

            for (int i = 3; i <= k; i = i + 2)
            {
                bool isPrime = true;
                foreach (int p in primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)                
                    primes.Add(i);
                
            }
            return primes;
        }
        public bool IsPrime(int k)
        {
            if(k>1000)
                primes=Primes(k);

            if(primes.Contains(k))
                return true; 
            bool isPrime = true;
            foreach (int p in primes)
            {
                if (k % p == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;            
        }
    }
}
