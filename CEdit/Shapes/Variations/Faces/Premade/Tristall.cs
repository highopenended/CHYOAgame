using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Faces.Premade
{
    public static class Tristall
    {
        static Tristall()
        {
            Initialize_ListsToCharArrays();
        }

        static void Initialize_ListsToCharArrays()
        {
            char[,] arr1 = PUBVAR.GetCharArr(lSpeaking1_Chars);
            char[,] arr2 = PUBVAR.GetCharArr(lSpeaking1_Chars);


            UpdateArrayChars(arr1);
            UpdateArrayChars(arr2);
            



            lSpeaking_Chars_arr.Add(arr1);
            lSpeaking_Chars_arr.Add(arr2);

            lSpeaking_ColorsFG_arr.Add(PUBVAR.GetCharArr(lSpeaking1_ColorsFG));
            lSpeaking_ColorsFG_arr.Add(PUBVAR.GetCharArr(lSpeaking2_ColorsFG));

            lSpeaking_ColorsBG_arr.Add(PUBVAR.GetCharArr(lSpeaking1_ColorsBG));
            lSpeaking_ColorsBG_arr.Add(PUBVAR.GetCharArr(lSpeaking2_ColorsBG));





            void UpdateArrayChars(char[,] arrToUpdate)
            {
                for (int i = 0; i < arrToUpdate.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < arrToUpdate.GetUpperBound(1); j++)
                    {
                        switch (arrToUpdate[i, j])
                        {
                            case '@':
                                arrToUpdate[i, j] = Convert.ToChar(220);
                                break;

                            case '<':
                                arrToUpdate[i, j] = Convert.ToChar(174);
                                break;

                            case '>':
                                arrToUpdate[i, j] = Convert.ToChar(175);
                                break;

                            case '{':
                                arrToUpdate[i, j] = Convert.ToChar(244);
                                break;

                            case '}':
                                arrToUpdate[i, j] = Convert.ToChar(245);
                                break;

                            case '(':
                                arrToUpdate[i, j] = Convert.ToChar(221);
                                break;

                            case ')':
                                arrToUpdate[i, j] = Convert.ToChar(219);
                                break;

                            case '8':
                                arrToUpdate[i, j] = Convert.ToChar(236);
                                break;

                            case 't':
                                arrToUpdate[i, j] = Convert.ToChar(176);
                                break;

                            case 'Q':
                                arrToUpdate[i, j] = Convert.ToChar(232);
                                break;


                            case 'f':
                                arrToUpdate[i, j] = Convert.ToChar(190);
                                break;

                            case 'L':
                                arrToUpdate[i, j] = Convert.ToChar(220);
                                break;

                            case 'v':
                                arrToUpdate[i, j] = Convert.ToChar(251);
                                break;

                            case '=':
                                arrToUpdate[i, j] = Convert.ToChar(240);
                                break;
                        }
                    }
                }
            }
        }

        public static List<char[,]> Get_ListOfArrays_Chars()    { return lSpeaking_Chars_arr; }
        public static List<char[,]> Get_ListOfArrays_ColorsFG() { return lSpeaking_ColorsFG_arr; }
        public static List<char[,]> Get_ListOfArrays_ColorsBG() { return lSpeaking_ColorsBG_arr; }

        // Lists of the char arrays for multiple frames of movement 
        static readonly List<char[,]> lSpeaking_Chars_arr = new List<char[,]>();
        static readonly List<char[,]> lSpeaking_ColorsFG_arr = new List<char[,]>();
        static readonly List<char[,]> lSpeaking_ColorsBG_arr = new List<char[,]>();


        // Chars
        static readonly List<string> lSpeaking1_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$_```````;,--,_$$$$$",
            "$$(`$$$$$$$$;$$$$$`,$$$",
            "$$}$$$$$$$$$$$$$$$$;}$$",
            "$$|;$/``--__$$$$$$$(}$$",
            "$$-$/$_>>>$$v_<<<_$|-$$",
            "$$$|$$\\(@)}$${(@)/(|$$$",
            "$$(|$$$$$$$|$$$$$$(|$$$",
            "$$$(|$$$$$c..$$#$$$|$$$",
            "$$$$|$$$$_____$$$$|$$$$",
            "$$$$$|$#$($`$#$$$|$$$$$",
            "$$$$$$$__(______$$$$$$$",
            "$$$$$L==L____L==L$$$$$$",
            "LttttttQ888888QtttttttL"
        };
        static readonly List<string> lSpeaking2_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$_```````;,--,_$$$$$",
            "$$(`$$$$$$$$;$$$$$`,$$$",
            "$$}$$$$$$$$$$$$$$$$;}$$",
            "$$|;$/``--__$$$$$$$(}$$",
            "$$-}/$_>>>$$v_<<<_$|-$$",
            "$$$|$$\\(@)}$${(@)/(|$$$",
            "$$$|$$$$$$$|$$$$$$(|$$$",
            "$$$(|$$$$$c..$$#$$$|$$$",
            "$$$$|$$$$_____$$$$|$$$$",
            "$$$$$|$#$(\\_/#$$$|$$$$$",
            "$$$$$$$__(______$$$$$$$",
            "$$$$$L==L____L==L$$$$$$",
            "L/tttttQ888888QtttttttL"
        };

        // Colors - FG
        static readonly List<string> lSpeaking1_ColorsFG = new List<string>()
        { 
            "                       ",
            "    yyyyyyyyyyyyyy     ",
            "  yy        y     yy   ",
            "  y                yy  ",
            "  YYYYYYYYYYYYYYYYYYY  ",
            " YYYYYYYYYYYYYYYYYYYY  ",
            " YYYYYYOoXYYYYOoXYrYYY ",
            " YyYYYYYYYYYYYYYYYrYYY ",
            "  YyYYYYYYYYYYYRYYYYY  ",
            "   yyYYYYRRRRRYYYYYY   ",
            "     yyRYRYYYRYYYY     ",
            "       YYRYYYYYY       ",
            "     yyybXXXXbyyy      ",
            "O      yyyyyyyy       O"
        };
        static readonly List<string> lSpeaking2_ColorsFG = new List<string>()
        {
            "                       ",
            "    yyyyyyyyyyyyyy     ",
            "  yy        y     yy   ",
            "  y                yy  ",
            "  YYYYYYYYYYYYYYYYYYY  ",
            " YYYYYYYYYYYYYYYYYYYY  ",
            " YYYYYYOoXYYYYOoXYrYYY ",
            " YyYYYYYYYYYYYYYYYrYYY ",
            "  YyYYYYYYYYYYYRYYYYY  ",
            "   yyYYYYRRRRRYYYYYY   ",
            "     yyRYRrrrRYYYY     ",
            "       YYRYYYYYY       ",
            "     yyybXXXXbyyy      ",
            "O      yyyyyyyy       O"
        };

        // Colors - BG
        static readonly List<string> lSpeaking1_ColorsBG = new List<string>()
        {
            "XXXXXXXXXXXXXXXXXXXXXXX",
            "XXXXYYYYYYYYYYYYYXXXXXX",
            "XXYYYYYYYYYYYYYYYYYYXXX",
            "XXYYYYYYYYYYYYYYYYYYYXX",
            "XXYYYYYYYYYYYYYYYYYYYXX",
            "XXYYYyYyyyyyyyyyYyRYYXX",
            "XXyYyyYCXCWyyWCXCyyYyXX",
            "XXyYyyyyyyyyyyyyyyyYXXX",
            "XXXYYyyyyyyyyyyyyyyYXXX",
            "XXXXYYyyyyyyyyyyyyYXXXX",
            "XXXXXYYyyyyyyyyyYYXXXXX",
            "XXXXXXXYYYYYYYYYXXXXXXX",
            "XXXXXXOOyyyyyyOOXXXXXXX",
            "XOyOOOOObbbbbbOOOOOOyOX"
        };
        static readonly List<string> lSpeaking2_ColorsBG = new List<string>()
        {
            "XXXXXXXXXXXXXXXXXXXXXXX",
            "XXXXYYYYYYYYYYYYYXXXXXX",
            "XXYYYYYYYYYYYYYYYYYYXXX",
            "XXYYYYYYYYYYYYYYYYYYYXX",
            "XXYYYYYYYYYYYYYYYYYYYXX",
            "XXYYYyYyyyyyyyyyYyRYYXX",
            "XXyYyyYCXCWyyWCXCyyYyXX",
            "XXyYyyyyyyyyyyyyyyyYXXX",
            "XXXYYyyyyyyyyyyyyyyYXXX",
            "XXXXYYyyyyyyyyyyyyYXXXX",
            "XXXXXYYyyyrrryyyYYXXXXX",
            "XXXXXXXYYYYYYYYYXXXXXXX",
            "XXXXXXOOyyyyyyOOXXXXXXX",
            "XOyOOOOObbbbbbOOOOOOyOX"
        };
    }
}
