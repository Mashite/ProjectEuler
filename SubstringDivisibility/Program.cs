// See https://aka.ms/new-console-template for more information
using SubstringDivisibility;
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
Solution solution = new Solution();
long res = solution.Solve();
sw.Stop();

Console.WriteLine($"Result: {res}");
Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");
Console.WriteLine("Hello, World!");
