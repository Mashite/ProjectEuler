using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutivePrimeSum
{
    internal class Solution
    {
        const int LIMIT = 1000000;
        bool[] isPrime=new bool[LIMIT];
        HashSet<long> primes = new HashSet<long>();
        HashSet<long> sums = new HashSet<long>();
        public int Solve()
        {
            Sieve();
            long sum = 0;
            foreach(int p in primes)
            {
                sum += p;
                sums.Add(sum);
            }
            int len = sums.Count;
            int start = 0;
            int longest = 1;
            foreach(long r in sums.Reverse())
            {
                foreach(long p in sums)
                {                    
                    if((r-p)>LIMIT ||p==r || (len - start)<=longest ) break;
                    start++;

                    if (primes.Contains(r - p) && (len - start) > longest)
                    {
                        Console.WriteLine(r - p);
                        longest = len - start;
                        break;
                    }
                    
                }
                len--;
                start = 0;
            }

            return longest;
        }

        public void Sieve()
        {
            Array.Fill(isPrime, true);
            if (LIMIT > 0) isPrime[0] = false;
            if (LIMIT > 1) isPrime[1] = false;
            for (int i = 2; i*i < LIMIT; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = i*i; j < LIMIT; j += i)
                    isPrime[j] = false;
            }

            for(int i = 2;i < LIMIT; i++)
            {
                if(isPrime[i]) primes.Add(i);
            }
        }
    }
}
