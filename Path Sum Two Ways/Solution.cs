using System;
using System.Collections.Generic;
using System.Text;

namespace Path_Sum_Two_Ways
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
        int[,] memo = new int[80, 80];

        public int Solve()
        {
            grid = ReadMatrix("matrix.txt");
            return FindBest(0, 0);
        }


        public int FindBest(int i,int j)
        {
            if (memo[i, j] != 0)
                return memo[i, j];
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (i == rows - 1 && j == cols - 1)
                return grid[i, j];

            if (i == rows - 1)
                return memo[i, j] = grid[i, j] + FindBest(i, j + 1);

            if (j == cols - 1)
                return memo[i, j] = grid[i, j] + FindBest(i + 1, j);

            return memo[i, j] =
                grid[i, j] + Math.Min(
                    FindBest(i + 1, j),
                    FindBest(i, j + 1)
                );
        }

        public static int[,] ReadMatrix(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int rows = lines.Length;
            int cols = lines[0].Split(',').Length;

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',');

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            return matrix;
        }
    }
}