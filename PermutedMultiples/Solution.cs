using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutedMultiples
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 12;
            while (true)
            {
                if (SameDigits(count, count * 3))
                    if (SameDigits(count, count * 2))
                        if (SameDigits(count, count * 4))
                            if (SameDigits(count, count * 5))
                                if (SameDigits(count, count * 6))
                                {
                                    Console.WriteLine(count);
                                    Console.WriteLine(count * 2);
                                    Console.WriteLine(count * 3);
                                    Console.WriteLine(count * 4);
                                    Console.WriteLine(count * 5);
                                    Console.WriteLine(count * 6);
                                    return count;
                                }
                    count+=3;
            }

        }
         
        
        public bool SameDigits(int n, int m)
        {
            HashSet<char> nSet = new HashSet<char>(n.ToString());
            if(nSet.Count!=n.ToString().Length) 
                return false;
            HashSet<char> mSet = new HashSet<char>(m.ToString());
            if(mSet.Count!=m.ToString().Length)
                return false;
            if(nSet.Count!=mSet.Count) 
                return false;
            foreach(char c in nSet)
                if(!mSet.Contains(c)) 
                    return false;
            return true;
        }
    }
}
