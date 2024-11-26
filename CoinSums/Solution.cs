using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinSums
{
    public class Solution
    {
     
        public int Solve()  
        {
            int target = 200;
            int[] coins = new int[8] { 1, 2, 5, 10, 20, 50, 100, 200 };
            var table = new int[201];
            table[0] = 1;
            for (var i = 0; i < coins.Count(); i++)
            {
                for (var j = coins[i]; j <= target; j++)
                {
                    table[j] += table[j - coins[i]];
                }
            }
            return table[target];
        }

    }
}
