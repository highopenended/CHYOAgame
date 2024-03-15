using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit
{
    public static class DrawTool
    {
        [STAThread]
        public static void Draw(char[,] myArr_Char, char[,] myArr_ColorsFG, char[,] myArr_ColorsBG)
        {
            using (SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero))
            {
                Random myRand = new Random();

                if (!h.IsInvalid)
                {
                    CharInfo[,] buf = new CharInfo[PUBVAR.windowHeight, PUBVAR.windowWidth];
                    SmallRect rect = new SmallRect() { Left = 0, Top = 0, Right = (short)myArr_Char.GetUpperBound(1), Bottom = (short)myArr_Char.GetUpperBound(0)};
                    
                    for (int i = 0; i < myArr_Char.GetUpperBound(0); ++i)
                    {
                        for (int j = 0; j < myArr_Char.GetUpperBound(1); j++)
                        {
                            byte myChar = (byte)(myArr_Char[i, j]);
                            short myColFG = (short)PUBVAR.GetColorInt(myArr_ColorsFG[i, j].ToString(), true);
                            short myColBG = (short)PUBVAR.GetColorInt(myArr_ColorsBG[i, j].ToString(), false);
                            
                            if (myChar != PUBVAR.omitChar)
                            {
                                buf[i, j].Char.AsciiChar = myChar;
                                buf[i, j].Attributes = (short)(myColFG | (myColBG << 4));
                            } 
                        }
                    }

                    bool b = WriteConsoleOutput(h, buf,
                        new Coord() { X = PUBVAR.windowWidth, Y = PUBVAR.windowHeight },
                        new Coord() { X = 0, Y = 0 },
                        ref rect);
                }
            }
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
            SafeFileHandle hConsoleOutput,
            CharInfo[,] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }
    }
}
