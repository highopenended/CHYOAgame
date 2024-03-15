using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.TextBoxShapes
{
    public class Typer_TextBox : Shape
    {
        public Typer_TextBox(char[,] arrayOfCharacters, char[,] arrayOfColors_FG, char[,] arrayOfColors_BG,
                                int _BorderHeight_Top, int _BorderHeight_Bot, 
                                int _BorderWidth_Left, int _BorderWidth_Right, 
                                char _borderColor, char _textColor,
                                int _typeSpeed, 
                                List<string> _listOfHighlightWords, char _highlightColor) 
                                : base(arrayOfCharacters, arrayOfColors_FG, arrayOfColors_BG)
        {

            ArrCharsText_Full = new char[ArrChars.GetUpperBound(0)+1, ArrChars.GetUpperBound(1)+1];
            TypingSpeed = _typeSpeed;

            for (int i = 0; i < ArrChars.GetUpperBound(0); i++)
            {
                for (int j = 0; j < ArrChars.GetUpperBound(1); j++)
                {
                    ArrCharsText_Full[i, j] = ArrChars[i, j] ;
                }
            }


            BorderHeight_Top = _BorderHeight_Top;
            BorderHeight_Bot = _BorderHeight_Bot;
            BorderWidth_Left = _BorderWidth_Left;
            BorderWidth_Right = _BorderWidth_Right;

            index_Row = BorderHeight_Top + 1;
            index_Col = BorderWidth_Left + 1;

            borderColor = _borderColor;
            textColor = _textColor;

            listOfHighlightWords = _listOfHighlightWords;
            highlightColor = _highlightColor;

            // Initialize the borders (before set to empty) so they are automatically drawn all the time (instead of being typed out slowly)
            InitializeBorderArr();

            // Empty the array that will be pulled and written to the console 
            //  since it will be empty until filled over time with typed out text
            SetToEmptyArray(out ArrChars);
            InternalMovement_IsComplete = false;
        }


        // These are used to determine the shape of the border so it's excluded from being typed out and just appears instantly
        int BorderHeight_Top;
        int BorderHeight_Bot;
        int BorderWidth_Left;
        int BorderWidth_Right;


        // Holds the completed version of the textbox
        private char[,] ArrCharsText_Full;

        // OVERRIDE : Expand internal text
        protected override void MoveOneTick_InternalMovement()
        {
            if (IsVisible)
            {
                MoveOneTick_TypeOutText();
            }
        }

        // OVERRIDE : Complete internal text immediately
        protected override void Complete_InternalMovement()
        {
            index_Row = ArrChars.GetUpperBound(0);
            index_Col = ArrChars.GetUpperBound(1);
        }



        string highlightString;

        List<string> listOfHighlightWords;
        char highlightColor;

        List<char> lAllowedStartEndChars = new List<char>(){'!', '"', '.', '?',  ' ', ']' };
        bool CheckIfAllowedStartEndChar(char charToCheck)
        {
            for (int i = 0; i < lAllowedStartEndChars.Count; i++)
            {
                if(charToCheck == lAllowedStartEndChars[i])
                {
                    return true;
                }
            }
            return false;
        }




        public int TypingSpeed { get; set; }

        int index_Row;
        int index_Col;

        bool TypingIsComplete = false;
        void MoveOneTick_TypeOutText()
        {


            // This is increased to quickly get through empty spaces 
            int TypingSpeed_Mod = TypingSpeed;
            bool charWasSpace = false;


            // Type entire border first
            ArrChars = arrOutsideBorder_Chars;
            ArrColors_FG = arrOutsideBorder_ColorsFG;
            ArrColors_BG = arrOutsideBorder_ColorsBG;

            // Do multiple times for faster text
            for (int k = 0; k < TypingSpeed_Mod; k++)
            {
                // Only run this if the typing is not complete
                if (!TypingIsComplete)
                {
                    for (int i = BorderHeight_Top; i <= index_Row - BorderHeight_Bot; i++)
                    {
                        // Reset check mod for skipping spaces
                        for (int j = BorderWidth_Left; j < index_Col - BorderWidth_Right; j++)
                        {
                            ArrChars[i, j] = ArrCharsText_Full[i, j];

                            // Check if the character was a blank space (' ')
                            if (ArrChars[i, j] == ' ' || ArrChars[i,j] == 'Ú' || ArrChars[i,j] == 'Ä' || ArrChars[i,j] == '\0' || ArrChars[i,j] == 'þ')
                                    { charWasSpace = true; }
                            else    { charWasSpace = false; }

                            // This whole section deals with highlighted words (if any)
                            if(listOfHighlightWords != null)
                            {
                                for (int h = 0; h < listOfHighlightWords.Count; h++)
                                {
                                    highlightString = listOfHighlightWords[h];

                                    // First letter matched and previous char is allowed
                                    if (char.ToUpper(ArrCharsText_Full[i, j]) == char.ToUpper(highlightString[0]) && CheckIfAllowedStartEndChar(ArrChars[i, j - 1]))
                                    {

                                        for (int c = 0; c < highlightString.Length; c++)
                                        {
                                            char checkChar = char.ToUpper(ArrCharsText_Full[i, j + c]);

                                            if (char.ToUpper(highlightString[c]) != checkChar)
                                            {
                                                // Exit on mismatch
                                                c = highlightString.Length;
                                            }
                                            else
                                            {   // Char Matches
                                                if (c == highlightString.Length - 1)
                                                {
                                                    //  Last letter of match word (it matches fully), so fill color array accordingly (if next word is space)
                                                    for (int v = 0; v < highlightString.Length; v++)
                                                    {
                                                        // Only highlight the word if there is a space or punctuation after
                                                        if (CheckIfAllowedStartEndChar(ArrCharsText_Full[i, j + c + 1]))
                                                        {
                                                            ArrColors_FG[i, j + v] = highlightColor;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }




                    if (index_Col < ArrChars.GetUpperBound(1))
                    {
                        index_Col++;

                        // If the character was a space, then do another loop this same step to quickly skip the spaces
                        if(charWasSpace)
                                { TypingSpeed_Mod++; }
                        else    { TypingSpeed_Mod = TypingSpeed; }
                    }
                    else
                    {
                        index_Col = 0;

                        if (index_Row < ArrChars.GetUpperBound(0))
                        {
                            index_Row++;
                        }
                        else
                        {
                            index_Row = 0;
                            TypingIsComplete = true;
                            InternalMovement_IsComplete = true;
                        }
                    }


                }
            }
        }


        // Colors of the textbox
        char borderColor;
        char textColor;

        // The array representing the outside border of the textbox
        private char[,] arrOutsideBorder_Chars;
        private char[,] arrOutsideBorder_ColorsFG;
        private char[,] arrOutsideBorder_ColorsBG;

        void InitializeBorderArr()
        {
            arrOutsideBorder_Chars = new char[ArrCharsText_Full.GetUpperBound(0) + 1, ArrCharsText_Full.GetUpperBound(1) + 1];
            arrOutsideBorder_ColorsFG = new char[ArrCharsText_Full.GetUpperBound(0) + 1, ArrCharsText_Full.GetUpperBound(1) + 1];
            arrOutsideBorder_ColorsBG = new char[ArrCharsText_Full.GetUpperBound(0) + 1, ArrCharsText_Full.GetUpperBound(1) + 1];


            // Get an array of the border without the text

            for (int i = 0; i < arrOutsideBorder_Chars.GetUpperBound(0); i++)
            {
                // Top Border or bottom border are filled entirely
                if (i < BorderHeight_Top || i >= arrOutsideBorder_Chars.GetUpperBound(0) - BorderHeight_Bot)
                {
                    for (int j = 0; j < arrOutsideBorder_Chars.GetUpperBound(1); j++)
                    {
                        arrOutsideBorder_Chars[i, j] = ArrCharsText_Full[i, j];
                        arrOutsideBorder_ColorsFG[i, j] = borderColor;
                    }
                }
                else
                {
                    // Left and Right borders are only filled for the width
                    for (int j = 0; j < arrOutsideBorder_Chars.GetUpperBound(1); j++)
                    {
                        // Left or Right Border
                        if(j<BorderWidth_Left || j >= arrOutsideBorder_Chars.GetUpperBound(1)- BorderWidth_Right)
                        {
                            arrOutsideBorder_Chars[i, j] = ArrCharsText_Full[i, j];
                            arrOutsideBorder_ColorsFG[i, j] = borderColor;
                        }
                        else // Null for the inside spots
                        {
                            arrOutsideBorder_Chars[i, j] = ' ';
                            arrOutsideBorder_ColorsFG[i, j] = textColor;
                        }
                    }
                }
            }            
        }


        // Used in EventColumnUpdates to make the box disappear
        public int CountDown_EventColumn { get; set; }
        public void Step_Countdown()
        {
            CountDown_EventColumn--;
        }

        // If it started to the left, then this will be true until a movement plan is added to correct it
        public bool NeedsCoordinateCorrection_EventColumn { get; set; }

        // When the message sits still, this keeps track of where it should ultimately go once it snaps back in to the column
        public int TrueTopCoord_EventColumn { get; set; }

    }
}
