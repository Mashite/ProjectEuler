using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePairSets
{
    internal class Example
    {
        public static Dictionary<int, List<int>> BuildAdjList(int n, (int u, int v)[] edges)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < n; i++)
                graph[i] = new HashSet<int>();

            foreach (var (u, v) in edges)
            {
                graph[u].Add(v);
                graph[v].Add(u);
            }

            return graph.ToDictionary(
                kv => kv.Key,
                kv => kv.Value.OrderBy(x => x).ToList()
            );
        }

        // 2) Connected components (DFS)
        public static List<List<int>> ConnectedComponents(Dictionary<int, List<int>> g)
        {
            var visited = new HashSet<int>();
            var components = new List<List<int>>();

            foreach (int start in g.Keys.OrderBy(x => x))
            {
                if (visited.Contains(start)) continue;

                var stack = new Stack<int>();
                var component = new List<int>();

                stack.Push(start);
                visited.Add(start);

                while (stack.Count > 0)
                {
                    int u = stack.Pop();
                    component.Add(u);

                    foreach (int v in g[u])
                    {
                        if (visited.Add(v))
                            stack.Push(v);
                    }
                }

                component.Sort();
                components.Add(component);
            }

            return components;
        }

        // 3) Shortest path length (BFS)
        public static int ShortestPathLength(Dictionary<int, List<int>> g, int start, int goal)
        {
            if (start == goal) return 0;

            var queue = new Queue<int>();
            var dist = new Dictionary<int, int>();

            queue.Enqueue(start);
            dist[start] = 0;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();

                foreach (int v in g[u])
                {
                    if (dist.ContainsKey(v)) continue;

                    dist[v] = dist[u] + 1;
                    if (v == goal)
                        return dist[v];

                    queue.Enqueue(v);
                }
            }

            return -1;
        }

        // 4) Cycle detection (undirected)
        public static bool HasCycle(Dictionary<int, List<int>> g)
        {
            var visited = new HashSet<int>();

            foreach (int start in g.Keys)
            {
                if (visited.Contains(start)) continue;

                var stack = new Stack<(int node, int parent)>();
                stack.Push((start, -1));
                visited.Add(start);

                while (stack.Count > 0)
                {
                    var (u, parent) = stack.Pop();

                    foreach (int v in g[u])
                    {
                        if (v == parent) continue;

                        if (visited.Contains(v))
                            return true;

                        visited.Add(v);
                        stack.Push((v, u));
                    }
                }
            }

            return false;
        }

        // 5) Find any k-clique (DFS + intersection pruning)
        public static List<int>? FindClique(Dictionary<int, List<int>> g, int k)
        {
            foreach (var kv in g)
                kv.Value.Sort();

            foreach (int start in g.Keys.OrderBy(x => x))
            {
                var candidates = g[start].Where(x => x > start).ToList();
                var result = DfsClique(new List<int> { start }, candidates, g, k);
                if (result != null)
                    return result;
            }

            return null;
        }

        public static List<int>? DfsClique(
            List<int> chosen,
            List<int> candidates,
            Dictionary<int, List<int>> g,
            int k)
        {
            if (chosen.Count == k)
                return new List<int>(chosen);

            if (candidates.Count < k - chosen.Count)
                return null;

            for (int i = 0; i < candidates.Count; i++)
            {
                int next = candidates[i];

                var remaining = candidates.Skip(i + 1).ToList();
                var nextCandidates = IntersectSorted(remaining, g[next]);

                chosen.Add(next);
                var found = DfsClique(chosen, nextCandidates, g, k);
                if (found != null)
                    return found;

                chosen.RemoveAt(chosen.Count - 1);
            }

            return null;
        }

        public static List<int> IntersectSorted(List<int> a, List<int> b)
        {
            var result = new List<int>();
            int i = 0, j = 0;

            while (i < a.Count && j < b.Count)
            {
                if (a[i] == b[j])
                {
                    result.Add(a[i]);
                    i++;
                    j++;
                }
                else if (a[i] < b[j])
                    i++;
                else
                    j++;
            }

            return result;
        }
    }
}
