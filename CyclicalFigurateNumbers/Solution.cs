using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclicalFigurateNumbers
{
    internal class Solution
    {

        Dictionary<int, List<int>> numbers= new Dictionary<int, List<int>>();
        Dictionary<(int Type, int Value), List<(int Type, int Value)>> graph= new();
        public int Solve()
        {
            numbers.Add(3, new List<int>());
            numbers.Add(4, new List<int>());
            numbers.Add(5, new List<int>());
            numbers.Add(6, new List<int>());
            numbers.Add(7, new List<int>());
            numbers.Add(8, new List<int>());
            FillLists();

            foreach (var kvp in numbers)
            {
                if (kvp.Value.Any(x => x < 1000 || x >= 10000))
                    Console.WriteLine($"Type {kvp.Key} has invalid: " +
                                      string.Join(",", kvp.Value.Where(x => x < 1000 || x >= 10000)));
            }
            BuildGraph();


            foreach (var start in graph.Keys.ToList())
            {
                var path = new List<(int Type, int Value)> { start };
                var usedTypes = new HashSet<int>() { start.Type };
                var usedValues= new HashSet<int>() { start.Value };

                if (Dfs(start, path, usedTypes,usedValues, start) && IsValidCycle(path))
                {
                    return path.Sum(p=>p.Value);
                }
            }



            return 0;
        }

        private bool IsValidCycle(List<(int Type, int Value)> path)
        {
            if (path.Count != 6) return false;
            if (path.Select(p => p.Type).Distinct().Count() != 6) return false;

            if (path.Select(p => p.Value).Distinct().Count() != 6) return false;

            for (int i = 0; i < 6; i++)
            {
                var a = path[i].Value;
                var b = path[(i + 1) % 6].Value;
                if (a % 100 != b / 100) return false;
            }
            return true;
        }

        private bool Dfs(
          (int Type, int Value) current,
          List<(int Type, int Value)> path,
          HashSet<int> usedTypes,
          HashSet<int> usedValues,
          (int Type, int Value) start)
        {
            if (path.Count == 6)
                return (current.Value % 100) == (start.Value / 100);

            if (!graph.TryGetValue(current, out var nexts)) return false;

            foreach (var next in nexts)
            {
                if (usedTypes.Contains(next.Type)) continue;
                if (usedValues.Contains(next.Value)) continue; // ✅ prevent same number reused

                usedTypes.Add(next.Type);
                usedValues.Add(next.Value);
                path.Add(next);

                if (Dfs(next, path, usedTypes, usedValues, start)) return true;

                path.RemoveAt(path.Count - 1);
                usedTypes.Remove(next.Type);
                usedValues.Remove(next.Value);
            }

            return false;
        }


        private void BuildGraph()
        {
            foreach (var kvp in numbers) // kvp.Key = type, kvp.Value = list
            {
                int type = kvp.Key;
                foreach (int value in kvp.Value)
                {
                    int tail = value % 100;
                    if (tail < 10) continue; // optional but very helpful

                    var nexts = numbers
                        .Where(x => x.Key != type)
                        .SelectMany(x => x.Value.Select(v => (Type: x.Key, Value: v)))
                        .Where(n => n.Value / 100 == tail)
                        .ToList();

                    graph[(type, value)] = nexts;
                }
            }
        }

       

        public void FillLists()
        {
            #region triangle
            for (int n = 1; ; n++)
            {
                int v =n * (n + 1) / 2;
                if (v >= 10000) break;
                if(v>=1000)
                    numbers[3].Add(v);              
            }
            #endregion


            #region square
            for (int n = 1; ; n++)
            {
                int v = n * n;
                if (v >= 10000) break;
                if (v >= 1000)
                    numbers[4].Add(v);          
            }           
            #endregion

            #region pentagonal
            for (int n = 1; ; n++)
            {
                int v = n * ((3*n) -1) / 2;
                if (v >= 10000) break;
                if (v >= 1000)
                    numbers[5].Add(v);
                

            }
            #endregion

            #region hexagonal
            for (int n = 1; ; n++)
            {
                int v = n * ((2 * n )- 1);
                if (v >= 10000) break;
                if (v >= 1000)
                    numbers[6].Add(v);       
            }
            #endregion


            #region heptagonal
            for (int n = 1; ; n++)
            {
                int v = n * ((5 * n )- 3) / 2;
                if (v >= 10000) break;
                if (v >= 1000)
                    numbers[7].Add(v);
            }
            #endregion


            #region octagonal
            for (int n = 1; ; n++)
            {
                int v = n * ((3 * n) -2);
                if (v >= 10000) break;
                if (v >= 1000)
                    numbers[8].Add(v);
            }
            #endregion
        }
    }
}
