using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NY
{
	static class Santa//да, они типа далеко очень
	{
		static Point pos;
		static Point speed;

		static int MaxX, MaxY;
		static int MinX, MinY;
		static public  void Init(int mi_x, int ma_x, int mi_y, int ma_y)
		{
			MaxX = ma_x;
			MinX = mi_x;
			MinY = mi_y;
			MaxY = ma_y;
			pos.X = mi_x;
			pos.Y = mi_y;
			speed.X=1;
			speed.Y = 0;
		}

		static public  void Move()
		{
			if(pos.X+speed.X>MaxX)
			{
				pos.X = MaxX;
				speed.X *= -1;
			}
			else
			if (pos.X + speed.X <MinX)
			{
				pos.X = MinX;
				speed.X *= -1;
			}
			else
			{
				pos.X += speed.X;
			}


			if (pos.Y + speed.Y > MaxY)
			{
				pos.Y = MaxY;
				speed.Y *= -1;
			}
			else
			if (pos.Y + speed.Y < MinY)
			{
				pos.Y = MinY;
				speed.Y *= -1;
			}
			else
			{
				pos.Y += speed.Y;
			}
		}

		static public void Draw()
		{
			Console.SetCursorPosition(pos.X, pos.Y);
			if (speed.X > 0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("**");
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(" . . .");//
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(" + + +");

				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("**");
			}
		}
		static public void ReDraw()
		{
			Console.SetCursorPosition(pos.X, pos.Y);

				Console.ForegroundColor = Console.BackgroundColor;
				Console.Write("        ");

		}

        static public MovingPresent DropPreset()
        {
            return new MovingPresent(pos);
        }

	}
}
