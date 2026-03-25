using System;
using System.Collections.Generic;
using System.Text;

namespace Magic5gonRing
{    
    internal class Solution
    {
        string maxString = "";
        public string Solve()
        {
            int[] numbers = {1,2,3,4,5,6,7,8,9, 10 };
           
            Permute(numbers, 0);

            return maxString;   
        }

        void Permute(int[] arr, int start)
        {
            if (start == arr.Length)
            {
                int[] outer = arr.Take(5).ToArray();
                int[] inner = arr.Skip(5).Take(5).ToArray();
                if (outer[0]!=outer.Min()) 
                    return;
                if (!outer.Contains(10)) 
                    return;

                int sum1 = outer[0] + inner[0] + inner[1];
                int sum2 = outer[1] + inner[1] + inner[2];
                int sum3 = outer[2] + inner[2] + inner[3];
                int sum4 = outer[3] + inner[3] + inner[4];
                int sum5 = outer[4] + inner[4] + inner[0];

                if (!(sum1 == sum2 && sum2 == sum3 && sum3 == sum4 && sum4 == sum5))
                    return;

                string result =
                    $"{outer[0]}{inner[0]}{inner[1]}" +
                    $"{outer[1]}{inner[1]}{inner[2]}" +
                    $"{outer[2]}{inner[2]}{inner[3]}" +
                    $"{outer[3]}{inner[3]}{inner[4]}" +
                    $"{outer[4]}{inner[4]}{inner[0]}";

                if (string.Compare(result, maxString, StringComparison.Ordinal) > 0)
                {
                    maxString = result;
                }

                return;
            }

            for (int i = start; i < arr.Length; i++)
            {
                Swap(arr, start, i);
                Permute(arr, start + 1);
                Swap(arr, start, i); 
            }
        }

        void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
