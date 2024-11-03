using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonAbundantSums
{
    public class Solution2
    {
        public int Solve(int k)
        {
            List<int> abundants = new List<int>();
            List<int> allInteger = Enumerable.Range(1, k).ToList();
            for(int i = 12;i<=k;i++)
            {
                if(TotalDivs(i)>i)
                {
                    abundants.Add(i);
                    for(int j =0;j<abundants.Count ;j++)
                        allInteger.Remove(i + abundants[j]);
                }
            }

            return allInteger.Sum();
        }

        public int TotalDivs(int n)
        {
            int sum = 1;
            for(int i = 2;i < ((n/2)+1); i++) 
            {
                if (n % i == 0)
                    sum += i;
            }
            return sum;
        }
    }
}
