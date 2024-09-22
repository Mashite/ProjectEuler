using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberLetterCounts
{
	public class Solution
	{
		Dictionary<int, string> index = new Dictionary<int, string>
		{
			{1,"one"},
			{2,"two"},
			{3,"three"},
			{4,"four"},
			{5,"five"},
			{6,"six"},
			{7,"seven"},
			{8,"eight"},
			{9,"nine"},
			{10,"ten"},
			{11,"eleven"},
			{12,"twelve"},
			{13,"thirteen"},
			{14,"fourteen"},
			{15,"fifteen"},
			{16,"sixteen"},
			{17,"seventeen"},
			{18,"eighteen"},
			{19,"nineteen"},
			{20,"twenty"},
			{30,"thirty"},
			{40,"forty"},
			{50,"fifty" },
			{60,"sixty"},
			{70,"seventy" },
			{80,"eighty" },
			{90,"ninety" },
			{100,"hundred" },
			{1000,"thousand" }};
		
		public string Solve()
		{
			string count = "";
			for(int i = 1;i<1000;i++)
			{
				int n = i;
				while (n != 0)
				{
					if (n < 20)
					{
						string length = index.Where(p => p.Key == n).First().Value;
						count += length;
						n = n - n;
					}
					else
					{
						if (n >= 100)
						{
							int j = n / 100;
							string length = index.Where(p => p.Key == j).First().Value;
							count += length;
							count += "hundred";//for hundred
							n = n - (j*100);
							if (n>0)
								count+= "and"; //for and
						}
						else
						{
							int j = n;
							n = n - (n % 10);
							string length = index.Where(p => p.Key == n).First().Value;
							count += length;
							n = j - n;
						}

					}
				}

			}
			count += "onethousand";
			return count;
		}

	}
}
