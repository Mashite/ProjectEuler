namespace FindtheLongestConsecutiveSequence
{
    internal class Solution
    {
        public int Solve()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };

            return LongestConsecutive(nums);
        }

        static int LongestConsecutive(int[] nums)
        {
            int longestStreak = 0;
            HashSet<int> numbers = new HashSet<int>(nums);

            foreach (int num in numbers)
            {
                if (!numbers.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numbers.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }
    }
}