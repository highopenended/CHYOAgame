using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chyoa.CEdit.Shapes.Variations.TextBoxShapes;

namespace Chyoa.CEdit.Shapes
{
    public class ShapeMaker_Text
    {
        private readonly Variations.TextBoxShapes.StringEdit.TextSplitter TextSplitter = new Variations.TextBoxShapes.StringEdit.TextSplitter();
        private readonly Variations.TextBoxShapes.StringEdit.TextBoxer    TextBoxer = new Variations.TextBoxShapes.StringEdit.TextBoxer();

        private readonly ArrayMaker ArrayMaker = new ArrayMaker();


        /// <summary>
        /// Returns a list of strings (all equal length) which represent boxed in text
        /// </summary>
        /// <param name="textToPutInBox"> The string to be put in a box </param>
        /// <param name="maxBoxWidth"> The widest the box can possibly be </param>
        /// <param name="borderStyle"> Choose a style </param>
        /// <param name="autosizeBox"> If true, then the box will shrink to its smallest size while still fitting the text (will never be bigger than max) </param>
        /// <returns></returns>
        char[,] GetTextBox(string textToPutInBox, int maxBoxWidth,
                                    BorderStyles borderStyle, bool autosizeBox, 
                                    out int bHeight_Top, out int bHeight_Bot, 
                                    out int bWidth_Left, out int bWidth_Right,
                                    bool isCentered = false)
        {                    
            List<string> lEqualWidthStrings = TextSplitter.SplitUpText(textToPutInBox, maxBoxWidth);
            List<string> lBoxedStrings = TextBoxer.GetBoxedList_OneBigBox(lEqualWidthStrings, maxBoxWidth, borderStyle, autosizeBox,
                                        out bHeight_Top, out bHeight_Bot,
                                        out bWidth_Left, out bWidth_Right,
                                        isCentered);
            char[,] arrTextBox = ArrayMaker.GetCharArr(lBoxedStrings);


            for (int i = 0; i < arrTextBox.Length; i++)
            {
                //Console.WriteLine(arrTextBox[i]);
            }

            return arrTextBox;
        }



        /// <summary>
        /// Returns a full static textbox shape with array complete.
        /// </summary>
        /// <param name="textToPutInBox"></param>
        /// <param name="maxBoxWidth"></param>
        /// <param name="borderStyle"></param>
        /// <param name="autosizeBox"></param>
        /// <returns></returns>
        public Shape CreateShape_StaticTextbox(string textToPutInBox, int maxBoxWidth = 25,
                                    BorderStyles borderStyle = BorderStyles.Style_SpeechBox, 
                                    bool autosizeBox = false, bool isCentered = false)
        {

            List<string> lEqualWidthStrings = TextSplitter.SplitUpText(textToPutInBox, maxBoxWidth);
            List<string> lBoxedStrings = TextBoxer.GetBoxedList_OneBigBox(lEqualWidthStrings, maxBoxWidth, borderStyle, autosizeBox, 
                                                                        out _, out _, out _, out _, isCentered);

            char[,] arrTextBox = ArrayMaker.GetCharArr(lBoxedStrings);
            Shape newShape = new Shape(arrTextBox);
            return newShape;
        }


