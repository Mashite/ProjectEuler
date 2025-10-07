using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldbachsOtherConjecture
{
    internal class Solution
    {
        HashSet<int> primes=new HashSet<int>();
        
        public int Solve()
        {
            primes.Add(3);
            int n = 5;
            while (true)
            {
                bool isPrime = true;
                foreach (int i in primes)
                    if (n % i == 0) { isPrime = false; break; }

                if(isPrime)                
                    primes.Add((int)n);       
                else
                {
                    bool isExcept = true;
                    foreach (int i in primes.Reverse())
                    {
                        int temp = n - i;
                        temp /= 2;
                        int sqrt=(int)Math.Sqrt(temp);
                        if(sqrt*sqrt==temp)
                        {
                            isExcept = false;
                            break;
                        }
                    }
                    if (isExcept) return n;
                }
                n = n + 2;
            }
        }
    }
}
