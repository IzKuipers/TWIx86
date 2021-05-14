using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Core = TWIx86.Core;
using Commands = TWIx86.Commands;
using Cosmos.HAL;
using System.IO;
namespace TWIx86
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Core.bootSequence();
            Core.startClock();
        }

        protected override void Run()
        {

            if (Core.Running != false)
            {
                Commands.getUserInput();
            }
        }

    }
}
