using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubicPermutations
{
    internal class Solution
    {
        public Dictionary<string, List<long>> cubics = new Dictionary<string, List<long>>();
        public long Solve()
        {
            for (long i = 1000; ; i++)
            {
                long cubic = i * i * i;

                string cubicDigits = new string( cubic.ToString() .OrderBy(c => c).ToArray() );

                if (cubics.ContainsKey(cubicDigits))
                    cubics[cubicDigits].Add(cubic);
                else
                    cubics.Add(cubicDigits, new List<long>() { cubic });

                if (cubics[cubicDigits].Count == 5) 
                    return cubics[cubicDigits].First();
            }

            return 0;
        }
    }
}
