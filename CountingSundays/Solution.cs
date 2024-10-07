using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSundays
{
    public class Solution
    {
        public int Solve()
        {
            DateTime oldCentury= new DateTime(1901,1,1);
            DateTime newCentury = new DateTime(2001, 1, 1);
            int suns = 0;
            while(oldCentury<newCentury)
            {
                oldCentury=oldCentury.AddMonths(1);
                if(oldCentury.DayOfWeek==DayOfWeek.Sunday)
                    suns++;
            }
            return suns;
        }
    }
}
