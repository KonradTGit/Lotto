using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lotto
{
	internal class Program
	{
		static int cumulation;
		static int START = 30;
		static Random random = new Random();

		static void Main(string[] args)
		{
			LotteryTicket lotteryTicket = new LotteryTicket();
			Coupon newCoupon = new Coupon();

			do
			{
				int money = START;
				int day = 0;
				ConsoleKey choose;
				do
				{
					cumulation = random.Next(2, 33) * 1000000;
					day++;
					int tickets = 0;
					do
					{
						Console.Clear();
						Console.WriteLine("Day: {0}", day);
						Console.WriteLine("Welcome to the Lotto game, today you can win {0}", cumulation);
						Console.Write("\nYour account balance: {0}$", money);
						Console.WriteLine("");
						newCoupon.ShowCoupon();

						//MENU
						if (money >= 4 && tickets < 6)
						{
							Console.WriteLine("\n1 - Buy one lottery ticket - 4$ [{0}/6]", tickets + 1);
						}
						Console.WriteLine("2 - Check coupon - Lotto draw");
						Console.WriteLine("3 - End of the Game.");
						//MENU
						choose = Console.ReadKey().Key;
						if (choose == ConsoleKey.D1 && money > 4 && tickets < 6)
						{
							newCoupon.CouponList.Add(lotteryTicket.UseLotteryTicket());
							money -= 4;
							tickets++;
						}

					} while (choose == ConsoleKey.D1);
					Console.Clear();
					if (newCoupon.CouponList.Count > 0)
					{
						int win = check(newCoupon);
						if (win > 0)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("You WIN {}", win);
							Console.ResetColor();
							money += win;

						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Unfortunately, you didn't win.");
							Console.ResetColor();
						}
					}
					else
					{
						Console.WriteLine("You don't have tickets for this draw.");
					}
					Console.WriteLine("Enter - continue.");
					Console.ReadKey();


				} while (money >= 4 && choose != ConsoleKey.D3);

				Console.Clear();
				Console.WriteLine("Day {0}. \n End of the game, your score is: {1}", day, money - START);
				Console.WriteLine("Press Enter to continue.");
			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
		private static int check(Coupon coupon)
		{
			int win = 0;
			int[] drawn = new int[6];
			for (int i = 0; i < drawn.Length; i++)
			{
				int ticket = random.Next(1, 50);
				if (!drawn.Contains(ticket))
				{
					drawn[i] = ticket;
				}
				else
				{
					i--;
				}
			}
			Array.Sort(drawn);
			Console.WriteLine("Drawn number are:");
			foreach (int number in drawn)
			{
				Console.Write(number + ", ");
			}
			int[] hit = coupon.CheckCoupon(drawn);
			Console.WriteLine();
			int value;
			if (hit[0] > 0)
			{
				value = hit[0] * 24;
				Console.WriteLine("3 Hits: {0} + {1}$", hit[0], value);
				win += value;
			}
			if (hit[1] > 0)
			{
				value = hit[1] * random.Next(100, 301);
				Console.WriteLine("4 Hits: {0} + {1}$", hit[1], value);
				win += value;
			}
			if (hit[2] > 0)
			{
				value = hit[2] * random.Next(4000, 8001);
				Console.WriteLine("5 Hits: {0} + {1}$", hit[2], value);
				win += value;
			}
			if (hit[3] > 0)
			{
				value = hit[3] * cumulation / (hit[3] + random.Next(0, 5));
				Console.WriteLine("6 Hits: {0} + {1}$", hit[3], value);
				win += value;
			}
			return win;
		}
	}
}
