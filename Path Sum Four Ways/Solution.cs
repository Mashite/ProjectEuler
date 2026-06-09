using System;
using System.Collections.Generic;
using System.Text;

namespace Path_Sum_Four_Ways
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
            ReadMatrix("matrix.txt");
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int[,] dist= new int[rows,cols];

            bool[,] visited = new bool[rows, cols];

            for(int i = 0;i<rows;i++) {
                for(int j= 0;j<cols;j++) {
                    dist[i, j] = int.MaxValue;
                    visited[i, j] = false;
                }
            }

            dist[0, 0] = grid[0, 0];

            int[] dr = new int[] { -1, 1, 0, 0 };
            int[] dc = new int[] { 0, 0, -1, 1 };

            var pq=new PriorityQueue<(int r, int c), int>();
            pq.Enqueue((0, 0), dist[0, 0]);


            while (pq.Count > 0) {

                var current = pq.Dequeue();

                int r = current.r;
                int c = current.c;
                if (visited[r, c])
                    continue;

                visited[r, c] = true;

               if(r ==rows- 1 && c == cols - 1)
                    return dist[r, c];

               for(int k=0;k<4;k++)
                {
                    int nr = r + dr[k];
                    int nc = c + dc[k];

                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        continue;

                    if(visited[nr, nc])
                        continue;

                    int newDist = dist[r, c] + grid[nr, nc];
                    if(newDist < dist[nr, nc])
                    {
                        dist[nr,nc] = newDist;
                        pq.Enqueue((nr, nc), newDist);
                    }


                }

            }
            return -1;

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
