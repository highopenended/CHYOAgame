using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit
{
    public class ArrayMaker
    {
        public char[,] GetCharArr(List<string> listOfStrings)
        {
            int height, width;

            height = listOfStrings.Count;
            width = height > 0 ? listOfStrings[0].Length : 0;


            char[,] returnArr = new char[height + 1, width + 1];

            for (int i = 0; i < height; i++)
            {
                string textLine = listOfStrings[i];
                char[] charRow = textLine.ToCharArray();
                for (int j = 0; j < width; j++)
                {
                    returnArr[i, j] = charRow[j];
                }
            }
            return returnArr;
        }



        public void GetCharArr(List<string> listOfStrings, List<string> listOfHighlightedWords, out char[,] charArray)
        {
            int height, width;

            height = listOfStrings.Count;
            width = height > 0 ? listOfStrings[0].Length : 0;

            charArray = new char[height + 1, width + 1];
            for (int i = 0; i < height; i++)
            {
                string textLine = listOfStrings[i];

                char[] charRow = textLine.ToCharArray();
                for (int j = 0; j < width; j++)
                {
                    charArray[i, j] = charRow[j];
                }
            }

        }
    }
}
