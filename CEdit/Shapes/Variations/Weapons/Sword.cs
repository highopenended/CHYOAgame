using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Weapons
{
    public class Sword
    {

        public Sword()
        {
            arr_Chars = PUBVAR.GetCharArr(lSword);
            arr_ColorsFG = PUBVAR.GetCharArr(lSword_ColorsFG);

            charConverter(arr_Chars);
        }

        public string Description { get; }


        public char[,] arr_Chars = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        public char[,] arr_ColorsFG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        public char[,] arr_ColorsBG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];


        void charConverter(char[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1); j++)
                {
                    switch(arr[i,j])
                    {
                        case '[':
                            arr[i, j] = Convert.ToChar(221);
                            break;

                        case ']':
                            arr[i, j] = Convert.ToChar(222);
                            break;

                        case 'S':
                            arr[i, j] = Convert.ToChar(245);
                            break;

                        case 'A':
                           // arr[i, j] = Convert.ToChar(215);
                            break;

                        case 'V':
                            arr[i, j] = Convert.ToChar(254);
                            break;

                        case 'Y':
                            arr[i, j] = Convert.ToChar(251);
                            break;

                        case 'X':
                            arr[i, j] = Convert.ToChar(178);
                            break;

                        case '#':
                            arr[i, j] = Convert.ToChar(244);
                            break;

                        case '=':
                            arr[i, j] = Convert.ToChar(220);
                            break;

                        case '}':
                           // arr[i, j] = Convert.ToChar(244);
                            break;

                        case '{':
                           // arr[i, j] = Convert.ToChar(245);
                            break;

                        case 'O':
                            arr[i, j] = Convert.ToChar(153);
                            break;


                        case '0':
                            arr[i, j] = Convert.ToChar(232);
                            break;

                        case ';':
                            arr[i, j] = Convert.ToChar(174);
                            break;

                        case ',':
                            arr[i, j] = Convert.ToChar(175);
                            break;



                        default:
                            // Do Nothing
                            break;
                    }

                }
            }
        }


        // ASCII - Sword
        readonly List<string> lSword = new List<string>()
        {
            "           .           ",
            "          /|\\          ",
            "          [Y]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "          [S]          ",
            "       0==#V#==0       ",
            "           X           ",
            "           X           ",
            "          <O>          "
        };

        readonly List<string> lSword_ColorsFG = new List<string>()
        {
            "                       ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "          oCo          ",
            "       COOCoCOOC       ",
            "          YYY          ",
            "          YYY          ",
            "          CrC          "
        };
    }
}
