using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Network;

namespace TWIx86
{
    class Commands
    {
        public static void getUserInput()
        {
            Console.Write("\n[~] TWIx86 $> ");
            var x = Console.ReadLine();
            var y = x.Split(" ");
            var z = y[0].ToLower();
            
            string a = "";
            string b = "";
            for (int i = 0; i < y.Length; i++)
            {
                a += y[i] + " ";
            }
            for (int i = 1; i < y.Length; i++)
            {
                b += y[i] + " ";
            }

            Core.history.Add(a);
            switch (z)
            {
                case "shutdown": Core.shutDown(); break;
                case "restart": Core.restart();break;
                case "": break;
                case "cls": case "clr":Core.clearScreen(); break;
                case "ver": ver(); break;
                case "help": 
                    if (y.Length == 1)
                    {
                        help();
                    } else
                    {
                        dispHelp(y[1]);
                    }
                break;
                case "resetcolor":Core.resetColors();Core.clearScreen();break;
                case "color":
                    try {
                        color(int.Parse(y[1]), int.Parse(y[2]));
                    } catch {
                        Console.WriteLine("ERROR: Input is not in correct format. Usage: COLOR (int)[fg] (int)[bg]");
                    };
                    break;
                case "hty":
                case "history":
                    string histarg = "";
                    for (int i = 1; i < y.Length; i++)
                    {
                        histarg += y[i] + " ";
                    }
                    showHistory(histarg);
                    break;
                case "beep":
                    Console.Beep();
                    break;
                case "random":
                    randomNumbers();
                    break;
                case "disp":
                    Console.WriteLine("Character Resolution: " + Console.WindowWidth + "x" + Console.WindowHeight + " @ 16 colors");
                    break;
                case "crash":
                    Console.WriteLine("WARNING! Continuing WILL lock up your device.");
                    if (Core.askYesNo("Do you want to continue?") == true)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Core.dispLogo("It's now safe to turn off your device.",ConsoleColor.Red);
                        Console.WriteLine(Core.StringToHex("command".SplitInParts(2).ToString()));
                    } else
                    {
                        Console.WriteLine("\nFunction \"crash\" in \"TWIx86.Commands.getUserInput\" has been cancelled.");
                    }
                    break;
                case "run":
                    try
                    {
                        Core.runProgram(y[1]);
                    } catch
                    {
                        Console.WriteLine("An error occured while trying to open the specified app.");
                    }
                    
                    break;
                case "classes":
                    Console.WriteLine("Loaded classes:");
                    Console.WriteLine("System");
                    Console.WriteLine("System.Collections.Generic");
                    Console.WriteLine("System.Text");
                    Console.WriteLine("TWIx86");
                    Console.WriteLine("TWIx86.Core");
                    Console.WriteLine("TWIx86.Kernel");
                    Console.WriteLine("TWIx86.Commands");
                    Console.WriteLine("TWIx86.stringExt");
                    break;
                case "bootseq":
                    Core.Running = false;
                    Core.bootSequence();
                    Core.Running = true;
                    break;
                case "print":
                    print(b);
                    break;
                case "calc":
                    TWIx86.Programs.Calculator.Draw();
                    break;
                default: commandNotFound(z); break;
            }
        }

