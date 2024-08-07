using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummationofPrimes
{
    public class Solution
    {
        public Int64 Solve(int k)
        {
            List<int> primes = new List<int>();
            Int64 sum = 0;
            primes.Add(2);

            for (int i = 3; i < k; i = i +2)
            {
                bool isPrime = true;
                foreach(int p in primes)
                {
                    if(i%p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime) primes.Add(i);
                sum += i;
            }
            return sum;
        }
        
    }
}
