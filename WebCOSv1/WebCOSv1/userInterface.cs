using System;
using System.Collections.Generic;
using System.Text;

namespace TWIx86
{
    class userInterface
    {
        public static void drawRectangle(int x, int y, int width, int height, ConsoleColor color)
        {
            var currentX = Console.CursorLeft;
            var currentY = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            for (var i=0;i<height;i++)
            {
                Console.BackgroundColor = color;
                for (var ii=0;ii<width;ii++)
                {
                    Console.Write(' ');
                }
                Console.SetCursorPosition(x, Console.CursorTop + 1);
            }
            Console.SetCursorPosition(currentX, currentY);
        }

        public static void WriteString(int x, int y, string text, ConsoleColor color, ConsoleColor background = ConsoleColor.Black)
        {
            var currentX = Console.CursorLeft;
            var currentY = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.SetCursorPosition(currentX, currentY);
        }
        public static void writeChar(int x, int y, char text, ConsoleColor color, ConsoleColor background = ConsoleColor.Black)
        {
            var currentX = Console.CursorLeft;
            var currentY = Console.CursorTop;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.SetCursorPosition(currentX, currentY);
        }
    }
}
