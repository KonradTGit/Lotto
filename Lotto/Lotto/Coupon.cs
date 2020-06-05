using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotto
{
	class Coupon
	{
		public List<int[]> CouponList { get; set; } = new List<int[]>();

		public int[] CheckCoupon(int[] drawn)
		{
			int[] win = new int[4];
			int i = 0;
			Console.WriteLine("\n\nYOUR COUPON: ");
			foreach (int[] ticket in CouponList)
			{
				i++;
				Console.Write(i + ": ");
				int hit = 0;
				foreach (var number in ticket)
				{
					if (drawn.Contains(number))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write(number + ", ");
						Console.ResetColor();
						hit++;
					}
					else
					{
						Console.Write(number + ", ");
					}
				}
				switch (hit)
				{
					case 3:
						win[0]++;
						break;
					case 4:
						win[1]++;
						break;
					case 5:
						win[2]++;
						break;
					case 6:
						win[3]++;
						break;
				}
				Console.WriteLine(" - HIT {0}/6", hit);
			}
			return win;
		}

		public void ShowCoupon()
		{
			if (CouponList.Count == 0)
			{
				Console.WriteLine("You don't use any coupons.");
			}
			else
			{
				int i = 0;
				Console.Write("Your coupon: \n");
				foreach (int[] ticket in CouponList)
				{
					i++;
					Console.Write(i + ":\n ");
					foreach (int number in ticket)
					{
						Console.Write(number + ", ");
					}
					Console.WriteLine();
				}
			}
		}
	}
}
