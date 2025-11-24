using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SquareRootConvergents
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;
            BigInteger nom = 3;
            BigInteger oldDenom = 2;
            for(int i=0;i<1000;i++)
            {
                BigInteger newDenom = oldDenom + nom;
                nom = oldDenom + newDenom;
                oldDenom = newDenom;
                if(Check(nom,newDenom))
                    count++;
            }
            return count;
        }


        public bool Check(BigInteger n, BigInteger d)
        {
            if(n.ToString().Length>d.ToString().Length)
                return true;
            return false;
        }
    }

    
    


}

