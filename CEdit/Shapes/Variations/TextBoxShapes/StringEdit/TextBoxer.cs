using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.TextBoxShapes.StringEdit
{
    public class TextBoxer
    {
        readonly char emptySpaceChar = ' ';
        readonly int minLeadTrailSpaces = 2;


        /// <summary>
        /// Input a list of equal length strings and get out a list of string representing a boxed in version of those strnig
        /// </summary>
        /// <param name="equalWidthStrings">  Has to be equal widths, even if spaces are required </param>
        /// <param name="maxBoxWidth"> The maximum width allowed for the box </param>
        /// <param name="borderStyle"> Choose a style </param>
        /// <param name="autosizeBox"> If true, then the box may be smaller than the max size if it can (but never larger) </param>
        /// <returns></returns>
        public List<string> GetBoxedList_OneBigBox(List<string> equalWidthStrings, int maxBoxWidth, ShapeMaker_Text.BorderStyles borderStyle, bool autosizeBox,
                                                    out int bHeight_Top, out int bHeight_Bot,
                                                    out int bWidth_Left, out int bWidth_Right,
                                                    bool isCentered)
        {            
            
            // Convert spaces to omitChar
            for (int i = 0; i < equalWidthStrings.Count; i++) { equalWidthStrings[i] = equalWidthStrings[i].Replace(' ', emptySpaceChar); }

            // Find the longest string length
            int longestStringLength = equalWidthStrings.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

                        
            // Set the longest string width if it's autosized (might be smaller)
            if (!autosizeBox)
            {
                if (longestStringLength < maxBoxWidth - minLeadTrailSpaces){ longestStringLength = maxBoxWidth - minLeadTrailSpaces; }
            }

            int totalWordSpaceWidth = longestStringLength + (minLeadTrailSpaces * 2);

            // Set the borderstyle properties
            SetBorderStyle(borderStyle, totalWordSpaceWidth,
                        out string topCorner1, out string topCorner2,
                        out string botCorner1, out string botCorner2,
                        out string leftBorder, out string rightBorder, 
                        out string topBorder, out string botBorder);

            
            bHeight_Top = 1;
            bHeight_Bot = 1;
            bWidth_Left = leftBorder.Length;
            bWidth_Right = rightBorder.Length;


            List<string> lBoxedStrings = new List<string>();
            lBoxedStrings.Add(topBorder);

            for (int i = 0; i < equalWidthStrings.Count; i++)
            {

                int totalSpaceCount = totalWordSpaceWidth - equalWidthStrings[i].Length;


                int leadingSpaceCount;

                if(!isCentered)
                        { leadingSpaceCount = 2;  }
                else    { leadingSpaceCount = totalSpaceCount / 2; }

                int trailingSpacesCount = totalSpaceCount - leadingSpaceCount;

                string leadingSpaces = string.Concat(Enumerable.Repeat(emptySpaceChar, leadingSpaceCount));
                string trailingSpaces = string.Concat(Enumerable.Repeat(emptySpaceChar, trailingSpacesCount));

                string midString = leftBorder + leadingSpaces + equalWidthStrings[i] + trailingSpaces + rightBorder;

                lBoxedStrings.Add(midString);
            }

            lBoxedStrings.Add(botBorder);

            return lBoxedStrings;

        }



        public void GetBorderMeasurements(ShapeMaker_Text.BorderStyles style,
                                            out int bHeight_Top, out int bHeight_Bot,
                                            out int bWidth_Left, out int bWidth_Right)
        {
            SetBorderStyle(style, 10, out _, out _, out _, out _, 
                            out string leftBorder, out string rightBorder, 
                            out _, out _);
             
            bHeight_Top = 1;
            bHeight_Bot = 1;
            bWidth_Left = leftBorder.Length;
            bWidth_Right = rightBorder.Length;
        }





        //__________________________________________________
        //      Choose the border style properties
        //__________________________________________________
        void SetBorderStyle(ShapeMaker_Text.BorderStyles _borderStyle, int totalWordSpaceWidth,
            out string _topCorner1, out string _topCorner2,
            out string _botCorner1, out string _botCorner2,
            out string _leftBorder, out string _rightBorder,
            out string _topBorder, out string _botBorder)
        {

            switch (_borderStyle)
            {
                case ShapeMaker_Text.BorderStyles.Style0:
                    _topCorner1 = " " + Convert.ToChar(218) + Convert.ToChar(196); _topCorner2 = Convert.ToChar(175) + "  ";
                    _leftBorder = " " + Convert.ToChar(179) + Convert.ToChar(17); _rightBorder = Convert.ToChar(222) + "  ";
                    _botCorner1 = " " + Convert.ToChar(192) + Convert.ToChar(254); _botCorner2 = Convert.ToChar(254) + "  ";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(196), totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(254), totalWordSpaceWidth)) + _botCorner2;
                    break;

                case ShapeMaker_Text.BorderStyles.Style01:

                    _topCorner1 = " " + Convert.ToChar(218) + Convert.ToChar(196); _topCorner2 = Convert.ToChar(249) + "  ";
                    _leftBorder = " " + Convert.ToChar(179) + " "; _rightBorder = Convert.ToChar(222) + "  ";
                    _botCorner1 = " " + Convert.ToChar(192) + Convert.ToChar(254); _botCorner2 = Convert.ToChar(254) + "  ";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(196), totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(254), totalWordSpaceWidth)) + _botCorner2;
                    break;

                case ShapeMaker_Text.BorderStyles.Style_SpeechBox:
                    _topCorner1 = " " + Convert.ToChar(218) + Convert.ToChar(196); _topCorner2 = Convert.ToChar(175) + "  ";
                    _leftBorder = " " + Convert.ToChar(179) + " "; _rightBorder = Convert.ToChar(222) + "  ";
                    _botCorner1 = " " + Convert.ToChar(192) + Convert.ToChar(254); _botCorner2 = Convert.ToChar(254) + "  ";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(196), totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat(Convert.ToChar(254), totalWordSpaceWidth)) + _botCorner2;
                    break;

                case ShapeMaker_Text.BorderStyles.Style2:
                    _topCorner1 = "[]"; _topCorner2 = "[]";
                    _leftBorder = "[]"; _rightBorder = "[]";
                    _botCorner1 = "[]"; _botCorner2 = "[]";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _botCorner2;
                    break;


                case ShapeMaker_Text.BorderStyles.Style3:
                    _topCorner1 = "[=]"; _topCorner2 = "[=]";
                    _leftBorder = "[|]"; _rightBorder = "[|]";
                    _botCorner1 = "[_]"; _botCorner2 = "[_]";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _botCorner2;
                    break;


                case ShapeMaker_Text.BorderStyles.Style4:
                    _topCorner1 = "[ ]"; _topCorner2 = "[ ]";
                    _leftBorder = "} {"; _rightBorder = "} {";
                    _botCorner1 = "[ ]"; _botCorner2 = "[ ]";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _botCorner2;
                    break;


                default:
                    _topCorner1 = "[]"; _topCorner2 = "[]";
                    _leftBorder = "[]"; _rightBorder = "[]";
                    _botCorner1 = "[]"; _botCorner2 = "[]";
                    _topBorder = _topCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _topCorner2;
                    _botBorder = _botCorner1 + string.Concat(Enumerable.Repeat("=", totalWordSpaceWidth)) + _botCorner2;
                    break;
            }
        }
    }
}
