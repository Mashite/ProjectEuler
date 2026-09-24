using System.Numerics;

namespace ProductsumNumbers
{
    internal class Solution
    {
        private readonly Dictionary<int, int> minimums = new();

        private const int MaxK = 12000;
        private const int MaxProduct = 2 * MaxK;
        

        public int Solve()
        {
            FindProductSumNumbers(product: 1, sum: 0, factorCount: 0, minimumFactor: 2);
            int sum = 0;
            HashSet<int> only = new HashSet<int>();
            foreach (int i in minimums.Keys)
            {
                only.Add(minimums[i]);
            }
            sum=only.Sum();
            return 0;  
        
        }

        private void FindProductSumNumbers(int product, int sum, int factorCount, int minimumFactor)
        {
            for (int factor = minimumFactor; factor <= MaxProduct / product; factor++)
            {
                int newProduct = product * factor;
                int newSum = sum + factor;
                int newCount = factorCount + 1;

                int k = newCount + newProduct - newSum;

                if (k > MaxK)
                    break;

                if (k >= 2)
                {
                    if (!minimums.TryGetValue(k, out int currentMinimum) || newProduct < currentMinimum)
                    {
                        minimums[k] = newProduct;
                    }
                }

                FindProductSumNumbers(newProduct, newSum, newCount, factor);
            }
        }
    }
}