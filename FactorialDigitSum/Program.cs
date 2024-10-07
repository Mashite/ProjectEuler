// See https://aka.ms/new-console-template for more information

using FactorialDigitSum;
using System.Numerics;

Solution solution= new Solution();
BigInteger result = solution.Solve(100);

int sum = 0;

string resultString = result.ToString();
int i = 0;
while (i<resultString.Length)
{
    sum += Convert.ToInt32(resultString.Substring(i,1));
    i++;
}

Console.WriteLine(sum);
