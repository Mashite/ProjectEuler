// See https://aka.ms/new-console-template for more information
using PrimePairSets;

//Solution solution = new Solution();
//int res = solution.Solve();
Console.WriteLine("Hello, World!");


var edges = new (int, int)[] { (0, 1), (0, 2), (1, 2), (3, 4) };
var g = Example.BuildAdjList(5, edges);

Console.WriteLine("Adjacency List:");
foreach (var kv in g.OrderBy(k => k.Key))
    Console.WriteLine($"{kv.Key}: [{string.Join(", ", kv.Value)}]");

Console.WriteLine();

Console.WriteLine("Components:");
foreach (var comp in Example.ConnectedComponents(g))
    Console.WriteLine(string.Join(",", comp));

Console.WriteLine("Shortest 0->2: " + Example.ShortestPathLength(g, 0, 2));
Console.WriteLine("HasCycle: " + Example.HasCycle(g));

var clique3 = Example.FindClique(g, 3);
Console.WriteLine("Clique size 3: " + (clique3 == null ? "none" : string.Join(",", clique3)));