        public static void commandNotFound(string input)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The entered command, \"{input}\", was not recognized.");
            Console.ForegroundColor = Core.fgColor;
            Console.BackgroundColor = Core.bgColor;
        }

        public static void ver()
        {
            Console.WriteLine("TWIx86, version " + Core.version);
        }

        public static void help()
        {
            Console.WriteLine("\nList of built-in commands:");
            Console.WriteLine("SHUTDOWN         Shuts down TWIx86 and turns off your computer");
            Console.WriteLine("RESTART          Shuts down TWIx86 and restarts your computer");
            Console.WriteLine("CLS,CLR          Clears the screen and sets the cursor to 0,0");
            Console.WriteLine("VER              Shows the version of TWIx86 that you are running");
            Console.WriteLine("HELP             Displays a list of built-in commands");
            Console.WriteLine("HISTORY,HTY      Displays a list of previously entered commands");
            Console.WriteLine("BEEP             Plays a tone from the PC Speaker");
            Console.WriteLine("RANDOM           Generates a random number");
            Console.WriteLine("DISP             Displays the character resolution and color depth");
            Console.WriteLine("CRASH            Crashes your computer");
            Console.WriteLine("RUN              Runs a built-in program (not yet implemented)");
            Console.WriteLine("CLASSES          Shows a list of TWIx86 classes");
            Console.WriteLine("BOOTSEQ          Plays the boot animation");
            Console.WriteLine("PRINT            Echoes a specified string");
            Console.WriteLine("\nFor more information about a command: enter: \"HELP [COMMAND]\"");
        }

        public static void color(int fg, int bg)
        {
            if ((fg < 16 || bg < 16) && (fg > -1 || bg > -1))
            {
                Core.resetColors();
                bool clear = true;
                switch (bg)
                {
                    case 0: Console.BackgroundColor = Core.bgColor = ConsoleColor.Black; break;
                    case 1: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkBlue; break;
                    case 2: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkGreen; break;
                    case 3: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkCyan; break;
                    case 4: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkRed; break;
                    case 5: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkMagenta; break;
                    case 6: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkYellow; break;
                    case 7: Console.BackgroundColor = Core.bgColor = ConsoleColor.Gray; break;
                    case 8: Console.BackgroundColor = Core.bgColor = ConsoleColor.DarkGray; break;
                    case 9: Console.BackgroundColor = Core.bgColor = ConsoleColor.Blue; break;
                    case 10: Console.BackgroundColor = Core.bgColor = ConsoleColor.Green; break;
                    case 11: Console.BackgroundColor = Core.bgColor = ConsoleColor.Cyan; break;
                    case 12: Console.BackgroundColor = Core.bgColor = ConsoleColor.Red; break;
                    case 13: Console.BackgroundColor = Core.bgColor = ConsoleColor.Magenta; break;
                    case 14: Console.BackgroundColor = Core.bgColor = ConsoleColor.Yellow; break;
                    case 15: Console.BackgroundColor = Core.bgColor = ConsoleColor.White; break;
                    case 16: Console.BackgroundColor = Core.bgColor = ConsoleColor.Black; break;
                    default: Console.WriteLine("ERROR: Invalid background color!\nEntered: " + bg);Console.BackgroundColor = Core.bgColor; break;
                }
                switch (fg)
                {
                    case 0: Console.ForegroundColor = Core.fgColor = ConsoleColor.Black; break;
                    case 1: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkBlue; break;
                    case 2: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkGreen; break;
                    case 3: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkCyan; break;
                    case 4: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkRed; break;
                    case 5: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkMagenta; break;
                    case 6: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkYellow; break;
                    case 7: Console.ForegroundColor = Core.fgColor = ConsoleColor.Gray; break;
                    case 8: Console.ForegroundColor = Core.fgColor = ConsoleColor.DarkGray; break;
                    case 9: Console.ForegroundColor = Core.fgColor = ConsoleColor.Blue; break;
                    case 10: Console.ForegroundColor = Core.fgColor = ConsoleColor.Green; break;
                    case 11: Console.ForegroundColor = Core.fgColor = ConsoleColor.Cyan; break;
                    case 12: Console.ForegroundColor = Core.fgColor = ConsoleColor.Red; break;
                    case 13: Console.ForegroundColor = Core.fgColor = ConsoleColor.Magenta; break;
                    case 14: Console.ForegroundColor = Core.fgColor = ConsoleColor.Yellow; break;
                    case 15: Console.ForegroundColor = Core.fgColor = ConsoleColor.White; break;
                    case 16: Console.ForegroundColor = Core.fgColor = ConsoleColor.White; break;
                    default: Console.WriteLine("ERROR: Invalid background color!\nEntered: " + fg); Console.ForegroundColor = Core.fgColor; break;
                }
                if (clear) Core.clearScreen();
            }
            else { dispHelp("color"); }
        }

        public static void dispHelp(string forCommand)
        {
            switch (forCommand.ToLower())
            {
                case "shutdown":
                    Console.WriteLine(
                        "Shuts down TWIx86 and turns off your computer.\n\n" +
                        "Usage: SHUTDOWN"
                    );

                    break;
                case "restart":
                    Console.WriteLine(
                        "Shuts down TWIx86 and restarts off your computer.\n\n" +
                        "Usage: RESTART"
                    );

                    break;
                case "cls":
                case "clr":
                    Console.WriteLine(
                        "Clears the screen and resets the cursor position (to 0,0).\n\n" +
                        "Usage: CLS or CLR"
                    );
                    break;
                case "ver":
                    Console.WriteLine(
                        "Displays the current version of TWIx86\n\n" +
                        "Usage: VER"
                    );
                    break;
                case "help":
                    Console.WriteLine(
                        "Displays a list of available commands, or information about a specific command.\n\n" +
                        "Usage: HELP [COMMAND]"
                    );
                    break;
                case "resetcolor":
                    Console.WriteLine(
                        "Resets the foreground and background colors to their respective states.\n\n" +
                        "Usage: RESETCOLOR"
                    );
                    break;
                case "color":
                    Console.WriteLine(
                        "Changes the color of CLOS to a specified color.\n\n" +
                        "Usage: COLOR [FOREGROUND] [BACKGROUND]\n\n" +
                        "for each of the foreground and background arguments, there are 16 colors you can apply.\n" +
                        "Here is a list of them:\n\n" +
                        "0  Black           8  Dark Gray\n" +
                        "1  Dark Blue       9  Blue\n" +
                        "2  Dark Green      10 Green\n" +
                        "3  Dark Cyan       11 Cyan\n" +
                        "4  Dark Red        12 Red\n" +
                        "5  Dark Magenta    13 Magenta\n" +
                        "6  Dark Yellow     14 Yellow\n" +
                        "7  Gray            15 White\n" +
                        "\n" +
                        "Example: Entering \"COLOR 4 0\" will display dark red text on a black background."
                    );
                    break;
                case "history":
                case "hty":
                    Console.WriteLine(
                        "Shows a list of all entered commands, or clears the history if specified.\n\n" +
                        "Usage: HISTORY [CLEAR] or HTY [CLEAR]"
                    );
                    break;
                case "beep":
                    Console.WriteLine(
                        "Plays a tone from the PC speaker\n\n" +
                        "Usage: BEEP"
                    );
                    break;
                case "random":
                    Console.WriteLine(
                        "Generates a random number\n\n" +
                        "Usage: RANDOM"
                    );
                    break;
                case "disp":
                    Console.WriteLine(
                        "Displays information about your display, such as the character resolution.\n\n" +
                        "Usage: DISP"
                    );
                    break;
                case "crash":
                    Console.WriteLine(
                        "Crashes your device if confirmed.\n\n" +
                        "Usage: CRASH"
                    );
                    break;
                case "run":
                    Console.WriteLine(
                        "Runs a specified, built-in program\n\n" +
                        "Usage: RUN [PROGRAM]"
                    );
                    break;
                case "classes":
                    Console.WriteLine(
                        "Displays a list of TWIx86 classes.\n\n" +
                        "Usage: CLASSES"
                    );
                    break;
                case "bootseq":
                    Console.WriteLine(
                        "Plays the boot sequence\n\n" +
                        "Usage: BOOTSEQ"
                    );
                    break;
                case "print":
                    Console.WriteLine(
                        "Echoes a specified string\n\n" +
                        "Usage: PRINT [STRING]"
                    );
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid help article!\n\nfor a list of commands, just type HELP without any arguments.");
                    break;
            }
        }

        public static void showHistory(string arg)
        {
            if (arg == "clear ")
                Core.history.Clear();
            try { Core.history.Remove(Core.history[Core.history.Count - 1]); } catch { }
            if (arg == "clear ")
            {
                Console.WriteLine("\nThe history bus is cleared using the \"CLEAR\" argument.");
            }
            else
            {
                if (Core.history.Count == 0)
                {
                    Console.WriteLine("There is nothing in the history bus.");
                }
                else
                {
                    Console.WriteLine("CLOS command history:\n");
                    foreach (string com in Core.history)
                    {
                        Console.WriteLine(com);
                    }
                    Console.WriteLine($"\nThere are {Core.history.Count.ToString()} item(s) in the history bus.");
                }
                Console.WriteLine("\nTo clear the history, enter \"HISTORY CLEAR\", or \"HTY CLEAR\"");
            }
        }
        
        public static void randomNumbers()
        {
            byte[] bytes1 = new byte[100];
            byte[] bytes2 = new byte[100];
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            rnd1.NextBytes(bytes1);
            rnd2.NextBytes(bytes2);

            Console.WriteLine("Set 1:");
            for (int ctr = bytes1.GetLowerBound(0);
                 ctr <= bytes1.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes1[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Set 2:");
            for (int ctr = bytes2.GetLowerBound(0);
                 ctr <= bytes2.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes2[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
        }
        

        public static void RandomNumber()
        {
            byte[] bytes1 = new byte[100];
            byte[] bytes2 = new byte[100];
            Random rnd1 = new Random();
            Random rnd2 = new Random();

            rnd1.NextBytes(bytes1);
            rnd2.NextBytes(bytes2);

            Console.WriteLine("First Series:");
            for (int ctr = bytes1.GetLowerBound(0);
                 ctr <= bytes1.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes1[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Second Series:");
            for (int ctr = bytes2.GetLowerBound(0);
                 ctr <= bytes2.GetUpperBound(0);
                 ctr++)
            {
                Console.Write("{0, 5}", bytes2[ctr]);
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
