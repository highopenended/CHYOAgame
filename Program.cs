using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Chyoa.Shared;



namespace Chyoa
{
    class Program
    {
        static void Main()
        {
            // Maximize the screen
            Startup.Maximizer.MaximizeScreen();

            // Set Timers
            DrawTimer.SetTimer();

            CEdit.Shapes.Variations.Animations.ShapeMaker_AnimatedThing FireMaker = new CEdit.Shapes.Variations.Animations.ShapeMaker_AnimatedThing();

            Startup.OpeningScreen.Display_Fire();

            Console.ReadKey();            

            Startup.MainUI_DisplayMaker.Make_UI();

            //MusicTimer.SetTimer();

            // Start the Game
            Sets.GameManager GameMaster = new Sets.GameManager();
            GameMaster.StartGame();

            Console.ReadKey();
        }
    }
}