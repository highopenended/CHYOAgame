using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chyoa.CEdit.Shapes.Variations.Animations
{
    public class Fire_Small : Shape
    {

        public Fire_Small(char[,] arrayOfCharacters, char[,] arrayOfColors_FG = null, char[,] arrayOfColors_BG = null) : base(arrayOfCharacters, arrayOfColors_FG, arrayOfColors_BG)
        {
            Initialize_Fire();
            InternalMovement_IsComplete = false;
            ArrColors_FG = PUBVAR.GetCharArr(lFire_Colors); 
        }

        protected override void MoveOneTick_InternalMovement()
        {
            ArrChars = GetNextArr();
        }

        List<char[,]> instanceArrays = new List<char[,]>();

        public void Initialize_Fire()
        {
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_1));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_1));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_2));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_2));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_3));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_3));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_4));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_4));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_5));
            instanceArrays.Add(PUBVAR.GetCharArr(lFire_5));
        }

        public int counter = 0;
        public char[,] GetNextArr()
        {
            char[,] returnArr = instanceArrays[counter];

            if((counter+1)<instanceArrays.Count)
                    { counter++; }
            else    { counter = 0; }
            return returnArr;
        }

        // ASCII - Fire
        public static readonly List<string> lFire_0 = new List<string>()
        {
            "               ",
            "               ",
            "               ",
            "   ,`-_        ",
            "   `-`     __  ",
            "     .-_  - -  ",
            "   _]  ``  [   ",
            "  [        ;   ",
            " (           ] ",
            " ]         _-  ",
            " `--_____--    ",
        };

        readonly List<string> lFire_Colors = new List<string>()
        {
            "               ",
            "ooooooooooooooo",
            "ooooooooooooooo",
            "OOOOooooooooooo",
            "OOOOOOOOOOOOOOO",
            "RRRyRRRRRRyRRRR",
            "RRRRyrRRrryRRRR",
            "RRRrrRrRrrRRRRR",
            "RRRryyyyyyyRRRR",
            "RRRryyyyyyyRRRR",
            "RRRRRRRRRRRRRRR",
        };

        // ASCII - Fire
        static readonly List<string> lFire_1 = new List<string>()
        {
            "               ",
            "               ",
            "            ;' ",
            "   ,`-_        ",
            "   `-`     __  ",
            "     .-_  - -  ",
            "   _]  ``  {   ",
            "  {   _    ;   ",
            " (    ''     } ",
            " }   ''    _-  ",
            " `--_____--    ",
        };

        static readonly List<string> lFire_2 = new List<string>()
        {
            "        -_     ",
            "   ,``_   -_-  ",
            "   { ;     -`` ",
            "   `-`     ,   ",
            "          -  `_",
            "   _-.-_ -- - `",
            "    -' `     }  ",
            "   {  -   ;    ",
            "  -  -`-    '- ",
            " }    '_-- _-  ",
            "  `--__-_--    ",
        };

        static readonly List<string> lFire_3 = new List<string>()
        {
            "     .         ",
            "     .;        ",
            "  ,``'         ",
            "  [ ;          ",
            "   ``        -`",
            " `--_.-_ -- - `",
            "   _} `     {  ",
            "   {       ;   ",
            "    )  ))    } ",
            "  ]   ( _) -   ",
            "  `--____--    ",
        };

        static readonly List<string> lFire_4 = new List<string>()
        {
            "     `.        ",
            "     .;        ",
            "   `           ",
            "  ';           ",
            "              _",
            "   _-.-_    - `",
            "   _] ` `` ,   ",
            "   [ ((   ;    ",
            " (   ( )    _  ",
            "  }  '-`  `_   ",
            "  `--____--    ",
        };

        static readonly List<string> lFire_5 = new List<string>()
        {
            "               ",
            "               ",
            "               ",
            "               ",
            "            `-.",
            "   _-.-_ --_- `",
            "   _] ` _`-,   ",
            "   [       ;   ",
            " (           ] ",
            "   }       _-  ",
            "    `-___--    ",
        };
    }
}
