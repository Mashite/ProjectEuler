using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringDivisibility
{
    internal class Solution
    {
        long LIMIT = 9_876_543_210;
        long sum = 0;
        char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public long Solve()
        {
            for (long i = 1_023_456_789; i <= LIMIT;)
            {
                string s=i.ToString();
                int a = Convert.ToInt16(string.Join("",s[1],s[2],s[3]));
                if (a % 2 == 0)
                {
                    a = Convert.ToInt16(string.Join("",s[2], s[3],s[4]));
                    if (a % 3 == 0)
                    {
                        a = Convert.ToInt16(string.Join("", s[3], s[4], s[5]));
                        if (a % 5 == 0)
                        {
                            a = Convert.ToInt16(string.Join("", s[4], s[5], s[6]));
                            if (a % 7 == 0)
                            {
                                a = Convert.ToInt16(string.Join("", s[5], s[6], s[7]));
                                if (a % 11 == 0)
                                {
                                    a = Convert.ToInt16(string.Join("", s[6], s[7], s[8]));
                                    if (a % 13 == 0)
                                    {
                                        a = Convert.ToInt16(string.Join("", s[7], s[8], s[9]));
                                        if (a % 17 == 0)
                                        {
                                            if (IsPandigal(i))
                                                sum += i;
                                            i++;
                                        }
                                        else
                                        {
                                            i++;
                                        }

                                    }
                                    else
                                    {
                                        i += 10;
                                    }
                                }
                                else
                                {
                                    i += 100;
                                }
                            }
                            else
                            {
                                i += 1000;
                            }
                        }
                        else
                        {
                            i += 10000;
                        }
                    }
                    else
                    {
                        i += 100000;
                    }
                }
                else
                {
                    i += 1000000;
                }
            }

            return sum;
        }

        public bool IsPandigal(long i)
        {
            string s = i.ToString();
            foreach(char c in digits)
            {
                if(!s.Contains(c))return false;
            }
            return true;
        }
    }
}
