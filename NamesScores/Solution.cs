using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesScores
{
    public class Solution
    {
        public int Solve()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "names.txt");
            int total = 0;

            try
            {
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("\"", "");
                List<string> names = fileContent.Split(',').ToList();
                names = names.OrderBy(line => line).ToList();

                for (int i = 0; i < names.Count; i++)
                {
                    int sum = 0;
                    for (int j = 0; j < names[i].Length; j++)
                        sum += names[i][j] - 'A' + 1;

                    total = total + (sum * (i + 1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return total;
        }
    }
}
