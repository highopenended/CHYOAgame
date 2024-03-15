using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Weapons
{
    public class Hammer
    {
        public Hammer()
        {
            arr_Chars = PUBVAR.GetCharArr(lHammer);
            arr_ColorsFG = PUBVAR.GetCharArr(lHammer_ColorsFG);
            arr_ColorsBG = PUBVAR.GetCharArr(lHammer_ColorsBG);

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
                                             
                        default:
                            // Do Nothing
                            break;
                    }

                }
            }
        }

        // ASCII - Sword
        readonly List<string> lHammer = new List<string>()
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
        readonly List<string> lHammer_ColorsFG = new List<string>()
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
        readonly List<string> lHammer_ColorsBG = new List<string>()
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
