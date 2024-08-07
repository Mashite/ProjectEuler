using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseSublist
{
    public class Solution
    {
        public string Solve(string sentence, int k)
        {
            string head = new string( sentence.Substring(0, k).Reverse().ToArray());
            string tail = sentence.Substring(k, sentence.Length - k);
            string sub=string.Join("",head,tail);
            return sub;
        }
    }
}
