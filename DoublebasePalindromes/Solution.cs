using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublebasePalindromes
{
    internal class Solution
    {

        const int LIMIT = 1000000;

        public int Solve()
        {
            int sum = 0;
            for (int i = 1; i <= LIMIT; i += 2)
            {

                if (IsPolindrom(Digits(i, 10)) && IsPolindrom(Digits(i, 2)))
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }

            return 0;
        }



        public bool IsPolindrom(List<int> n)
        {
            var reversed = new List<int>(n);
            reversed.Reverse();
            return n.SequenceEqual(reversed);
        }


        public List<int> Digits(int n, int nbase)
        {
            List<int> digits = new List<int>();
            while (n >= nbase)
            {
                int digit = n % nbase;
                n = n / nbase;
                digits.Add(digit);
            }
            digits.Add(n);

            return digits;

        }



        public bool Polindrom2(int n)
        {
            List<int> digits = Digits2(n);
            for (int i = 0, j = digits.Count - 1; i < digits.Count / 2; i++, j--)
            {
                int head = digits[i];
                int tail = digits[j];
                if (head != tail) return false;
            }
            return true;
        }

        public List<int> Digits2(int n)
        {
            List<int> digits = new List<int>();
            while (n > 1)
            {
                int digit = n % 2;
                n = n / 2;
                digits.Add(digit);
            }
            digits.Add(n);

            return digits;

        }


    }
}
