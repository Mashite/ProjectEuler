using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicographicPermutations
{
    public class Solution
    {
        public int Solve()
        {
            int[] array = new int[] { 9,8,7,6,5,4,3,2,1,0};
                int sum = 0;
            int total = 999999;
            while (total!=0)
            {
                int temp = 1;
                for (int i = 1; i <= 10; i++)
                {
                    if ( temp * i > total )
                    {
                        int index = (total / temp); 
                        temp = index * temp;
                        total = total - temp;

                        int tempVal= array[i-index-1];

                        for(int j=i-index-1;j<i-1;j++)                        
                            array[j] = array[j+1];
                        array[i-1] = tempVal;

                        Console.WriteLine( string.Join(", ", array) +"    "+index + " " +(i-1)+ " " +temp + " " + total  +" " + sum);
                        break;
                    }
                    temp=temp * i;
                }             
                sum += temp;              
            }

            return 0;
        }


    }
}
