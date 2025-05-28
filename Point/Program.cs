using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var p1 = new Point(0, 0);
			var p2 = new Point(3, 4);

			double distance = p1 - p2;

			Console.WriteLine($"Расстояние между точками: {distance}");
		}
	}
}
