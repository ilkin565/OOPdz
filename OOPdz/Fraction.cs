using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPdz
{
	internal class Fraction
	{
		public double Numerator { get; set; }
		public double Denominator { get; set; }

		public Fraction(double numerator = 0, double denominator = 1)
		{
			if (denominator == 0)
				throw new ArgumentException("Знаменатель не может быть нулевым");
			Numerator = numerator;
			Denominator = denominator;
			reduce();
		}

		public static Fraction operator +(Fraction a, Fraction b)
		{
			return new Fraction(
				a.Numerator * b.Denominator + b.Numerator * a.Denominator,
				a.Denominator * b.Denominator).reduce();
		}

		public static Fraction operator -(Fraction a, Fraction b)
		{
			return new Fraction(
				a.Numerator * b.Denominator - b.Numerator * a.Denominator,
				a.Denominator * b.Denominator).reduce();
		}

		public static Fraction operator *(Fraction a, Fraction b)
		{
			return new Fraction(
				a.Numerator * b.Numerator,
				a.Denominator * b.Denominator).reduce();
		}

		public static Fraction operator /(Fraction a, Fraction b)
		{
			if (b.Numerator == 0)
				throw new DivideByZeroException("Невозможно разделить на нулевую дробь");
			return new Fraction(
				a.Numerator * b.Denominator,
				a.Denominator * b.Numerator).reduce();
		}

		public static bool operator ==(Fraction a, Fraction b)
		{
			if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
				return true;
			if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
				return false;
			return Math.Abs(a.Numerator * b.Denominator - b.Numerator * a.Denominator) < 1e-10;
		}

		public static bool operator !=(Fraction a, Fraction b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return $"{Numerator}/{Denominator}";
		}

		public Fraction reduce()
		{
			int gcd = GCD((int)Math.Abs(Numerator), (int)Math.Abs(Denominator));
			if (gcd != 0)
			{
				Numerator /= gcd;
				Denominator /= gcd;
			}
			if (Denominator < 0)
			{
				Denominator = -Denominator;
				Numerator = -Numerator;
			}
			return this;
		}

		private int GCD(int a, int b)
		{
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}

		public static Fraction Parse(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
				throw new ArgumentException("Входная строка пуста");

			input = input.Trim();

			if (input.Contains("/"))
			{
				var parts = input.Split('/');
				if (parts.Length != 2)
					throw new FormatException("Неверный формат дроби");

				double numerator = double.Parse(parts[0].Trim());
				double denominator = double.Parse(parts[1].Trim());

				return new Fraction(numerator, denominator);
			}
			else
			{
				double numerator = double.Parse(input);
				return new Fraction(numerator);
			}
		}
	}
}