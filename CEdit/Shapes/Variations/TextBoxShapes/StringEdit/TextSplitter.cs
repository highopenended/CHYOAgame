using System;
using System.Collections.Generic;
using System.Linq;

namespace Chyoa.CEdit.Shapes.Variations.TextBoxShapes.StringEdit
{
    public class TextSplitter
    {

        string forceSplitChar = "@";

        /// <summary>
        /// Breaks up a single string into multiple equal-length strings
        /// </summary>
        /// <param name="textToSplit"> The string to split up </param>
        /// <param name="maxLength"> Max length any one string is allowed to be </param>
        /// <returns></returns>
        public List<string> SplitUpText(string textToSplit, int maxLength)
        {
            List<string> returnString = new List<string>();
            List<string> lSeperatedWords = new List<string>();

            int startPoint = 0;
            int endPoint;
            int checkLength;
            string nextWord;

            //---------------------------------------------------
            // Get the list of words
            //---------------------------------------------------
            bool continueLoop = true;
            while (continueLoop)
            {
                checkLength = Math.Min(textToSplit.Length - startPoint, maxLength);
                endPoint = textToSplit.IndexOf(" ", startPoint, checkLength);

                // End loop once the end is found
                if (endPoint == -1)
                {
                    endPoint = textToSplit.Length;
                    continueLoop = false;
                }

                // Get the next word and add a space to it
                nextWord = textToSplit.Substring(startPoint, endPoint - startPoint);

                if (nextWord != "")
                        { lSeperatedWords.Add(nextWord + " "); }
                else    { lSeperatedWords.Add(" "); }

                startPoint = endPoint + 1;
            }


            //---------------------------------------------------
            // Make strings that fit within boundaries
            //---------------------------------------------------
            string tempWord;
            string lineOfStrings = "";
            for (int i = 0; i < lSeperatedWords.Count; i++)
            {
                tempWord = lSeperatedWords[i];

                if (tempWord != (forceSplitChar + " "))
                {
                    if (lineOfStrings.Length + tempWord.Length <= maxLength)
                    {
                        lineOfStrings += (tempWord);
                        if (i == lSeperatedWords.Count - 1) { returnString.Add(lineOfStrings); }
                    }
                    else
                    {
                        returnString.Add(lineOfStrings);
                        lineOfStrings = tempWord;
                        if (i == lSeperatedWords.Count - 1)
                        {
                            returnString.Add(lineOfStrings);
                        }
                    }
                }
                else
                {
                    returnString.Add(lineOfStrings);
                    lineOfStrings = "";
                }
            }

            return returnString;
        }





        /// <summary>
        /// Breaks up a single string into multiple equal-length strings AND adds blank lines to make the box the right height
        /// </summary>
        /// <param name="textToSplit"> The text to split up </param>
        /// <param name="textArea_Width"> The width of the text area </param>
        /// <param name="textArea_Height"> The height of the text area </param>
        /// <returns></returns>
        public List<string> SplitUpText(string textToSplit, int textArea_Width, int textArea_Height)
        {
            List<string> lTextStrings = new List<string>();
            List<string> lTextStrings_WithBlankLines = new List<string>();
            List<string> lSeperatedWords = new List<string>();

            int startPoint = 0;
            int endPoint;
            int checkLength;
            string nextWord;

            //---------------------------------------------------
            // Get the list of words
            //---------------------------------------------------
            bool continueLoop = true;
            while (continueLoop)
            {
                checkLength = Math.Min(textToSplit.Length - startPoint, textArea_Width);
                endPoint = textToSplit.IndexOf(" ", startPoint, checkLength);

                // End loop once the end is found
                if (endPoint == -1)
                {
                    endPoint = textToSplit.Length;
                    continueLoop = false;
                }

                // Get the next word and add a space to it
                nextWord = textToSplit.Substring(startPoint, endPoint - startPoint);

                if (nextWord != "")
                        { lSeperatedWords.Add(nextWord + " "); }
                else    { lSeperatedWords.Add(" "); }

                startPoint = endPoint + 1;
            }


            //---------------------------------------------------
            // Make strings that fit within boundaries
            //---------------------------------------------------
            string tempWord;
            string lineOfStrings = "";
            for (int i = 0; i < lSeperatedWords.Count; i++)
            {
                tempWord = lSeperatedWords[i];

                if (tempWord != (forceSplitChar + " "))
                {
                    if (lineOfStrings.Length + tempWord.Length <= textArea_Width)
                    {
                        lineOfStrings += (tempWord);
                        if (i == lSeperatedWords.Count - 1) { lTextStrings.Add(lineOfStrings); }
                    }
                    else
                    {
                        lTextStrings.Add(lineOfStrings);
                        lineOfStrings = tempWord;
                        if (i == lSeperatedWords.Count - 1)
                        {
                            lTextStrings.Add(lineOfStrings);
                        }
                    }
                }
                else
                {
                    lTextStrings.Add(lineOfStrings);
                    lineOfStrings = "";
                }
            }

            // Add the blank text lines to even out the 
            Add_BlankLines();

            return lTextStrings_WithBlankLines;




            void Add_BlankLines()
            {
                int blankLineCount = 0;
                if (lTextStrings.Count < textArea_Height)
                {
                    blankLineCount = textArea_Height - lTextStrings.Count;
                }

                int blankLines_Top = blankLineCount / 2;
                int blankLines_Bot = blankLineCount - blankLines_Top;

                string blankLine = string.Concat(Enumerable.Repeat(" ", textArea_Width));

                // Add top blank lines
                for (int i = 0; i < blankLines_Top; i++)
                {
                    lTextStrings_WithBlankLines.Add(blankLine);
                }

                // If the box is too small, then the text will get cut off
                int stringsToAdd;
                if(blankLines_Bot > 0)
                        { stringsToAdd = lTextStrings.Count; }
                else    { stringsToAdd = (lTextStrings.Count - blankLines_Top); }


                // Add strings
                if (stringsToAdd <= textArea_Height)
                {
                    for (int i = 0; i < stringsToAdd; i++)
                    {
                        lTextStrings_WithBlankLines.Add(lTextStrings[i]);
                    }
                }
                else
                {
                    // Cut off bottom lines if there isn't enough room in box since size is preset
                    for (int i = 0; i < textArea_Height; i++)
                    {
                        lTextStrings_WithBlankLines.Add(lTextStrings[i]);
                    }
                }

                // Add bottom blank lines
                for (int i = 0; i < blankLines_Bot; i++)
                {
                    lTextStrings_WithBlankLines.Add(blankLine);
                }
            }
        }
    }
}
