using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialPythagoreanTriplet
{
    public class Solution
    {
        public int Solve()
        {

            for (int i = 1; i < 500; i++)
            {
                for (int j = 1; j <500 ; j++)
                {
                    int c = (i * i) + (j * j);
                    int root = 0;
                    if (IsPerfectSquare(c, out root) && root!=0 && root + i + j == 1000)
                        return i * j * root;

                }
            }

            return 0;
        }
        static bool IsPerfectSquare(int number, out int root)
        {
            if (number < 0)
            {
                root = 0;
                return false;
            }

            root = (int)Math.Sqrt(number);
            return root * root == number;
        }
    }
}
