using PowerDigitSum;
using System.Numerics;

BigInteger result = Solution.Power(1000);
Console.WriteLine(result);
string digits = result.ToString();

int sum = 0;
for (int i = 0; i < digits.Length; i++)
	sum += Convert.ToInt32( digits.Substring(i,1));
Console.WriteLine(sum);
