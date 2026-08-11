namespace Problem87
{
    internal class Solution
    {
        bool[] isPrime = new bool[10000];
        public int Solve()
        {
            Sieve(10000);
            int maxSqr = (int)Math.Sqrt(49_999_976);
            int maxTri = (int)Math.Cbrt(49_999_980);
            int maxQuad = (int)Math.Pow(49_999_988, 0.25);
            int count = 0;
            HashSet<int> visited = new HashSet<int>();
            for (int i = 2; i <= maxSqr; i++)
            {
                if (!isPrime[i]) 
                    continue;
                for (int j = 2; j <= maxTri; j++)
                {
                    if (!isPrime[j]) 
                        continue;
                    for (int k = 2; k <= maxQuad; k++)
                    {
                        if (!isPrime[k]) 
                            continue;
                        int sum = i * i + j * j * j + k * k * k * k;
                        if(sum> 49_999_999) 
                            break;
                        if (visited.Contains(sum)) 
                            continue;
                        visited.Add(sum);

                        
                    }
                }
            }
            return visited.Count;
        }

        void Sieve(int n)
        {
            isPrime = new bool[n];
            Array.Fill(isPrime, true);
            isPrime[0] = isPrime[1] = false;
            for (int p = 2; p * p <= n; p++)
            {
                if (!isPrime[p]) continue;
                for (int m = p * p; m < n; m += p)
                    isPrime[m] = false;
            }
        }

    }
}    