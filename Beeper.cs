using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Chyoa
{

    public static class Beeper
    {
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

    }
}
