using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
namespace TWIx86.Programs
{
    class Calculator
    {
        public static void Draw()
        {
            Core.Running = false;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            //Start drawing//
            setToolbarStatus("Drawing... Please wait...", ConsoleColor.Cyan, ConsoleColor.White);
            userInterface.drawRectangle(29, 6, 22, 13, ConsoleColor.White);
            userInterface.drawRectangle(31, 7, 18, 3, ConsoleColor.Blue);
            userInterface.drawRectangle(31, 11, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(36, 11, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(41, 11, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(46, 11, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(31, 13, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(36, 13, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(41, 13, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(46, 13, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(31, 15, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(36, 15, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(41, 15, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(46, 15, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(31, 17, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(36, 17, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(41, 17, 3, 1, ConsoleColor.Blue);
            userInterface.drawRectangle(46, 17, 3, 1, ConsoleColor.Blue);
            userInterface.WriteString(32, 11, "1", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(37, 11, "2", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(42, 11, "3", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(47, 11, "/", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(32, 13, "4", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(37, 13, "5", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(42, 13, "6", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(47, 13, "*", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(32, 15, "7", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(37, 15, "8", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(42, 15, "9", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(47, 15, "+", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(32, 17, "0", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(37, 17, ".", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(42, 17, "-", ConsoleColor.Yellow, ConsoleColor.Blue);
            userInterface.WriteString(47, 17, "=", ConsoleColor.Yellow, ConsoleColor.Blue);
            //Stop drawing///
            setToolbarStatus("TWIx86 Calculator", ConsoleColor.Cyan, ConsoleColor.White);
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            Draw();
            
        }

        public static void stopCalculator()
        {
            Core.Running = true;
            Console.ForegroundColor = Core.fgColor;
            Console.BackgroundColor = Core.bgColor;
            Console.Clear();
        }

        public static void setToolbarStatus(string text,ConsoleColor bg, ConsoleColor fg)
        {
            userInterface.drawRectangle(0, 0, 80, 1, bg);
            userInterface.WriteString(0, 0, text, fg, bg);
        }
    }
}
