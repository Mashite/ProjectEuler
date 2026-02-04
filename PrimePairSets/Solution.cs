using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrimePairSets
{


    internal class Solution
    {
        const int LIMIT = 1000000;
        public bool[] isPrime = new bool[LIMIT];
        public List<int> primes = new List<int>();

        public int Solve()
        {
            FindPrimes();
            Array.Fill(setCount, 0);
            long min = 1000000;

            for (int i = 0; i < primes.Count - 5; i++)
            {
                if (primes[i] == 2 || primes[i]==5) continue;      

                for (int j = i + 1; j < primes.Count  - 4; j++)
                {
                    if (primes[j] == 2 || primes[j] == 5) continue;
                    if (primes[i] + primes[j] > min)
                        break;
                    if (Check(i,j)&&
                        Check(j,i))
                    {
                        
                        for (int k = j + 1; k < primes.Count - 3; k++)
                        {
                            if (primes[k] == 2 || primes[k] == 5) continue;
                            if (primes[i] + primes[j] + primes[k] > min)
                                break;
                            if (Check(i, k) &&
                       Check(k, i) &&
                       Check(j, k) &&
                       Check(k, j))
                            {
                                for (int l = k + 1; l < primes.Count - 2; l++)
                                {
                                    if (primes[i] + primes[j] + primes[k] + primes[l] > min)
                                        break;
                                        if (Check(i, l) &&
                               Check(l, i) &&
                               Check(j, l) &&
                               Check(l, j) &&
                               Check(k, l) &&
                               Check(l, k))
                                    {
                                        for (int m = l + 1; m < primes.Count - 1; m++)
                                        {
                                            if (primes[i] + primes[j] + primes[k] + primes[l] + primes[m] > min) break;
                                            if (Check(i, m) &&
                                                   Check(m, i) &&
                                                   Check(j, m) &&
                                                   Check(m, j) &&
                                                   Check(k, m) &&
                                                   Check(m, k) &&
                                                   Check(l, m) &&
                                                   Check(m, l))
                                            {
                                                Console.WriteLine(primes[i] + primes[j] + primes[k] + primes[l] + primes[m]);
                                                if (primes[i] + primes[j] + primes[k] + primes[l] + primes[m] < min)
                                                    min = primes[i] + primes[j] + primes[k] + primes[l] + primes[m];
                                                else
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
             
            }
            return 0;
        }

        public bool Check(int p, int q)
        {
            long value = long.Parse(primes[p].ToString() + primes[q].ToString());
            if (value < LIMIT) return isPrime[(int)value];
            return IsPrime64(value); // you need this for correctness
        }

        bool IsPrime64(long n)
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

        public void FindPrimes()
        {
            Array.Fill(isPrime, true);

            if (isPrime.Length > 0) isPrime[0] = false;
            if (isPrime.Length > 1) isPrime[1] = false;

            for (int i = 2; i * i < LIMIT; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i * i; j < LIMIT; j = j + i)
                    isPrime[j] = false;
            }

            for (int i = 2; i < LIMIT; i++)
                if (isPrime[i])
                    primes.Add(i);

        }
    }
}
