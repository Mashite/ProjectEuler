using System;
using System.Collections.Generic;
using System.Text;

namespace CountingRectangles
{
    internal class Solution
    {
        const long target = 2_000_000;
        public int Solve()
        {
            int limit = 2000;
            int bestWidth = 0;
            int bestHeight = 0;
            long bestCount = 0;
            for (int width = 0; width <= limit; width++) {
                for(int height = 0; height < width; height++) {
                    long count = RectangleCount(width, height);
                    if (Math.Abs(count - target) < Math.Abs(bestCount - target)) {
                        bestCount = count;
                        bestWidth = width;
                        bestHeight = height;
                    }
                }
            }
            return bestWidth * bestHeight;
        }


        public long RectangleCount(int m, int n)
        {
            return ((long)m * (m + 1) * n * (n + 1)) / 4;
        }
    }
}
