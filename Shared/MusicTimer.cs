using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chyoa.Shared
{
    public static class MusicTimer
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

            //Play_IntroBit();

            Beeper.Beep(1500, 500);
            Beeper.Beep(1200, 500);
            Beeper.Beep(1000, 1000);

            Beeper.Beep(500, 50);
            Beeper.Beep(400, 50);
            Beeper.Beep(300, 50);

            Beeper.Beep(1000, 200);
            Beeper.Beep(1200, 200);
            Beeper.Beep(1500, 1000);

            Beeper.Beep(1600, 500);
            Beeper.Beep(1400, 500);
            Beeper.Beep(1500, 1000);

            aTimer.Start();


            void Play_IntroBit()
            {
                int counter = 1;


                for (; ;)
                {
                    Beeper.Beep(150, 100);

                    counter++;

                    
                    Beeper.Beep(500, 100);
                    Beeper.Beep(400, 100);
                    Beeper.Beep(300, 100);

                    Beeper.Beep(225, 100);
                    Beeper.Beep(300, 100);
                    Beeper.Beep(450, 100);
                    
                }
            }





        }
    }
}
