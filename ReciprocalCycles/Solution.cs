using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciprocalCycles
{
    public class Solution
    {
        public int Solve()
        {
            int max=0;
            int longest=0;
            for(int i=10;i<1000;i++)
            {
                int num = 1;
                List<int> mods = new List<int>();
                while (num!=0)
                {
                    if (num < i)                    
                        num = num * 10;
                     else
                     {
                        num = num % i;
                        if (mods.Any(p => p == num))
                            break;
                        mods.Add(num);
                     }
                }
                if (mods.Count > max)
                {
                    max = mods.Count;
                    longest = i;
                }
            }
            return longest;
        }

        
    }
}
