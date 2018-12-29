using System;
using System.Threading;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Drawing;

namespace NY
{

    class Program
    {
        static Random r2 = new Random();
        /// <summary>
        /// Длина консоли, чтобы определять ее центр
        /// </summary>
        static int Length = Console.BufferWidth - 5;
        /// <summary>
        /// Середина консоли откуда считаем елочку
        /// </summary>
        static int Mid = (Console.BufferWidth - 5) / 2;
        /// <summary>
        /// Вычота консоли - высота елочки
        /// </summary>
        static int Height = 24;

        static SoundPlayer music = new SoundPlayer(Properties.Resources.Метель);
        static SoundPlayer explos = new SoundPlayer(Properties.Resources.Взрыв1);
        /// <summary>
        /// Устанавливает цвет фона
        /// </summary>
        static void SetBackColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < Height + 5; i++)
                for (int j = 0; j < Length; j++)
                    Console.Write(" ");
        }

        static List<MovingPresent> presetns = new List<MovingPresent>();
        static void Explose()
        {
            explos.Load();
            explos.Play();
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("HAPPY NEW YEAR!!");// ЭТО ТИПА ХОРРОР-МОМЕНТ

            Point[] points = new Point[20];
            Point[] speedss = new Point[20];
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = r2.Next(PresentBox.Left, PresentBox.Left + PresentBox.Width);
                points[i].Y = r2.Next(PresentBox.Top, PresentBox.Top + PresentBox.Height);
            }

            for (int i = 0; i < speedss.Length; i++)
            {
                speedss[i].X = r2.Next(-10, 2);
                speedss[i].Y = r2.Next(-4, -1);
            }

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (points[i].X < 0 || points[i].X > Length || points[i].Y < 0 || points[i].Y > 24)
                        continue;

                    Console.SetCursorPosition(points[i].X, points[i].Y);//да
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("*");
                    Thread.Sleep(10);

                    Console.SetCursorPosition(points[i].X, points[i].Y);//да
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("*");

                    points[i].X += speedss[i].X;
                    points[i].Y += speedss[i].Y;

                }
                Thread.Sleep(90);
            }
        }
        /// <summary>
        /// Главная функция - связывает все вместе
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //текст консоли и загрузка цветов
            Console.Title = "Новогоднее дерево";

            Snow.Init(Length, Height);
            Santa.Init(Length / 2, Length - 2, 0, 10);
            //Console.Write(@"𐂂");


            //загрузка и запуск мызки

            music.Load();
            music.PlayLooping();

            Tree.TreeInit(Mid / 2 + 2, Height, Length / 2);

            SetBackColor();
            //Console.Write(@"𐂂");


            Tree.PrintTree();
            PresentBox.Draw();

            //бесконечный цикл
            while (true)
            {

                Santa.Draw();
                foreach (var p in presetns)
                    p.Draw();

                for (int i = 0; i < 10; i++)
                {
                    Tree.ChandeRandPixelInTree();//мигание огоньков
                    Thread.Sleep(50);
                }
                Santa.ReDraw();
                foreach (var p in presetns)
                    p.ReDraw();
                Santa.Move();

                Snow.MoveSnow();
                PresentBox.Draw();
                foreach (var p in presetns)
                    p.Move();

                //Thread.Sleep(500);//пауза

                //по нажатие клавиши - завершение или стирание введенного
                if (Console.KeyAvailable)
                {
                    var c = Console.ReadKey().Key;

                    if (c == ConsoleKey.Enter || c == ConsoleKey.Escape)
                        break;
                    else
                    {
                        if (c == ConsoleKey.Spacebar)
                            presetns.Add(Santa.DropPreset());

                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write("*");
                    }
                }

                bool NeedExplose = false;

                ////
                foreach (var p in presetns)
                {
                    if (p.pos.X > PresentBox.Left && p.pos.X < PresentBox.Left + PresentBox.Width
                        && p.pos.Y > PresentBox.Top && p.pos.Y < PresentBox.Top + PresentBox.Left)
                        NeedExplose = true;
                }
                if (NeedExplose)
                {
                    music.Stop();//выкл музыку
                    Explose();

                    break;
                }

            }
            music.Stop();//выкл музыку можно.
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, 13);
            Console.WriteLine("Счастливого рождества и веселого новго года!");
            Console.ReadKey();
        }
    }
}
