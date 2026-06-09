using System;
using System.Collections.Generic;
using System.Text;

namespace PasscodeDerivation
{
    internal class Solution
    {
        List<string> sequences = new List<string>() { "319", "680", "180", "690", "129", "620", "762", "689", "762", "318", "368", "710", "720", "710", "629", "168", "160", "689", "716", "731", "736", "729", "316", "729", "729", "710", "769", "290", "719", "680", "318", "389", "162", "289", "162", "718", "729", "319", "790", "680", "890", "362", "319", "760", "316", "729", "380", "319", "728", "716" };

        public int Solve()
        {
            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();

            foreach (var seq in sequences)
            {
                for (int i = 0; i < seq.Length - 1; i++)
                {
                    char from = seq[i];
                    char to = seq[i + 1];
                    if (!graph.ContainsKey(from))
                        graph[from] = new HashSet<char>();
                    graph[from].Add(to);
                }

                if (!graph.ContainsKey(seq[seq.Length - 1]))
                    graph[seq[seq.Length - 1]] = new HashSet<char>();
            }

            string passcode = "";

            while(graph.Count > 0)
            {
                char next = '\0';
                foreach (var kvp in graph)
                {
                    if (kvp.Value.Count == 0)
                    {
                        next = kvp.Key;
                        break;
                    }
                }
                if (next == '\0')
                    throw new Exception("No valid passcode found");
                passcode += next;
                graph.Remove(next);
                foreach (var kvp in graph)
                {
                    kvp.Value.Remove(next);
                }
            }

            return int.Parse(passcode.Reverse().ToArray());
        }
    }
}
