using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
	internal class Point
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Point(double x, double y)
		{
			X = x;
			Y = y;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}

		public Point()
		{
		}

		~Point()
		{
			Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
		}

		public static Point operator +(Point left, Point right)
		{
			return new Point(left.X + right.X, left.Y + right.Y);
		}

		public static double operator -(Point left, Point right)
		{
			double deltaX = left.X - right.X;
			double deltaY = left.Y - right.Y;
			return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
		}

		public void Print()
		{
			Console.WriteLine($"X = {X}, Y = {Y}");
		}
	}
}
