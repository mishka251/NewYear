using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NY
{
    static class Tree
    {

        static int Height, Length, Mid;

        public static void TreeInit(int mid, int h, int l)
        {
            Height = h;
            Length = l;
            Mid = mid;
            Height = h > mid ? mid : h;
            InitColors();
        }
        /// <summary>
        /// Рандом - для генерации случайных чисел
        /// </summary>
        static Random r = new Random();

        /// <summary>
        /// Символ для иголок на ёлке
        /// </summary>
        static char TreeSymbol = '^';
        /// <summary>
        /// Символ для корня ёлочки
        /// </summary>
        static char TreeRootSymbol = '#';
        /// <summary>
        /// Символ для лампочек
        /// </summary>
        static char LightBallSymbol = '*';

        /// <summary>
        /// Основной цвет елочки
        /// </summary>
        static ConsoleColor TreeColor;
        /// <summary>
        /// Цвет "головы" - верхней строчки
        /// </summary>
        static ConsoleColor HeadColor;
        /// <summary>
        /// Цвет корня елочки
        /// </summary>
        static ConsoleColor RootColor;
        /// <summary>
        /// Цвет краев елочки
        /// </summary>
        static ConsoleColor LRColor;
        /// <summary>
        /// Массив цветов для игрущек на елочке
        /// </summary>
        static ConsoleColor[] Colors;

        /// <summary>
        /// Устанавливает цвета по умолчанию
        /// </summary>
        static void SetDefaultColors()
        {
            TreeColor = ConsoleColor.Green;
            RootColor = ConsoleColor.DarkGray;
            HeadColor = ConsoleColor.Red;
            LRColor = ConsoleColor.Green;

            Colors = new ConsoleColor[]
            {
                ConsoleColor.Blue,
                ConsoleColor.DarkGreen,
                ConsoleColor.Yellow,
                ConsoleColor.Red
            };

        }

        /// <summary>
        /// Загрузка цветов из файла
        /// </summary>
        /// <param name="sr">фигня для чтени файлов</param>
        static void LoadColorsFromFile(StreamReader sr)
        {
            ConsoleColor[] AllColors =
            {
                ConsoleColor.Black,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.Gray,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.White
            };

            sr.ReadLine();
            int tr_col = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();
            int root_col = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();
            int lr_col = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();
            int he_col = Convert.ToInt32(sr.ReadLine());
            sr.ReadLine();

            int[] hap_col;
            string[] hap = sr.ReadLine().Split(' ');
            hap_col = new int[hap.Length];

            for (int i = 0; i < hap_col.Length; i++)
                hap_col[i] = Convert.ToInt32(hap[i]);

            TreeColor = AllColors[tr_col];
            RootColor = AllColors[root_col];
            LRColor = AllColors[lr_col];
            HeadColor = AllColors[he_col];
            Colors = new ConsoleColor[hap.Length];
            for (int i = 0; i < hap_col.Length; i++)
                Colors[i] = AllColors[hap_col[i]];
        }
        /// <summary>
        /// Загрузка цветов
        /// </summary>
        static void InitColors()
        {
            if (File.Exists("Colors.txt"))
            {
                try//если можем - то читаем с файла
                {
                    StreamReader sr = new StreamReader("Colors.txt");
                    LoadColorsFromFile(sr);
                    sr.Close();
                }
                catch (Exception)//если получили ошибку
                {
                    SetDefaultColors();//стандартные
                }
            }
            else
            {
                SetDefaultColors();//стандартные
            }
        }



        /// <summary>
        /// Задает консоли случайный цвет текста из массива цветов
        /// </summary>
        static void SetConsoleRandomColor()
        {
            int greenProperty = 10;//типа вероятность основного цвета елочки

            int cas = r.Next(greenProperty + Colors.Length);
            if (cas < greenProperty)
                Console.ForegroundColor = TreeColor;
            else
                Console.ForegroundColor = Colors[cas - greenProperty];
        }

        /// <summary>
        /// Вывод верхушки елочки
        /// </summary>
        static void PrintTreeHead()
        {
            Console.ForegroundColor = HeadColor;
            for (int j = 0; j < Mid; j++)
                Console.Write(" ");
            Console.Write(new string(LightBallSymbol, 3));
            Console.WriteLine();
        }


        /// <summary>
        /// Вывод одной строчки для елочки
        /// </summary>
        /// <param name="level">какой уровень елочки выводим</param>
        /// <param name="length"></param>
        static void PrintTreeLevel(int level)
        {

            for (int j = 0; j < (Mid - level); j++)
                Console.Write(" ");

            Console.ForegroundColor = LRColor;
            Console.Write(TreeSymbol);

            for (int j = 0; j <= 2 * level; j++)
            {
                SetConsoleRandomColor();
                Console.Write(TreeSymbol);
            }
            Console.ForegroundColor = LRColor;
            Console.Write(TreeSymbol);
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод корня елочки
        /// </summary>
        static void PrintTreeRoot()
        {
            Console.ForegroundColor = RootColor;//Вот тут надо менять. 
            for (int i = 0; i < Mid; i++)
                Console.Write(" ");
            Console.WriteLine(new string(TreeRootSymbol, 3));
        }
        /// <summary>
        /// Ставит курсор в случайное место на елочке
        /// </summary>
        static void SetRandPosInTree()
        {
            int Y = 1 + r.Next(Height - 4);
            int X = r.Next(Mid - Y + 1, Mid + Y - 1);
            Console.SetCursorPosition(X, Y);
            Console.CursorVisible = false;
        }
        /// <summary>
        /// Вывод всего дерева
        /// </summary>
        public static void PrintTree()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Height && i < Mid; i++)
            {
                if (i == 0)
                    PrintTreeHead();
                else
                    if (Height - i <= 3)
                    PrintTreeRoot();
                else
                    PrintTreeLevel(i);
            }
        }


        /// <summary>
        /// Меняет цвет случайной звездочки в елочке
        /// </summary>
        public static void ChandeRandPixelInTree()
        {
            SetRandPosInTree();
            SetConsoleRandomColor();
            if (Console.ForegroundColor == TreeColor)
                Console.Write(TreeSymbol);
            else
                Console.Write(LightBallSymbol);
        }

        /// <summary>
        /// Проверка на координаты внутри тела ёлочки
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата У</param>
        /// <returns></returns>
        public static bool InMainTree(int x, int y)
        {
            return (y > 0 && y < Height - 3 && x > (Mid - y - 1) && x < (Mid + y + 3));
        }
        /// <summary>
        /// Проверка на координату внутри корня дерева
        /// </summary>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата У</param>
        /// <returns></returns>
        public static bool InTreeRoot(int x, int y)
        {
            return (y >= Height - 3 && y < Height && x > (Mid - 1) && x < (Mid + 3));
        }
        /// <summary>
        /// Восстановление дерева на кординатах
        /// </summary>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата У</param>
        public static void RestoreTree(int x, int y)
        {
            Console.SetCursorPosition(x, y);

            if (InMainTree(x, y))
            {
                Console.ForegroundColor = TreeColor;
                Console.Write(TreeSymbol);
            }

            if (InTreeRoot(x, y))
            {
                Console.ForegroundColor = RootColor;
                Console.Write(TreeRootSymbol);
            }
        }

    }
}
