using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa
{
    public static class PUBVAR
    {
        public static readonly short windowWidth = (short)(Console.LargestWindowWidth - 5);
        public static readonly short windowHeight = (short)Console.LargestWindowHeight;
        public static readonly short windowLeft = (short)0;
        public static readonly short windowBottom = (short)0;               

        public static int threadTimeSpeed = 30;

        public const char omitChar = '$';


        /// <summary>
        /// Converts the color letter to a color Int from the colors enum
        /// </summary>
        /// <param name="myColorString"> string (single char) that represents the color </param>
        /// <param name="FG_BG"> FG and BG have different default colors </param>
        /// <returns></returns>
        public static int GetColorInt(string myColorString, bool FG_BG = true)
        {

            switch (myColorString)
            {
                case "X":
                    return (int)Colors.Black;
                case "W":
                    return (int)Colors.White;
                case "o":
                    return (int)Colors.Gray;
                case "O":
                    return (int)Colors.DarkGray;
                case "r":
                    return (int)Colors.Red;
                case "R":
                    return (int)Colors.DarkRed;
                case "b":
                    return (int)Colors.Blue;
                case "B":
                    return (int)Colors.DarkBlue;
                case "g":
                    return (int)Colors.Green;
                case "G":
                    return (int)Colors.DarkGreen;
                case "y":
                    return (int)Colors.Yellow;
                case "Y":
                    return (int)Colors.DarkYellow;
                case "c":
                    return (int)Colors.Cyan;
                case "C":
                    return (int)Colors.DarkCyan;
                case "m":
                    return (int)Colors.Magenta;
                case "M":
                    return (int)Colors.DarkMagenta;
                default:
                    if (FG_BG)  { return (int)Colors.White; }
                    else        { return (int)Colors.Black; }
            }
        }


        /// <summary>
        /// Converts the color from the color enum into an Int
        /// </summary>
        /// <param name="myColorString"> string (single char) that represents the color </param>
        /// <param name="FG_BG"> FG and BG have different default colors </param>
        /// <returns></returns>
        public static int GetColorInt(Colors myColor, bool FG_BG = true)
        {
            switch (myColor)
            {
                case Colors.Black:
                    return (int)Colors.Black;
                case Colors.White:
                    return (int)Colors.White;
                case Colors.Gray:
                    return (int)Colors.Gray;
                case Colors.DarkGray:
                    return (int)Colors.DarkGray;
                case Colors.Red:
                    return (int)Colors.Red;
                case Colors.DarkRed:
                    return (int)Colors.DarkRed;
                case Colors.Blue:
                    return (int)Colors.Blue;
                case Colors.DarkBlue:
                    return (int)Colors.DarkBlue;
                case Colors.Green:
                    return (int)Colors.Green;
                case Colors.DarkGreen:
                    return (int)Colors.DarkGreen;
                case Colors.Yellow:
                    return (int)Colors.Yellow;
                case Colors.DarkYellow:
                    return (int)Colors.DarkYellow;
                case Colors.Cyan:
                    return (int)Colors.Cyan;
                case Colors.DarkCyan:
                    return (int)Colors.DarkCyan;
                case Colors.Magenta:
                    return (int)Colors.Magenta;
                case Colors.DarkMagenta:
                    return (int)Colors.DarkMagenta;
                default:
                    if (FG_BG) { return (int)Colors.White; }
                    else { return (int)Colors.Black; }
            }
        }


        public static char GetColorChar(Colors myColor, bool FG_BG = true)
        {
            switch (myColor)
            {
                case Colors.Black:
                    return 'X';

                case Colors.White:
                    return 'W';

                case Colors.Gray:
                    return 'o';

                case Colors.DarkGray:
                    return 'O';

                case Colors.Red:
                    return 'r';

                case Colors.DarkRed:
                    return 'R';

                case Colors.Blue:
                    return 'b';

                case Colors.DarkBlue:
                    return 'B';

                case Colors.Green:
                    return 'g';

                case Colors.DarkGreen:
                    return 'G';

                case Colors.Yellow:
                    return 'y';

                case Colors.DarkYellow:
                    return 'Y';

                case Colors.Cyan:
                    return 'c';

                case Colors.DarkCyan:
                    return 'C';

                case Colors.Magenta:
                    return 'm';

                case Colors.DarkMagenta:
                    return 'M';
                    
                default:
                    if (FG_BG) { return 'W'; }
                    else { return 'X'; }
            }
        }
        

        public static char[,] GetCharArr(List<string> listOfStrings)
        {
            int height, width;

            height = listOfStrings.Count;
            width = height > 0 ? listOfStrings[0].Length : 0;


            char[,] returnArr = new char[height + 1, width + 1];

            for (int i = 0; i < height; i++)
            {
                string textLine = listOfStrings[i];
                char[] charRow = textLine.ToCharArray();
                for (int j = 0; j < width; j++)
                {
                    if (charRow[j] != ' ')
                    {
                        if (charRow[j] != omitChar)
                                { returnArr[i, j] = charRow[j]; }
                        else    { returnArr[i, j] = ' '; }
                    }
                }
            }
            return returnArr;
        }

        static string alphaLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string allowedSymbols = "'-, ";
        static char[] allowedCharacters = (alphaLetters + allowedSymbols).ToCharArray();

        public static bool checkIfAllowedCharacter(char checkChar)
        {
            for (int i = 0; i < allowedCharacters.Length; i++)
            {
                if(checkChar == allowedCharacters[i])
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Constantly checking for user key input without interrupting the draw timer
        /// </summary>
        /// <returns></returns>
        public static ConsoleKeyInfo? MyReadKey()
        {
            var task = Task.Run(() => Console.ReadKey(true));
            bool read = task.Wait(-1);
            if (read) return task.Result;
            return null;
        }
        

        public enum Colors
        {
            Black,
            DarkBlue,
            DarkGreen,
            DarkCyan,
            DarkRed,
            DarkMagenta,
            DarkYellow,
            Gray,
            DarkGray,
            Blue,
            Green,
            Cyan,
            Red,
            Magenta,
            Yellow,
            White,
            None
        }
    }
}
