using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NY
{
	static class Snow
	{

		static List<Point> Points;//места снежинок
		static int MaxSnowCount = 40;

		static int Length, Height;
		static Random r2 = new Random();

		public static void Init(int len, int h)
		{
			Length = len;
			Height = h;
			Points = new List<Point>();
		}

		static void Clear()
		{
			for (int i = 0; i < Points.Count; i++)
			{
				int x = Points[i].X;
				int y = Points[i].Y;
				Console.SetCursorPosition(x, y);
				Console.Write(" ");
				Tree.RestoreTree(x, y);
			}
		}

		static void Move()
		{
			for (int i = 0; i < Points.Count; i++)
			{
				Point p = Points[i];
				p.X += r2.Next(-2, 2);
				p.Y++;
				Points[i] = p;

				if (p.Y > Height || p.X < 0 || p.X > Length)
				{
					Points.RemoveAt(i);
					i--;
				}

			}
		}

		static void Draw()
		{
			Console.ForegroundColor = ConsoleColor.White;

			for (int i = 0; i < Points.Count; i++)
			{
				Console.SetCursorPosition(Points[i].X, Points[i].Y);
				Console.Write("*");
			}

		}

		public static void MoveSnow()
		{
			Clear();

			Move();

			if (Points.Count < MaxSnowCount)
				Points.Add(new Point(r2.Next(Length), 3));

			Draw();

		}
	}
}
