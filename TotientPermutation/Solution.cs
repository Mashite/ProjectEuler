

namespace TotientPermutation
{
    internal class Solution
    {
        bool[] primes = new bool[10_000_0000];
        public int Solve()
        {
            Array.Fill(primes, true);
            Sieve();
            double minRatio = int.MaxValue;
            int bestN = 0;

            for (int i = 2; i < 10_000_000; i++)
            {
                int phi = Totient(i);
                if(i.ToString().Length != phi.ToString().Length) continue;
                bool equal = Permutaiton(i, phi);

                if (equal)
                {
                    double ratio = (double)i / phi;

                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        bestN = i;
                    }
                }

            }

            return bestN;
        }

        bool Permutaiton(int n, int p)
        {
            IOrderedEnumerable<char> ns = n.ToString().ToCharArray().Order();

            IOrderedEnumerable<char> ps = p.ToString().ToCharArray().Order();

            if (ns.SequenceEqual(ps))
                return true;
            return false;

        }

        void Sieve()
        {
            primes[0] = false;
            primes[1] = false;
            for (int i = 2; i * i < primes.Length; i++)
            {
                if (!primes[i]) continue;
                for (int j = i * i; j < primes.Length; j += i)
                {
                    primes[j] = false;
                }
            }
        }
        int Totient(int n)
        {
            int result = n;
            int temp = n;

            for (int p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            if (temp > 1)
                result -= result / temp;

            return result;
        }
    }
}