        /// <summary>
        /// Returns a full static textbox shape with array complete and optional highlight for fg array
        /// </summary>
        /// <param name="textToPutInBox"></param>
        /// <param name="textWidth"></param>
        /// <param name="textHeight"></param>
        /// <param name="highlightedWords"></param>
        /// <param name="highlightColor"></param>
        /// <param name="borderStyle"></param>
        /// <param name="autosizeBox"></param>
        /// <param name="isCentered"></param>
        /// <returns></returns>
        public Shape CreateShape_StaticTextbox(string textToPutInBox, int textWidth, int textHeight,
                                                PUBVAR.Colors textColor, PUBVAR.Colors borderColor,
                                                List<string> highlightedWords = null, PUBVAR.Colors highlightColor = PUBVAR.Colors.Green,
                                                BorderStyles borderStyle = BorderStyles.Style_SpeechBox,
                                                bool autosizeBox = false, bool isCentered = false)
        {

            List<string> lEqualWidthStrings = TextSplitter.SplitUpText(textToPutInBox, textWidth, textHeight);
            List<string> lBoxedStrings = TextBoxer.GetBoxedList_OneBigBox(lEqualWidthStrings, textWidth, borderStyle, autosizeBox,
                                                                        out _, out _, out _, out _, isCentered);

            

            Shape newShape;
            char[,] arr_chars = ArrayMaker.GetCharArr(lBoxedStrings);
            char[,] arr_ColorsFG = new char[arr_chars.GetUpperBound(0) + 1, arr_chars.GetUpperBound(1) + 1];

            if (highlightedWords != null)
            {
                bool[,] highlightCoordArr = GetArr_HighlightedWordFinder(arr_chars, highlightedWords);
                for (int i = 0; i < highlightCoordArr.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < highlightCoordArr.GetUpperBound(1); j++)
                    {
                        if(!highlightCoordArr[i,j])
                                { arr_ColorsFG[i, j] = PUBVAR.GetColorChar(textColor); }
                        else    { arr_ColorsFG[i, j] = PUBVAR.GetColorChar(highlightColor); }
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr_chars.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < arr_chars.GetUpperBound(1); j++)
                    {
                        arr_ColorsFG[i, j] = PUBVAR.GetColorChar(textColor);
                    }
                }
            }

            // Change the Border Color


            // *** Needs arbitrary numbers to find border and highlight.  Eventually needs to be smarter

            // TOP BOTTOM
            for (int i = 0; i < arr_chars.GetUpperBound(1); i++)
            {
                arr_ColorsFG[0, i] = PUBVAR.GetColorChar(borderColor);
                arr_ColorsFG[arr_chars.GetUpperBound(0) - 1, i] = PUBVAR.GetColorChar(borderColor);
            }

            // LEFT & RIGHT
            for (int i = 0; i < arr_chars.GetUpperBound(0); i++)
            {
                arr_ColorsFG[i, 1] = PUBVAR.GetColorChar(borderColor);
                arr_ColorsFG[i, arr_chars.GetUpperBound(1)-3] = PUBVAR.GetColorChar(borderColor);
            }


            newShape = new Shape(arr_chars, arr_ColorsFG);


            return newShape;
        }


        /// <summary>
        /// Return a textbox shape that will "type" out more of its text each tick at user defined speed until the text is complete 
        /// </summary>
        /// <param name="textToPutInBox"> The full string of text </param>
        /// <param name="maxBoxWidth"> max width of the box </param>
        /// <param name="typingSpeed"> characters per tick </param>
        /// <param name="borderColor"> color of box borders </param>
        /// <param name="textColor"> color of text color </param>
        /// <param name="borderStyle"> style of border </param>
        /// <param name="autosizeBox"> shrink box to fit text if true, otherwise lock at max width </param>
        /// <param name="lHighlightedWords"> list of words to highlight within the text </param>
        /// <returns></returns>
        public Typer_TextBox CreateShape_TyperTextbox(string textToPutInBox, int maxBoxWidth = 25, int typingSpeed = 2,
                                                                        PUBVAR.Colors borderColor = PUBVAR.Colors.White, PUBVAR.Colors textColor = PUBVAR.Colors.White,
                                                                        BorderStyles borderStyle = BorderStyles.Style_SpeechBox, 
                                                                        bool autosizeBox = false, bool isCentered = false,
                                                                        List<string> lHighlightedWords = null, PUBVAR.Colors highlightColor = PUBVAR.Colors.Green)
        {

            char[,] textBox_TyperArr = GetTextBox(textToPutInBox, maxBoxWidth, borderStyle, autosizeBox,
                                                out int topBorderHeight, out int botBorderHeight,
                                                out int leftBorderWidth, out int rightBorderWidth,
                                                isCentered);


            Typer_TextBox newShape = new Typer_TextBox(textBox_TyperArr, null, null,
                                                    topBorderHeight, botBorderHeight,
                                                    leftBorderWidth, rightBorderWidth,
                                                    PUBVAR.GetColorChar(borderColor), PUBVAR.GetColorChar(textColor),
                                                    typingSpeed, 
                                                    lHighlightedWords, PUBVAR.GetColorChar(highlightColor));

            return newShape;
        }


       

