using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DistinctPowers
{
    public class Solution
    {
        //List<(int, int)> squars = new List<(int, int)>();
        //public int Solve()
        //{
        //    int distinct = 0;
        //    for (int a = 2; a <= 100; a++)
        //    {
        //        var result = squars.FindAll(s => s.Item1 == a);
        //        if (result.Count != 0)
        //        {
                    
        //            bool check = false;
        //            for (int b = 2; b <= 100; b++)
        //            {
        //                if (Math.Pow(a, b) <= 100 && check == false)
        //                    squars.Add(((int)Math.Pow(a, b), b));
        //                else
        //                    check = true;

        //                bool checkPows = false;
        //                foreach ((int, int) pows in result)
        //                {
        //                    int pow = pows.Item2;
        //                    if (b > pow && b % pow == 0 && pow * b <= 100) checkPows = true;
                            
        //                }
        //                if (!checkPows)
        //                {
        //                    distinct++;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            bool check = false;
        //            for (int b = 2; b <= 100; b++)
        //            {
        //                if (Math.Pow(a, b) <= 100 && check == false)
        //                    squars.Add(((int)Math.Pow(a, b), b));
        //                else
        //                    check = true;

        //                distinct++;
        //            }
        //        }

        //    }

        //    return 0;
        //}

        //public List<int> Primes(long k)
        //{
        //    List<int> primes = new List<int>();
        //    primes.Add(2);

        //    for (int i = 3; i <= k; i = i + 2)
        //    {
        //        bool isPrime = true;
        //        foreach (int p in primes)
        //        {
        //            if (i % p == 0)
        //            {
        //                isPrime = false;
        //                break;
        //            }
        //        }
        //        if (isPrime)
        //            primes.Add(i);

        //    }
        //    return primes;
        //}
        //public bool IsPrime(int k)
        //{
        //    if (primes.Contains(k))
        //        return true;
        //    bool isPrime = true;
        //    foreach (int p in primes)
        //    {
        //        if (k % p == 0)
        //        {
        //            isPrime = false;
        //            break;
        //        }
        //    }
        //    return isPrime;
        //}


        public int Solve()
        {
            List<BigInteger> pows = new List<BigInteger>();
            for(BigInteger a=2;a<=100;a++)
            {
                BigInteger pow = a;
                for(BigInteger b=2;b<=100;b++)
                {
                    pow = pow * a; pows.Add(pow);
                }
            }

           return  pows.Distinct().Count();

            
        }
    }


}
