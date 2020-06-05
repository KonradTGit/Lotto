using System;
using System.Linq;

namespace Lotto
{
	class LotteryTicket
	{
		public int[] useLotteryTicket()
		{
			int[] numbers = new int[6];
			for (int i = 0; i < numbers.Length; i++)
			{
				Console.Clear();
				Console.Write("Circled numbers: ");
				foreach (int l in numbers)
				{
					if (l > 0)
					{
						Console.Write(l + ", ");
					}
				}
				Console.WriteLine("\n\nChose number from 1 to 49:");
				Console.Write("{0}/6: ", i + 1);
				int number;
				bool good = int.TryParse(Console.ReadLine(), out number);
				if (good && number >= 1 && number <= 49 && !numbers.Contains(number))
				{
					numbers[i] = number;
				}
				else
				{
					Console.WriteLine("Sorry, wrong number.");
					i--;
					Console.ReadKey();
				}

			}
			Array.Sort(numbers);
			return numbers;
		}
	}
}
