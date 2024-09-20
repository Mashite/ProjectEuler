using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerDigitSum
{
	public class Solution
	{
		public static BigInteger Power(int pow)
		{
			if (pow == 0) return 1;

			return 2 * Power(pow - 1);
		}
	}
}
