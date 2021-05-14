using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.HAL;
using Pwr = Cosmos.System.Power;
namespace TWIx86
{
    class Core
    {
        public static List<string> history = new List<string>();
        public static bool Running = true;
        public static string version = "0.3";
        public static readonly Random rnd = new Random();
        public static ConsoleColor fgColor = ConsoleColor.White;
        public static ConsoleColor bgColor = ConsoleColor.Black;
        public static ConsoleColor fgOriginal = Console.ForegroundColor;
        public static ConsoleColor bgOriginal = Console.BackgroundColor;

        public static void bootSequence()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("[OK] Imported Namespace   System                       . . .");
            Console.WriteLine("[OK] Imported Class       System.Collections.Generic   . . .");
            Console.WriteLine("[OK] Imported Class       System.Text                  . . .");
            Console.WriteLine("[OK] Imported Namespace   Cosmos                       . . .");
            Console.WriteLine("[OK] Imported Class       Cosmos.HAL                   . . .");
            Console.WriteLine("[OK] Imported Namespace   TWIx86                       . . .");
            Console.WriteLine("[OK] Imported Class       TWIx86.Kernel                . . .");
            Console.WriteLine("[OK] Imported Class       TWIx86.Commands              . . .");
            Console.WriteLine("[OK] Imported Class       TWIx86.Core                  . . .\n\nPlease wait...");
            Wait(1);
            dispLogo("Starting TWIx86 . . .");
            Wait(8);
            resetColors();
            Console.Clear();
            Console.WriteLine("\nWelcome to TWIx86! For help, type \"HELP\".");
        }

        internal static void runProgram(string app)
        {
            Console.WriteLine("Not yet implemented...");
        }

        public static void Wait(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                // Loop round
            }
        }

        public static void shutDown()
        {
            Console.Clear();
            dispLogo("TWIx86 is shutting down . . .");
            Running = false;
            Wait(4);
            Pwr.Shutdown();
        }

        public static void restart()
        {
            Console.Clear();
            dispLogo("TWIx86 is restarting . . .");
            Running = false;
            Wait(4);
            Pwr.Reboot();
        }

        public static void clearScreen()
        {
            Console.Clear();
        }

        public static void writeCenteredText(string text)
        {
            string textToEnter = text;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }

        public static bool IsAllDigits(string s)
        {
            foreach (char c in s) if (!char.IsDigit(c)) return false;
            return true;
        }
        public static string StringToHex(string hexstring)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in hexstring)
            { sb.Append(Convert.ToInt32(t).ToString("x")); }
            return sb.ToString();
        }

        public static void showHistoryContents()
        {
            foreach (string command in history)
            {
                var x = StringToHex(command.SplitInParts(2).ToString());
                Console.WriteLine(x);
            }
        }
        public static void resetColors()
        {
            Console.BackgroundColor = Core.bgOriginal;
            Console.ForegroundColor = Core.fgOriginal;
            Core.bgColor = Core.bgOriginal;
            Core.fgColor = Core.fgOriginal;
        }
        public static bool askYesNo(string question)
        {
            Console.Write("\n" + question + " [Y/N]"); var x = Console.ReadKey(false);
            switch (x.Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
                default:
                    break;
            }
            return false;
        }

        public static void dispLogo(string caption, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = color;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.WriteLine(@"          _____         _     _    _            _     _ _____           ");
            Console.WriteLine(@"         |_   _|       | |   | |  | |          | |   | |_   _|          ");
            Console.WriteLine(@"           | | ___  ___| |__ | |  | | ___  _ __| | __| | | | _ __   ___ ");
            Console.WriteLine(@"           | |/ _ \/ __| '_ \| |/\| |/ _ \| '__| |/ _` | | || '_ \ / __|");
            Console.WriteLine(@"           | |  __| (__| | | \  /\  | (_) | |  | | (_| |_| || | | | (__ ");
            Console.WriteLine(@"           \_/\___|\___|_| |_|\/  \/ \___/|_|  |_|\__,_|\___|_| |_|\___|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n           " + caption);
        }

        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }

        public static void startClock()
        {
            var timer1 = new Timer(_ => {
                var currentX = Console.CursorLeft; var currentY = Console.CursorTop;
                Console.SetCursorPosition(0, 0);
                userInterface.drawRectangle(0, 0, 80, 1, ConsoleColor.DarkCyan);
                userInterface.WriteString(0, 0, RTC.Hour + ":" + RTC.Minute + ":" + RTC.Second, ConsoleColor.White, ConsoleColor.DarkCyan);
            }, null, 0, 2000);
        }
    }
}