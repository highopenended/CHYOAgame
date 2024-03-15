using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Chyoa.CEdit.Shapes.Variations.TextBoxShapes.StringEdit;

namespace Chyoa.Shared
{
    public static class DrawTimer
    {
        private static readonly double updateInterval = PUBVAR.threadTimeSpeed;

        private static Timer aTimer;

        public static void SetTimer()
        {
            // Create a timer with a defined interval
            aTimer = new Timer(updateInterval);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        public static void StopTimer()
        {
            aTimer.Stop();
        }
               
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Update the arrays of characters and colors
            CEdit.DisplayLists.GetUpdatedArrays(out char[,] arrChars, out char[,] arrColorsFG, out char[,] arrColorsBG);

            // Redraw the console to reflect the updated arrays
            CEdit.DrawTool.Draw(arrChars, arrColorsFG, arrColorsBG);
            EventColumn_Update.Update_On_Tick();

            aTimer.Start();
        }
    }
}
