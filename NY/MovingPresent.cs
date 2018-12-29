using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NY
{
    class MovingPresent
    {
       public  Point pos;
        Point speed;
        ConsoleColor col;
        public Predicate<Point> Stop = (pos) => pos.Y >= 20;
        ConsoleColor[] Possible_colors = 
            {
            ConsoleColor.Red,
            ConsoleColor.White,
            ConsoleColor.Green,
            ConsoleColor.Blue
        };
        public MovingPresent(Point p, Point speed)
        {
            pos = p;
            this.speed = speed;
        }

        public MovingPresent(Point p)
        {
            pos.X = p.X;
            pos.Y = p.Y;
            Random r = new Random();
            col = Possible_colors[r.Next(Possible_colors.Length)];
            speed = new Point(0, 1);
        }

        public void Move()
        {
           if(!Stop(pos))
            {
                pos.X += speed.X;
                pos.Y += speed.Y;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
            //да, но случилась проблема dhjlt d rjjhlbyfnf[  ща отойду я тут
            //ты здесь? чет странное Ага и это другой подарок. хд Правильно
            Console.SetCursorPosition(pos.X - 1, pos.Y+1);
            Console.ForegroundColor = col;
            Console.Write("###");
            Console.SetCursorPosition(pos.X - 1, pos.Y+2);
            //да, рисую еще подарки
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
            Console.ForegroundColor = col;
            Console.Write("#");
            Console.SetCursorPosition(pos.X - 1, pos.Y+3);
            Console.Write("###");
            //теперь осталось сделать одну вещь 
            //сюрприз при попадании подарком в большой подарок. Только вот какой?
            //ты читаешь мысли? ща покурим(травку) и запилим
        }
        public void ReDraw()
        {
           

            Console.ForegroundColor = Console.BackgroundColor;
            Console.SetCursorPosition(pos.X-1, pos.Y);
            Console.Write("   ");
            Console.SetCursorPosition(pos.X - 1, pos.Y +1);
            Console.Write("   ");
            Console.SetCursorPosition(pos.X - 1, pos.Y +2);
            Console.Write("   ");
            Console.SetCursorPosition(pos.X - 1, pos.Y +3);
            Console.Write("   ");

        }
    }
}
