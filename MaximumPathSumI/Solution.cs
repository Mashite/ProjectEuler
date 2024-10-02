using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSumI
{
    public class Solution
    {
        int[][] ints = [[75],
                        [95, 64],
                        [17, 47, 82],
                        [18, 35, 87, 10],
                        [20, 04, 82, 47, 65],
                        [19, 01, 23, 75, 03, 34],
                        [88, 02, 77, 73, 07, 63, 67],
                        [99, 65, 04, 28, 06, 16, 70, 92],
                        [41, 41, 26, 56, 83, 40, 80, 70, 33],
                        [41, 48, 72, 33, 47, 32, 37, 16, 94, 29],
                        [53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14],
                        [70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57],
                        [91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48],
                        [63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31],
                        [04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23]];

        public int Solve()
        {
            for(int i = ints.GetLength(0)-1;i>0; i--)
            {
                for(int j = 0; j < ints[i].Length-1; j++)
                {
                    ints[i - 1][j] = ints[i - 1][j] + Math.Max(ints[i][j], ints[i][j + 1]);
                }
            }

            return ints[0][0];
        }

        //public int Solve()
        //{
        //    int j = 0;
        //    int sum = 0;
            
        //    for(int i=0; i<ints.GetLength(0);i++)
        //    {
        //        int max = 0;
        //        j = FindMax(i, j, out max);
        //        sum += max;
        //    }
        //    return sum;
        //}

        public int FindMax(int i, int j, out int max)
        {
            max = 0;
            int maxJ = j;
            if(ints[i][j]>max)
            {
                max = ints[i][j];
                maxJ = j;
            }
            if(j < ints[i].Length-1)
                if(ints[i][j + 1]>max)
                {
                    max = ints[i][j + 1];
                    maxJ = j + 1;
                }
            return maxJ;
        }
    }
}