        /// <summary>
        /// A typing line that will reflect keypresses by the user
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="lineLength"></param>
        /// <returns></returns>
        public UserInput_TypeLine CreateShape_TypingLine( int top, int left, int lineLength = 20)
        {
            char topChar = '.';
            char botChar = Convert.ToChar(254);
            
            string lineString = string.Concat(Enumerable.Repeat(topChar, lineLength));
            string lineString2 = string.Concat(Enumerable.Repeat(botChar, lineLength));
            List<string> lines = new List<string>();
            lines.Add(lineString);
            lines.Add(lineString2);

            char[,] arrChars = PUBVAR.GetCharArr(lines);

            Variations.TextBoxShapes.StringEdit.Blinker ConsoleBlinker = CreateABlinker();
            ConsoleBlinker.SetShapeCoordinates(top, left);
            ConsoleBlinker.Tick_MakeVisible();
            ConsoleBlinker.ShapeStatus = Shape.ShapeStatuses.AbsoluteTop;

            UserInput_TypeLine newLineShape = new UserInput_TypeLine(ConsoleBlinker, arrChars, null, null);
            newLineShape.SetShapeCoordinates(top, left);
            return newLineShape ;
                       

            Variations.TextBoxShapes.StringEdit.Blinker CreateABlinker()
            {
                return new Variations.TextBoxShapes.StringEdit.Blinker(new char[1, 1],null,null, Convert.ToChar(249));
            }
        }


        /// <summary>
        /// Returns a shape for the string (just a string, no box, etc.)
        /// </summary>
        /// <param name="stringToMakeIntoShape"></param>
        /// <returns></returns>
        public Shape CreateShape_StringOnly(string stringToMakeIntoShape)
        {
            List<string> lstringToMakeIntoShape = new List<string> { stringToMakeIntoShape };
            char[,] myArr = ArrayMaker.GetCharArr(lstringToMakeIntoShape);
            return new Shape(myArr);
        }




        /// <summary>
        /// Returns a bool array of size equal to the char array you put in. Every spot that's TRUE is represents where a highlighted word is (or rather, where each of its letters are)
        /// </summary>
        /// <param name="charArrayToCheck"></param>
        /// <param name="listOfHighlightWords"></param>
        /// <returns></returns>
        bool[,] GetArr_HighlightedWordFinder(char[,] charArrayToCheck, List<string> listOfHighlightWords)
        {
            bool[,] returnArr = new bool[charArrayToCheck.GetUpperBound(0) + 1, charArrayToCheck.GetUpperBound(1) + 1];

            string highlightString;


            for (int i = 0; i < charArrayToCheck.GetUpperBound(0); i++)
            {
                for (int j = 0; j < charArrayToCheck.GetUpperBound(1); j++)
                {
                    // Run through arr for each highlighted word
                    for (int h = 0; h < listOfHighlightWords.Count; h++)
                    {
                        highlightString = listOfHighlightWords[h];

                        // First letter matched and previous char is allowed
                        if (char.ToUpper(charArrayToCheck[i, j]) == char.ToUpper(highlightString[0]) && CheckIfAllowedStartEndChar(charArrayToCheck[i, j - 1]))
                        {

                            for (int c = 0; c < highlightString.Length; c++)
                            {
                                char checkChar = char.ToUpper(charArrayToCheck[i, j + c]);

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
                                            // Only set this coord as TRUE if word there is a space or punctuation after
                                            if (CheckIfAllowedStartEndChar(charArrayToCheck[i, j + c + 1]))
                                            {
                                                returnArr[i, j + v] = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return returnArr;




            //-----------------------------------------------------------

            
            bool CheckIfAllowedStartEndChar(char charToCheck)
            {
                List<char> lAllowedStartEndChars = new List<char>() { '!', '"', '.', '?', ' ', ']', '(', ')', '[',']', '\'' };

                for (int i = 0; i < lAllowedStartEndChars.Count; i++)
                {
                    if (charToCheck == lAllowedStartEndChars[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }








        public enum BorderStyles
        {
            Style0,
            Style01,
            Style_SpeechBox,
            Style2,
            Style3,
            Style4
        }
    }
}
