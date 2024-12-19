using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandigitalProducts
{
    public class Solution
    {
        public int Solve()
        {
            List<int> list = new List<int>();
            for(int  i=1; i<=9;i++)
            {
                if (!i.ToString().GroupBy(c => c).All(g => g.Count() == 1) || i.ToString().Contains('0'))
                    continue;
                for (int j= 1234; j<=9876;j++)
                {
                    if (!j.ToString().GroupBy(c => c).All(g => g.Count() == 1) || j.ToString().Contains('0'))
                        continue;
                    if (i.ToString().Intersect(j.ToString()).Any())
                        continue;

                    int mult = i * j;
                    if (!mult.ToString().GroupBy(c => c).All(g => g.Count() == 1) || mult.ToString().Contains('0'))
                        continue;
                    if (i.ToString().Intersect(mult.ToString()).Any() || j.ToString().Intersect(mult.ToString()).Any())
                        continue;


                   // Console.WriteLine(i +" x " + j +" = " + mult);
                    list.Add(mult);
                }
            }

            for (int i = 12; i <= 98; i++)
            {
                if (!i.ToString().GroupBy(c => c).All(g => g.Count() == 1) || i.ToString().Contains('0'))
                    continue;
                for (int j = 123; j <= 987; j++)
                {
                    if (!j.ToString().GroupBy(c => c).All(g => g.Count() == 1) || j.ToString().Contains('0'))
                        continue;
                    if (i.ToString().Intersect(j.ToString()).Any())
                        continue;

                    int mult = i * j;
                    if (!mult.ToString().GroupBy(c => c).All(g => g.Count() == 1) || mult.ToString().Contains('0'))
                        continue;
                    if (i.ToString().Intersect(mult.ToString()).Any() || j.ToString().Intersect(mult.ToString()).Any())
                        continue;


                    //Console.WriteLine(i + " x " + j + " = " + mult);
                    list.Add(mult);
                }
            }

            return list.Distinct().Sum();
        }
    }
}
