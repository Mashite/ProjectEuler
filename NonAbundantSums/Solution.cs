﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonAbundantSums
{
    public class Solution
    {
        List<int> primes = new List<int>();

        public int Solve(int k)
        {
            primes = Primes(k);
            List<int> abundant= new List<int>();
            List<int> allIntegers = Enumerable.Range(1, k).ToList();
            for (int i = 12;i<=k;i++)
            {
                if(!primes.Any(p=>p==i))
                    if(FindSum(i) > i )
                    {
                        abundant.Add(i);
                        for (int j=0;j<abundant.Count;j++)
                        {
                            allIntegers.Remove(i + abundant[j]);
                        }                    
                    }                               
            }

            return allIntegers.Sum();
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

        private int FindSum(int num)
        {
            List<(int, int)> divisions = new List<(int, int)>();

            long tempSum = num;
            while (tempSum == 1) { }
            {
                int j = 0;
                for (int i = 0; i < primes.Count && tempSum > 1;)
                {
                    if (tempSum % primes[i] == 0)
                    {
                        tempSum = tempSum / primes[i];
                        j++;

                        if (tempSum == 1)
                        {
                            divisions.Add((primes[i], j));
                            break;
                        }
                    }
                    else
                    {
                        if (j > 0)
                        {
                            divisions.Add((primes[i], j));
                            j = 0;
                        }
                        i++;
                    }
                }
            }

            List<int> divs = GenerateDivisors(divisions);
            divs.Remove(num);
            int sum = divs.Sum(i => i);
            return sum;
        }
        static List<int> GenerateDivisors(List<(int, int)> primeFactors)
        {
            var divisors = new List<int> { 1 };  // Start with 1 as the first divisor

            foreach (var factor in primeFactors)
            {
                int prime = factor.Item1;
                int exponent = factor.Item2;
                var newDivisors = new List<int>();

                foreach (var divisor in divisors)
                {
                    int power = 1;
                    for (int i = 0; i <= exponent; i++)
                    {
                        newDivisors.Add(divisor * power);
                        power *= prime; // Multiply by the prime to get the next power
                    }
                }
                divisors = newDivisors;
            }

            return divisors;
        }
    }
}