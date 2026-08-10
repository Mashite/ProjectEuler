namespace PrimePowerTriples
{
    internal class Solution
    {
        public int Solve()
        {
            int count = 0;

            for(int c = 1; ; c++)
            {
                for (int sum =  2; sum <=2*c; sum++)
                {
                    int value = sum * sum + c * c;

                    int root = (int)Math.Sqrt(value);

                    if (root * root == value)
                    {
                        int minA = Math.Max(1, sum - c);
                        int maxA = sum / 2;

                        int pairCount = maxA - minA + 1;

                        if (pairCount > 0)
                            count += pairCount;
                    }
                }
                if (count > 1_000_000)
                    return c;
            }

          
        }
    }
}