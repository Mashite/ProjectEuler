using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandigitalMultiples
{
    internal class Solution
    {
        public int Solve()
        {
            for(int i=9183;i<=9487; i++)
            {
                if (Check(i))
                    Console.WriteLine(i  +" "+i*2);
            }
            return 0;
        }

        public bool Check(int i)
        {
            char[] str = i.ToString().ToArray();
            str=str.Concat((i * 2).ToString().ToArray()).ToArray();

            char[] digits = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            foreach(char c in digits) {
                if(!str.Any(p=>p==c)) return false;
            }
            return true;
        }

        public bool Check2(int i)
        {
            string s = i.ToString() + (i * 2).ToString();

            // Must be exactly 9 digits.
            if (s.Length != 9) return false;

            int mask = 0;
            foreach (char ch in s)
            {
                int d = ch - '0';
                if (d == 0) return false;            // no zero allowed
                int bit = 1 << d;
                if ((mask & bit) != 0) return false; // digit repeats
                mask |= bit;
            }

            // Bits 1..9 set -> 0b1111111110 = 1022
            return mask == 1022;
        }
    }
}
