using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.TextBoxShapes.StringEdit
{
    // This is generally used to make a blinking console cursor 
    public class Blinker : Shape
    {

        public Blinker(char[,] arrayOfCharacters, char[,] arrayOfColors_FG = null, char[,] arrayOfColors_BG = null,
                        char _Highlight_Char = '>', PUBVAR.Colors _Highlight_ColorFG = PUBVAR.Colors.Red, PUBVAR.Colors _Highlight_ColorBG = PUBVAR.Colors.White,
                        char _Unhighlight_Char = '.', PUBVAR.Colors _Unhighlight_ColorFG = PUBVAR.Colors.White, PUBVAR.Colors _Unhighlight_ColorBG = PUBVAR.Colors.Black) 
                        : base(arrayOfCharacters, arrayOfColors_FG, arrayOfColors_BG)
        {
            Highlight_Char = _Highlight_Char;
            Highlight_ColorFG = _Highlight_ColorFG;
            Highlight_ColorBG = _Highlight_ColorBG;

            Unhighlight_Char = _Unhighlight_Char;
            Unhighlight_ColorFG = _Unhighlight_ColorFG;
            Unhighlight_ColorBG = _Unhighlight_ColorBG;

            current_Char = Unhighlight_Char;
            current_ColorFG = _Unhighlight_ColorFG;
            current_ColorBG = _Unhighlight_ColorBG;


            ArrChars = new char[1, 1];
            ArrColors_FG = new char[1, 1];
            ArrColors_BG = new char[1, 1];

            ArrChars[0, 0] = Highlight_Char;
            ArrColors_FG[0, 0] = PUBVAR.GetColorChar(Highlight_ColorFG);
            ArrColors_BG[0, 0] = PUBVAR.GetColorChar(Highlight_ColorBG);

            InternalMovement_IsComplete = false;
            ShapeStatus = ShapeStatuses.AbsoluteTop;
        }


        // The char and colors when "highlighted"
        char Highlight_Char;
        PUBVAR.Colors Highlight_ColorFG;
        PUBVAR.Colors Highlight_ColorBG;

        // The char and colors when "unhighlighted"
        char Unhighlight_Char;
        PUBVAR.Colors Unhighlight_ColorFG;
        PUBVAR.Colors Unhighlight_ColorBG;

        // The char and colors currently displaying
        public char current_Char;
        public PUBVAR.Colors current_ColorFG;
        public PUBVAR.Colors current_ColorBG;



        int tickCountsBeforeChange = 5;
        int tickCount = 0;
        bool highlightOrUnhighlight;


        protected override void MoveOneTick_InternalMovement()
        {           

            if(tickCount + 1 <= tickCountsBeforeChange)
            {
                tickCount++;
            }
            else
            {
                if(highlightOrUnhighlight)
                {
                    ArrChars[0, 0] = Highlight_Char;
                    ArrColors_FG[0, 0] = PUBVAR.GetColorChar(Highlight_ColorFG);
                    ArrColors_BG[0, 0] = PUBVAR.GetColorChar(Highlight_ColorBG);
                    highlightOrUnhighlight = !highlightOrUnhighlight;
                    tickCount = 0;
                }
                else
                {
                    ArrChars[0, 0] = Unhighlight_Char;
                    ArrColors_FG[0, 0] = PUBVAR.GetColorChar(Unhighlight_ColorFG);
                    ArrColors_BG[0, 0] = PUBVAR.GetColorChar(Unhighlight_ColorBG);
                    highlightOrUnhighlight = !highlightOrUnhighlight;
                    tickCount = 0;
                }
            }
        }

    }
}
