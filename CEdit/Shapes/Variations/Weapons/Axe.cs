using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Weapons
{
    class Axe
    {
        public Axe()
        {
            arr_Chars = PUBVAR.GetCharArr(lAxe);
            arr_ColorsFG = PUBVAR.GetCharArr(lAxe_ColorsFG);
            arr_ColorsBG = PUBVAR.GetCharArr(lAxe_ColorsBG);

            charConverter(arr_Chars);
        }

        public char[,] arr_Chars = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        public char[,] arr_ColorsFG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        public char[,] arr_ColorsBG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];


        void charConverter(char[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1); j++)
                {
                    switch (arr[i, j])
                    {

                        case '|':
                            arr[i, j] = Convert.ToChar(245);
                            break;

                        case '-':
                            arr[i, j] = Convert.ToChar(223);
                            break;

                        case '_':
                            arr[i, j] = Convert.ToChar(220);
                            break;

                        case 'X':
                            arr[i, j] = Convert.ToChar(176);
                            break;

                        case '8':
                            arr[i, j] = Convert.ToChar(178);
                            break;

                        case '9':
                            arr[i, j] = Convert.ToChar(177);
                            break;

                        case '/':
                            arr[i, j] = Convert.ToChar(221);
                            break;

                        case '+':
                            arr[i, j] = Convert.ToChar(222);
                            break;

                        case ']':
                            arr[i, j] = Convert.ToChar(219);
                            break;

                        case 'O':
                            arr[i, j] = Convert.ToChar(153);
                            break;

                        default:
                            // Do Nothing
                            break;
                    }

                }
            }
        }

        // ASCII - Sword
        readonly List<string> lAxe = new List<string>()
        {
            "       __              ",
            "   ___ 88____________  ",
            "  +888+99/888888888888 ",
            " +8888+99/888888888888/",
            "+88888+99/88888888888/ ",
            "8-   +899]8888888888/  ",
            "      |88    -88888/   ",
            "      |88     -88/     ",
            "      |88      -        ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      |88              ",
            "      /]]/             ",
            "     -]]]-             "
        };
        readonly List<string> lAxe_ColorsFG = new List<string>()
        {
            "       Yy          o   ",
            "   OOOOYyOOOOOOOOOOOo  ",
            "  OOOOOOoOOOOOOOOOOOoo ",
            " OOOOOOOoOOOOOOOOOOOooo",
            "OOOOOOOOoOOOOOOOOOOOoo ",
            "OO   OOOoOOOOOOOOOOoo  ",
            "      YYY    OOOOOoo   ",
            "      YYY    OOOoo     ",
            "      YYY      O       ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      OoOO             ",
            "     OOOOO             "
        };
        readonly List<string> lAxe_ColorsBG = new List<string>()
        {
            "                       ",
            "   ____  ____________  ",
            "  +888   o888888888888 ",
            " +8888   o888888888888/",
            "+88888   o88888888888/ ",
            "8-        8888888888/  ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "        y              ",
            "                       ",
            "                       "
        };
    }
}
