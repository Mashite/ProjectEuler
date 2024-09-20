using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LatticePaths
{
	public class Solution
	{
		public BigInteger Solve(int n)
		{
			BigInteger D = Factorial(n * 2);
			BigInteger P=  Factorial(n);
			BigInteger One = P * P;
			BigInteger Two = D/One;
			return Two;
		}
		public static BigInteger Factorial(int n)
		{
			if (n == 1) return 1 ;
			return  n * Factorial(n-1);
		}

	}


}
