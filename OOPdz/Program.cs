using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPdz
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Введите первую дробь:");
				string input1 = Console.ReadLine();
				Fraction f1 = Fraction.Parse(input1);

				Console.WriteLine("Введите вторую дробь:");
				string input2 = Console.ReadLine();
				Fraction f2 = Fraction.Parse(input2);

				Console.WriteLine($"f1 = {f1}");
				Console.WriteLine($"f2 = {f2}");

				var sum = f1 + f2;
				Console.WriteLine($"{f1} + {f2} = {sum}");

				var diff = f1 - f2;
				Console.WriteLine($"{f1} - {f2} = {diff}");

				var prod = f1 * f2;
				Console.WriteLine($"{f1} * {f2} = {prod}");

				var quot = f1 / f2;
				Console.WriteLine($"{f1} / {f2} = {quot}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}
	}
}
