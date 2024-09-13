using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HighlyDivisibleTriangularNumber
{
    public class Solution
    {
        public long Solve()
        {
            long sum = 6;
            int index = 3;
            int calc = 1;
            List<int> list = Primes(500);

            while (calc < 500)
            {
                calc = 1;
                index++;
                sum += index;
                List<(int, int)> divisions = new List<(int, int)>();
              
                long tempSum = sum;
                while (tempSum == 1) { }
                {
                    int j = 1;
                    for (int i = 0; i < list.Count && tempSum > 1;)
                    {
                        if (tempSum % list[i] == 0)
                        {
                            tempSum = tempSum / list[i];
                            j++;

                            if (tempSum == 1)
                            {
                                divisions.Add((list[i], j));
                                break;
                            }
                        }
                        else
                        {
                            if (j > 1)
                            {
                                divisions.Add((list[i], j));
                                j = 1;
                            }
                            i++;

                        }


                    }
                }

                foreach (var item in divisions)
                {
                    calc = item.Item2 * calc;

                }

            }


            return sum;
        }

        

        public List<int> Primes(long k)
        {
            List<int> primes = new List<int>();
            primes.Add(2);

            for (int i = 3, j = 1; j < k; i = i + 2)
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
                {
                    primes.Add(i);
                    j++;
                }
            }
            return primes;
        }
               
    }
}
