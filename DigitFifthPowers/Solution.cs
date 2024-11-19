using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFifthPowers
{
    public class Solution
    {
        public int Solve()
        {
            List<int> list = new List<int>();
            for(int i = 10; i < 354294; i++)  // 6 * Pow(9,5)=354294 < 999999
            {
                
                if(DigitsSum(i)==i)
                    list.Add(i);
            }

            return list.Sum();
        }

        private int DigitsSum(int i)
        {
             if(i<10)
            {
                return (int)Math.Pow(i,5);
            }

            return (int)Math.Pow(i % 10, 5) + DigitsSum(i / 10);
        }
    }

   
}
