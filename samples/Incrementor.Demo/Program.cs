using System;
using IncrementorLib;

namespace Samples.IncrementorDemo
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var inc = new Incrementor();        // максимум по умолчанию: int.MaxValue
			Console.WriteLine(inc.GetNumber()); // 0

			inc.SetMaximumValue(3);             // допустимо: 0,1,2; на 3 — сброс
			for (int i = 0; i < 5; i++)
			{
				inc.IncrementNumber();
				Console.WriteLine(inc.GetNumber()); // 1, 2, 0, 1, 2
			}
		}
	}
}