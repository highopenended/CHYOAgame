using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Animations
{
    public class Fire_Medium : Shape
    {
        public fireColors FireColor { get; set; }
        Random myRand = new Random();
        public Fire_Medium(fireColors fireColor)
        {
            FireColor = fireColor;
            Initialize_Fire();
            InternalMovement_IsComplete = false;

            counter = myRand.Next(0, instanceArrays_Chars.Count);
        }

        protected override void MoveOneTick_InternalMovement()
        {
            GetNextArr(out ArrChars, out ArrColors_FG, out ArrColors_BG);
        }

        List<char[,]> instanceArrays_Chars = new List<char[,]>();
        List<char[,]> instanceArrays_ColorsFG = new List<char[,]>();
        List<char[,]> instanceArrays_ColorsBG = new List<char[,]>();

        public void Initialize_Fire()
        {
            // Chars
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list1_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list1_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list2_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list2_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list3_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list3_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list4_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list4_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list5_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list5_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list6_Chars));
            instanceArrays_Chars.Add(PUBVAR.GetCharArr(list6_Chars));

            // Colors FG
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list1_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list1_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list2_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list2_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list3_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list3_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list4_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list4_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list5_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list5_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list6_ColorsFG));
            instanceArrays_ColorsFG.Add(PUBVAR.GetCharArr(list6_ColorsFG));

            // Colors BG
            switch (FireColor)
            {
                case fireColors.Red:
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_red));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_red));
                    break;

                case fireColors.Blue:
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_blue));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_blue));
                    break;

                case fireColors.Green:
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_green));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_green));
                    break;

                case fireColors.Magenta:
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list1_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list2_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list3_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list4_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list5_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_magenta));
                    instanceArrays_ColorsBG.Add(PUBVAR.GetCharArr(list6_ColorsBG_magenta));
                    break;
            }
        }


        public int counter = 0;
        public void GetNextArr(out char[,] arr_Chars, out char[,] arr_ColorsFG, out char[,] arr_ColorsBG)
        {
            arr_Chars = instanceArrays_Chars[counter];
            arr_ColorsFG = instanceArrays_ColorsFG[counter];
            arr_ColorsBG = instanceArrays_ColorsBG[counter];


            if ((counter + 1) < instanceArrays_Chars.Count)
                    { counter++; }
            else    { counter = 0; }
        }





        public List<string> list1_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };
        public List<string> list2_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };
        public List<string> list3_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };
        public List<string> list4_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };
        public List<string> list5_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };
        public List<string> list6_Chars = new List<string>()
        {
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$",
            "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        };

        public List<string> list1_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };
        public List<string> list2_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };
        public List<string> list3_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };
        public List<string> list4_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };
        public List<string> list5_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };
        public List<string> list6_ColorsFG = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             "
        };

        // Red
        public List<string> list1_ColorsBG_red = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              R              ",
            "           RRRR              ",
            "           RRR               ",
            "              RR             ",
            "             RRRR RR         ",
            "           RRRRRR RRR        ",
            "            RrRR RRRR        ",
            "         RR  RrR RRR         ",
            "         RRRrrRR             ",
            "         RRRRrrrRR           ",
            "         RRRrrrWrRR          ",
            "         RRrrrrrrrRR         ",
            "          rrrrWrrrr          ",
            "           RrrWWrrR          ",
            "              Rr             "
        };
        public List<string> list2_ColorsBG_red = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "           R                 ",
            "             RRRR            ",
            "            RR               ",
            "           R     R           ",
            "           R                 ",
            "        R  RRR    R          ",
            "        R  RRRRR  RR         ",
            "        R  r RRRR  RR        ",
            "       RR  RRRRRR  RRR       ",
            "        RRRRRRrR   RR        ",
            "         RRRRRrRRRR          ",
            "          RRRrrRRR           ",
            "         RRRRRrrRRR          ",
            "       RRRRRRrrrrRRR         ",
            "         RRRrrrrrrRR         ",
            "         RRrrWrrrrrR         ",
            "          rrrrWrrrr          ",
            "            rrWWrrR          ",
            "              RrR            "
        };
        public List<string> list3_ColorsBG_red = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              R              ",
            "              RR             ",
            "            RRRR  R          ",
            "           RRRR              ",
            "           RR   R            ",
            "         R  RR  RR           ",
            "         RRR RRRR  R         ",
            "         RRR  RR             ",
            "        RR       RRRR        ",
            "       RR    RRRRRRRR        ",
            "        RRRR  RrRR           ",
            "         RRRRRrRR    R       ",
            "         RRRRRrrR   R        ",
            "         RRRRRrrRRR          ",
            "         RRRRrrrrRRRR        ",
            "         RRRrrWrrrRR         ",
            "         RRrrWrrrrrR         ",
            "          rrrrWWrrr          ",
            "           RrrWWWrR          ",
            "              RrR            "
        };
        public List<string> list4_ColorsBG_red = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "            R                ",
            "            RRR              ",
            "         R   RRRR            ",
            "        RR RRRR   R          ",
            "        RR  R  R             ",
            "       RRRRRR  R             ",
            "       RRRRRRRRR             ",
            "        RRRRRRRRRR  R        ",
            "         RRRRRRR RRR         ",
            "           RRRRRR RRRR       ",
            "         R  RRRRRRRRR        ",
            "         RRR RRRRRR          ",
            "          RRRRRRrRR  R       ",
            "          RRRrrrrRR R        ",
            "          RRRrrrrRR          ",
            "         RRRRyyrrRRR         ",
            "         RRRrWWyrrRRR        ",
            "         RRRrryWyrRR         ",
            "          rrryyWyrrr         ",
            "           RrrWWrrr          ",
            "              rrr            "
        };
        public List<string> list5_ColorsBG_red = new List<string>()
        {
            "              R              ",
            "              RR             ",
            "           RRRR              ",
            "          RRRR               ",
            "           RRRRR R           ",
            "             RRR R           ",
            "         R    R              ",
            "                             ",
            "                             ",
            "         R   R               ",
            "         RR RRR    RR        ",
            "        RRR RRRR             ",
            "       RRRR RRRRR RRRR       ",
            "       RR  R RRRRRRRRR       ",
            "        R  R RRRRR R R       ",
            "            RRrRR RR         ",
            "          RRRrrRR R          ",
            "         RRRrrRR             ",
            "        RRRrrrRR             ",
            "        RRrrrrrRR            ",
            "        RRrrryyrrrR          ",
            "         RRrrWyyrrrR         ",
            "          RrrrWWrrr          ",
            "             RrrrR           "
        };
        public List<string> list6_ColorsBG_red = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                 R           ",
            "               R             ",
            "                R            ",
            "                 RR          ",
            "            R    R           ",
            "             R    RRR        ",
            "             RR RRR          ",
            "             RRR RRRR        ",
            "             RRRR RR         ",
            "            RRRRR  R         ",
            "          RRRRRrR            ",
            "         RRRRRrRR            ",
            "        RRRRrrRR     R       ",
            "        RRrrrrRR    R        ",
            "         RRrrrrRR    R       ",
            "          RRrrrrRR R R       ",
            "           RRrryyyrRRR       ",
            "           RRRyWWyyrrR       ",
            "         rrryyWWWyrrR        ",
            "            RrrrrR           ",
        };

        //Blue
        public List<string> list1_ColorsBG_blue = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              B              ",
            "           BBBB              ",
            "           BBB               ",
            "              BB             ",
            "             BBBB BB         ",
            "           BBBBBB BBB        ",
            "            BbBB BBBB        ",
            "         BB  BbB BBB         ",
            "         BBBbbBB             ",
            "         BBBBbbbBB           ",
            "         BBBbbbWbBB          ",
            "         BBbbbbbbbBB         ",
            "          bbbbWbbbb          ",
            "           BbbWWbbB          ",
            "              Bb             "
        };
        public List<string> list2_ColorsBG_blue = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "           B                 ",
            "             BBBB            ",
            "            BB               ",
            "           B     B           ",
            "           B                 ",
            "        B  BBB    B          ",
            "        B  BBBBB  BB         ",
            "        B  b BBBB  BB        ",
            "       BB  BBBBBB  BBB       ",
            "        BBBBBBbB   BB        ",
            "         BBBBBbBBBB          ",
            "          BBBbbBBB           ",
            "         BBBBBbbBBB          ",
            "       BBBBBBbbbbBBB         ",
            "         BBBbbbbbbBB         ",
            "         BBbbWbbbbbB         ",
            "          bbbbWbbbb          ",
            "            bbWWbbB          ",
            "              BbB            "
        };
        public List<string> list3_ColorsBG_blue = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              B              ",
            "              BB             ",
            "            BBBB  B          ",
            "           BBBB              ",
            "           BB   B            ",
            "         B  BB  BB           ",
            "         BBB BBBB  B         ",
            "         BBB  BB             ",
            "        BB       BBBB        ",
            "       BB    BBBBBBBB        ",
            "        BBBB  BbBB           ",
            "         BBBBBbBB    B       ",
            "         BBBBBbbB   B        ",
            "         BBBBBbbBBB          ",
            "         BBBBbbbbBBBB        ",
            "         BBBbbWbbbBB         ",
            "         BBbbWbbbbbB         ",
            "          bbbbWWbbb          ",
            "           BbbWWWbB          ",
            "              BbB            "
        };
        public List<string> list4_ColorsBG_blue = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "            B                ",
            "            BBB              ",
            "         B   BBBB            ",
            "        BB BBBB   B          ",
            "        BB  B  B             ",
            "       BBBBBB  B             ",
            "       BBBBBBBBB             ",
            "        BBBBBBBBBB  B        ",
            "         BBBBBBB BBB         ",
            "           BBBBBB BBBB       ",
            "         B  BBBBBBBBB        ",
            "         BBB BBBBBB          ",
            "          BBBBBBbBB  B       ",
            "          BBBbbbbBB B        ",
            "          BBBbbbbBB          ",
            "         BBBBccbbBBB         ",
            "         BBBbWWcbbBBB        ",
            "         BBBbbcWcbBB         ",
            "          bbbccWcbbb         ",
            "           BbbWWbbb          ",
            "              bbb            "
        };
        public List<string> list5_ColorsBG_blue = new List<string>()
        {
            "              B              ",
            "              BB             ",
            "           BBBB              ",
            "          BBBB               ",
            "           BBBBB B           ",
            "             BBB B           ",
            "         B    B              ",
            "                             ",
            "                             ",
            "         B   B               ",
            "         BB BBB    BB        ",
            "        BBB BBBB             ",
            "       BBBB BBBBB BBBB       ",
            "       BB  B BBBBBBBBB       ",
            "        B  B BBBBB B B       ",
            "            BBbBB BB         ",
            "          BBBbbBB B          ",
            "         BBBbbBB             ",
            "        BBBbbbBB             ",
            "        BBbbbbbBB            ",
            "        BBbbbccbbbB          ",
            "         BBbbWccbbbB         ",
            "          BbbbWWbbb          ",
            "             BbbbB           "
        };
        public List<string> list6_ColorsBG_blue = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                 B           ",
            "               B             ",
            "                B            ",
            "                 BB          ",
            "            B    B           ",
            "             B    BBB        ",
            "             BB BBB          ",
            "             BBB BBBB        ",
            "             BBBB BB         ",
            "            BBBBB  B         ",
            "          BBBBBbB            ",
            "         BBBBBbBB            ",
            "        BBBBbbBB     B       ",
            "        BBbbbbBB    B        ",
            "         BBbbbbBB    B       ",
            "          BBbbbbBB B B       ",
            "           BBbbcccbBBB       ",
            "           BBBcWWccbbB       ",
            "         bbbccWWWcbbB        ",
            "            BbbbbB           ",
        };

        // Green
        public List<string> list1_ColorsBG_green = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              G              ",
            "           GGGG              ",
            "           GGG               ",
            "              GG             ",
            "             GGGG GG         ",
            "           GGGGGG GGG        ",
            "            GgGG GGGG        ",
            "         GG  GgG GGG         ",
            "         GGGggGG             ",
            "         GGGGgggGG           ",
            "         GGGgggWgGG          ",
            "         GGgggggggGG         ",
            "          ggggWgggg          ",
            "           GggWWggG          ",
            "              Gg             "
        };
        public List<string> list2_ColorsBG_green = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "           G                 ",
            "             GGGG            ",
            "            GG               ",
            "           G     G           ",
            "           G                 ",
            "        G  GGG    G          ",
            "        G  GGGGG  GG         ",
            "        G  g GGGG  GG        ",
            "       GG  GGGGGG  GGG       ",
            "        GGGGGGgG   GG        ",
            "         GGGGGgGGGG          ",
            "          GGGggGGG           ",
            "         GGGGGggGGG          ",
            "       GGGGGGggggGGG         ",
            "         GGGggggggGG         ",
            "         GGggWgggggG         ",
            "          ggggWgggg          ",
            "            ggWWggG          ",
            "              GgG            "
        };
        public List<string> list3_ColorsBG_green = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              G              ",
            "              GG             ",
            "            GGGG  G          ",
            "           GGGG              ",
            "           GG   G            ",
            "         G  GG  GG           ",
            "         GGG GGGG  G         ",
            "         GGG  GG             ",
            "        GG       GGGG        ",
            "       GG    GGGGGGGG        ",
            "        GGGG  GgGG           ",
            "         GGGGGgGG    G       ",
            "         GGGGGggG   G        ",
            "         GGGGGggGGG          ",
            "         GGGGggggGGGG        ",
            "         GGGggWgggGG         ",
            "         GGggWgggggG         ",
            "          ggggWWggg          ",
            "           GggWWWgG          ",
            "              GgG            "
        };
        public List<string> list4_ColorsBG_green = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "            G                ",
            "            GGG              ",
            "         G   GGGG            ",
            "        GG GGGG   G          ",
            "        GG  G  G             ",
            "       GGGGGG  G             ",
            "       GGGGGGGGG             ",
            "        GGGGGGGGGG  G        ",
            "         GGGGGGG GGG         ",
            "           GGGGGG GGGG       ",
            "         G  GGGGGGGGG        ",
            "         GGG GGGGGG          ",
            "          GGGGGGgGG  G       ",
            "          GGGggggGG G        ",
            "          GGGggggGG          ",
            "         GGGGyyggGGG         ",
            "         GGGgWWyggGGG        ",
            "         GGGggyWygGG         ",
            "          gggyyWyggg         ",
            "           GggWWggg          ",
            "              ggg            "
        };
        public List<string> list5_ColorsBG_green = new List<string>()
        {
            "              G              ",
            "              GG             ",
            "           GGGG              ",
            "          GGGG               ",
            "           GGGGG G           ",
            "             GGG G           ",
            "         G    G              ",
            "                             ",
            "                             ",
            "         G   G               ",
            "         GG GGG    GG        ",
            "        GGG GGGG             ",
            "       GGGG GGGGG GGGG       ",
            "       GG  G GGGGGGGGG       ",
            "        G  G GGGGG G G       ",
            "            GGgGG GG         ",
            "          GGGggGG G          ",
            "         GGGggGG             ",
            "        GGGgggGG             ",
            "        GGgggggGG            ",
            "        GGgggyygggG          ",
            "         GGggWyygggG         ",
            "          GgggWWggg          ",
            "             GgggG           "
        };
        public List<string> list6_ColorsBG_green = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                 G           ",
            "               G             ",
            "                G            ",
            "                 GG          ",
            "            G    G           ",
            "             G    GGG        ",
            "             GG GGG          ",
            "             GGG GGGG        ",
            "             GGGG GG         ",
            "            GGGGG  G         ",
            "          GGGGGgG            ",
            "         GGGGGgGG            ",
            "        GGGGggGG     G       ",
            "        GGggggGG    G        ",
            "         GGggggGG    G       ",
            "          GGggggGG G G       ",
            "           GGggyyygGGG       ",
            "           GGGyWWyyggG       ",
            "         gggyyWWWyggG        ",
            "            GggggG           ",
        };

        // Magenta
        public List<string> list1_ColorsBG_magenta = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              M              ",
            "           MMMM              ",
            "           MMM               ",
            "              MM             ",
            "             MMMM MM         ",
            "           MMMMMM MMM        ",
            "            MmMM MMMM        ",
            "         MM  MmM MMM         ",
            "         MMMmmMM             ",
            "         MMMMmmmMM           ",
            "         MMMmmmWmMM          ",
            "         MMmmmmmmmMM         ",
            "          mmmmWmmmm          ",
            "           MmmWWmmM          ",
            "              Mm             "
        };
        public List<string> list2_ColorsBG_magenta = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "           M                 ",
            "             MMMM            ",
            "            MM               ",
            "           M     M           ",
            "           M                 ",
            "        M  MMM    M          ",
            "        M  MMMMM  MM         ",
            "        M  m MMMM  MM        ",
            "       MM  MMMMMM  MMM       ",
            "        MMMMMMmM   MM        ",
            "         MMMMMmMMMM          ",
            "          MMMmmMMM           ",
            "         MMMMMmmMMM          ",
            "       MMMMMMmmmmMMM         ",
            "         MMMmmmmmmMM         ",
            "         MMmmWmmmmmM         ",
            "          mmmmWmmmm          ",
            "            mmWWmmM          ",
            "              MmM            "
        };
        public List<string> list3_ColorsBG_magenta = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              M              ",
            "              MM             ",
            "            MMMM  M          ",
            "           MMMM              ",
            "           MM   M            ",
            "         M  MM  MM           ",
            "         MMM MMMM  M         ",
            "         MMM  MM             ",
            "        MM       MMMM        ",
            "       MM    MMMMMMMM        ",
            "        MMMM  MmMM           ",
            "         MMMMMmMM    M       ",
            "         MMMMMmmM   M        ",
            "         MMMMMmmMMM          ",
            "         MMMMmmmmMMMM        ",
            "         MMMmmWmmmMM         ",
            "         MMmmWmmmmmM         ",
            "          mmmmWWmmm          ",
            "           MmmWWWmM          ",
            "              MmM            "
        };
        public List<string> list4_ColorsBG_magenta = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "            M                ",
            "            MMM              ",
            "         M   MMMM            ",
            "        MM MMMM   M          ",
            "        MM  M  M             ",
            "       MMMMMM  M             ",
            "       MMMMMMMMM             ",
            "        MMMMMMMMMM  M        ",
            "         MMMMMMM MMM         ",
            "           MMMMMM MMMM       ",
            "         M  MMMMMMMMM        ",
            "         MMM MMMMMM          ",
            "          MMMMMMmMM  M       ",
            "          MMMmmmmMM M        ",
            "          MMMmmmmMM          ",
            "         MMMMyymmMMM         ",
            "         MMMmWWymmMMM        ",
            "         MMMmmyWymMM         ",
            "          mmmyyWymmm         ",
            "           MmmWWmmm          ",
            "              mmm            "
        };
        public List<string> list5_ColorsBG_magenta = new List<string>()
        {
            "              M              ",
            "              MM             ",
            "           MMMM              ",
            "          MMMM               ",
            "           MMMMM M           ",
            "             MMM M           ",
            "         M    M              ",
            "                             ",
            "                             ",
            "         M   M               ",
            "         MM MMM    MM        ",
            "        MMM MMMM             ",
            "       MMMM MMMMM MMMM       ",
            "       MM  M MMMMMMMMM       ",
            "        M  M MMMMM M M       ",
            "            MMmMM MM         ",
            "          MMMmmMM M          ",
            "         MMMmmMM             ",
            "        MMMmmmMM             ",
            "        MMmmmmmMM            ",
            "        MMmmmyymmmM          ",
            "         MMmmWyymmmM         ",
            "          MmmmWWmmm          ",
            "             MmmmM           "
        };
        public List<string> list6_ColorsBG_magenta = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                 M           ",
            "               M             ",
            "                M            ",
            "                 MM          ",
            "            M    M           ",
            "             M    MMM        ",
            "             MM MMM          ",
            "             MMM MMMM        ",
            "             MMMM MM         ",
            "            MMMMM  M         ",
            "          MMMMMmM            ",
            "         MMMMMmMM            ",
            "        MMMMmmMM     M       ",
            "        MMmmmmMM    M        ",
            "         MMmmmmMM    M       ",
            "          MMmmmmMM M M       ",
            "           MMmmyyymMMM       ",
            "           MMMyWWyymmM       ",
            "         mmmyyWWWymmM        ",
            "            MmmmmM           ",
        };


        public enum fireColors
        {
            Red,
            Blue,
            Green,
            Magenta
        }


        /*
        public List<string> list1_Chars = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              1              ",
            "           1111              ",
            "           111               ",
            "              11             ",
            "             1111 11         ",
            "           111111 111        ",
            "            1011 1111        ",
            "         11  101 111         ",
            "         1110011             ",
            "         111100011           ",
            "         1110000011          ",
            "         11000000011         ",
            "          000000000          ",
            "           10000001          ",
            "              10             "
        };
        public List<string> list2_Chars = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "           1                 ",
            "             1111            ",
            "            11               ",
            "           1     1           ",
            "           1                 ",
            "        1  111    1          ",
            "        1  11111  11         ",
            "        1  0 1111  11        ",
            "       11  111111  111       ",
            "        11111101   11        ",
            "         1111101111          ",
            "          11100111           ",
            "         1111100111          ",
            "       1111110000111         ",
            "         11100000011         ",
            "         11000000001         ",
            "          000000000          ",
            "            0000001          ",
            "              101            "
        };
        public List<string> list3_Chars = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "              1              ",
            "              11             ",
            "            1111  1          ",
            "           1111              ",
            "           11   1            ",
            "         1  11  11           ",
            "         111 1111  1         ",
            "         111  11             ",
            "        11       1111        ",
            "       11    11111111        ",
            "        1111  1011           ",
            "         11111011    1       ",
            "         11111001   1        ",
            "         1111100111          ",
            "         111100001111        ",
            "         11100000011         ",
            "         11000000001         ",
            "          000000000          ",
            "           10000001          ",
            "              101            "
        };
        public List<string> list4_Chars = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "            1                ",
            "            111              ",
            "         1   1111            ",
            "        11 1111   1          ",
            "        11  1  1             ",
            "       111111  1             ",
            "       111111111             ",
            "        1111111111  1        ",
            "         1111111 111         ",
            "           111111 1111       ",
            "         1  111111111        ",
            "         111 111111          ",
            "          111111011  1       ",
            "          111000011 1        ",
            "          111000011          ",
            "         11110000111         ",
            "         111000000111        ",
            "         11100000011         ",
            "          0000100000         ",
            "           10000000          ",
            "              000            "
        };
        public List<string> list5_Chars = new List<string>()
        {
            "              1              ",
            "              11             ",
            "           1111              ",
            "          1111               ",
            "           11111 1           ",
            "             111 1           ",
            "         1    1              ",
            "                             ",
            "                             ",
            "         1   1               ",
            "         11 111    11        ",
            "        111 1111             ",
            "       1111 11111 1111       ",
            "       11  1 111111111       ",
            "        1  1 11111 1 1       ",
            "            11011 11         ",
            "          1110011 1          ",
            "         1110011             ",
            "        11100011             ",
            "        110000011            ",
            "        11000000001          ",
            "         11000000001         ",
            "          100000000          ",
            "             10001           "
        };
        public List<string> list6_Chars = new List<string>()
        {
            "                             ",
            "                             ",
            "                             ",
            "                             ",
            "                 1           ",
            "               1             ",
            "                1            ",
            "                 11          ",
            "            1    1           ",
            "             1    111        ",
            "             11 111          ",
            "             111 1111        ",
            "             1111 11         ",
            "            11111  1         ",
            "          1111101            ",
            "         11111011            ",
            "        11110011     1       ",
            "        11000011    1        ",
            "         11000011    1       ",
            "          11000011 1 1       ",
            "           11000000111       ",
            "           11100000001       ",
            "         000000000001        ",
            "            100001           ",
        };
        */
    }
}
