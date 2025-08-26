using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrimes
{
    internal class Solution
    {
        const int LIMIT = 1_000_000;
        bool[] isPrime= new bool[LIMIT];
        HashSet<int> primeSet = new HashSet<int>();
        public int Solve()
        {
            BuildSieve(LIMIT);

            var circulars = new List<int>();

            foreach (int i in primeSet)
            {
                if(IsCirclePrime(i)) circulars.Add(i);
            }

            return 0;
        }
            void BuildSieve(int n)
            {
                isPrime = new bool[n + 1];
                Array.Fill(isPrime, true);
                isPrime[0] = isPrime[1] = false;

                // standard sieve
                for (int p = 2; p * p <= n; p++)
                {
                    if (!isPrime[p]) continue;
                    for (int m = p * p; m <= n; m += p)
                        isPrime[m] = false;
                }

                // hash set for O(1) membership tests
                primeSet = new HashSet<int>();
                for (int i = 2; i <= n; i++)
                    if (isPrime[i]) primeSet.Add(i);
            }

        public bool IsCirclePrime(int n)
        {
            if(n>10 && HasForbiddenDigits(n)) return false;

            int digits=CountDigits(n);
            int pow10= Pow10(digits-1);

            int rot = n;
            for(int i = 0; i < digits; i++)
            {
                if(!primeSet.Contains(rot)) return false;
                int firstDigit = rot / pow10;
                rot = (rot % pow10)*10 + firstDigit;
            }

            return true;
        }



        public bool HasForbiddenDigits(int n)
        {
            while(n>0)
            {
                int d = n % 10;
                if (d == 0 || d == 2 || d == 4 || d == 6 || d == 8) return true;
                n /= 10;
            }
            return false;
        }
        static int CountDigits(int n) => n < 10 ? 1 :
       n < 100 ? 2 :
       n < 1_000 ? 3 :
       n < 10_000 ? 4 :
       n < 100_000 ? 5 : 6;


        static int Pow10(int k)
        {
            int p = 1;
            while (k-- > 0) p *= 10;
            return p;
        }


        //public bool IsCircle(int n)
        //{
        //    List<int> tempList = new List<int>();
        //    List<int> digits = new List<int>();

        //    tempList.Add((int)n);
        //    while (n >9)
        //    {
        //        digits.Add(n % 10);
        //        n = n / 10;
        //        if (n % 2 == 0)
        //            return false;
        //    }
        //    digits.Add((int)n);
        //    List<int> tempDigits = new List<int>(digits);
        //    for (int i=0; i<digits.Count; i++)
        //    {
               
        //        int temp = tempDigits[digits.Count-1];
        //        for (int j = digits.Count-1; j > 0; j--)
        //        {                    
        //            tempDigits[j] = tempDigits[j-1];
                   
        //        }
        //        tempDigits[0] = temp;

        //        int circlePrm = 0;
        //        int pow = 1;

        //            for(int k=0; k<digits.Count; k++)
        //            {
        //                circlePrm=circlePrm+ tempDigits[k]*pow;
        //                pow *= 10;
        //            }
        //            if (!primes.Contains(circlePrm)) 
        //                return false;
        //            else
        //                tempList.Add(circlePrm);
                
        //    }

        //    foreach (int i in tempList)
        //    {
        //        Console.WriteLine(i);
        //        if(!circlePrimes.Contains(i))
        //         circlePrimes.Add(i);
                 

        //    }

        //    return true;

        //}
    }
}
