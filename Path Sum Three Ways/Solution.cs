using System;
using System.Collections.Generic;
using System.Text;

namespace Path_Sum_Three_Ways
{
    internal class Solution
    {
        int[,] grid = new int[,]
         {
                { 131, 673, 234, 103, 18 },
                { 201, 96, 342, 965, 150 },
                { 630, 803, 746, 422, 111 },
                { 537, 699, 497, 121, 956 },
                { 805, 732, 524, 37, 331 }
         };
        public int Solve()
        {
           // ReadMatrix("matrix.txt");

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int[] cost = new int[rows];

            // First column: you can start from any row
            for (int r = 0; r < rows; r++)
                cost[r] = grid[r, 0];

            for (int c = 1; c < cols; c++)
            {
                // First, move right from previous column
                for (int r = 0; r < rows; r++)
                    cost[r] += grid[r, c];

                // Move down
                for (int r = 1; r < rows; r++)
                    cost[r] = Math.Min(cost[r], cost[r - 1] + grid[r, c]);

                // Move up
                for (int r = rows - 2; r >= 0; r--)
                    cost[r] = Math.Min(cost[r], cost[r + 1] + grid[r, c]);
            }

            return cost.Min();
        }


        public void ReadMatrix(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Split(',').Length;
            grid = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = int.Parse(values[j]);
                }
            }
        }
    }
}
