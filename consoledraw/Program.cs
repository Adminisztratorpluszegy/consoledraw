using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDrawApp
{
    class Program
    {
        static char[,] screen = new char[25, 80];
        static int cursorX = 0, cursorY = 0;
        static ConsoleColor currentColor = ConsoleColor.White;
        static string currentChar = "█";
        static ConsoleColor cursorColor = ConsoleColor.White;
        static void InitScreen()
        {
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 80; x++)
                {
                    screen[y, x] = ' ';
                }
            }
        }
        static void DrawScreen()
        {
            for (int y = 0; y < 25; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 80; x++)
                {
                    Console.ForegroundColor = currentColor;
                    Console.Write(screen[y, x]);
                }
            }
            Console.SetCursorPosition(cursorX, cursorY);
            Console.BackgroundColor = cursorColor;
            Console.Write(" ");
            Console.ResetColor();
            Console.SetCursorPosition(cursorX, cursorY);
            Console.CursorVisible = true;
        }
        static void SetColor(ConsoleColor color)
        {
            currentColor = color;
            Console.ForegroundColor = color;
        }

        static void SetCursorColor(ConsoleColor color)
        {
            cursorColor = color;
        }
        static void DrawChar(string c)
        {
            for (int i = 0; i < c.Length; i++)
            {
                screen[cursorY, cursorX + i] = c[i];
            }
        }
        static void MoveCursor(int dx, int dy)
        {
            int newX = cursorX + dx, newY = cursorY + dy;
            if (newX >= 0 && newX < 80 && newY >= 0 && newY < 25)
            {
                cursorX = newX;
                cursorY = newY;
            }
        }
        static void DisplaySettings()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Color: " + currentColor.ToString());
            Console.WriteLine("Cursor: " + cursorX + ", " + cursorY);
            Console.WriteLine("Character: " + currentChar);
            Console.WriteLine("Cursor Color: " + cursorColor.ToString());
        }
        static void Main(string[] args)
        {
            InitScreen();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        MoveCursor(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveCursor(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveCursor(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveCursor(1, 0);
                        break;
                    case ConsoleKey.Spacebar:
                        DrawChar(currentChar);
                        break;
                    case ConsoleKey.D0:
                        SetColor(ConsoleColor.Black);
                        break;
                    case ConsoleKey.D1:
                        SetColor(ConsoleColor.Red);
                        break;
                    case ConsoleKey.D2:
                        SetColor(ConsoleColor.Green);
                        break;
                    case ConsoleKey.D3:
                        SetColor(ConsoleColor.Yellow);
                        break;
                    case ConsoleKey.D4:
                        SetColor(ConsoleColor.Blue);
                        break;
                    case ConsoleKey.D5:
                        SetColor(ConsoleColor.Magenta);
                        break;
                    case ConsoleKey.D6:
                        SetColor(ConsoleColor.Cyan);
                        break;
                    case ConsoleKey.D7:
                        SetColor(ConsoleColor.DarkGreen);
                        break;
                    case ConsoleKey.D8:
                        SetColor(ConsoleColor.DarkYellow);
                        break;
                    case ConsoleKey.D9:
                        SetColor(ConsoleColor.DarkRed);
                        break;
                    case ConsoleKey.NumPad1:
                        currentChar = "█";
                        break;
                    case ConsoleKey.NumPad2:
                        currentChar = "▓";
                        break;
                    case ConsoleKey.NumPad3:
                        currentChar = "▒";
                        break;
                    case ConsoleKey.NumPad4:
                        currentChar = "░";
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                DrawScreen();
                DisplaySettings();
            }
        }
    }
}