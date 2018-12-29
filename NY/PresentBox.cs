using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NY
{
	static class PresentBox
	{
		public static int Left, Top, Width, Height;


		static ConsoleColor BodyColor = ConsoleColor.Red;
		static ConsoleColor BorderColor = ConsoleColor.Yellow;
		static char BoxSymbol = '#';

		static PresentBox()
		{
			Width = 10;
			Height = 4;
			Left = Console.BufferWidth - Width - 2;
			Top = 24 - Height-1;//Console.BufferHeight - Height;
		}

		public static void Draw()
		{
			Console.ForegroundColor = BodyColor;
			//Console.SetCursorPosition(Left, Top);
			for (int x = 0; x < Width; x++)
				for (int y = 0; y < Height; y++)
				{
					Console.SetCursorPosition(Left + x, Top + y);
					Console.Write(BoxSymbol);
				}



			Console.ForegroundColor = BorderColor;

			for (int x = 0; x < Width; x++)
			{
				Console.SetCursorPosition(Left + x, Top);
				Console.Write(BoxSymbol);
				Console.SetCursorPosition(Left + x, Top + Height);
				Console.Write(BoxSymbol);

				Console.SetCursorPosition(Left + x, Top + Height/2);
				Console.Write(BoxSymbol);
			}

			for (int y = 0; y <= Height; y++)
			{
				Console.SetCursorPosition(Left, Top + y);
				Console.Write(BoxSymbol);
				Console.SetCursorPosition(Left + Width, Top + y);
				Console.Write(BoxSymbol);
				Console.SetCursorPosition(Left + Width/2, Top + y);
				Console.Write(BoxSymbol);
			}

			Console.SetCursorPosition(Left + Width / 2 - 2, Top - 1);
			string tmp = new string(BoxSymbol, 2);
			Console.WriteLine(tmp + " " + tmp);


		}


	}
}
