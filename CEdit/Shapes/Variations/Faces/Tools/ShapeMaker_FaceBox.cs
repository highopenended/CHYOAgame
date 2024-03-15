using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Faces.Tools
{
    public class ShapeMaker_FaceBox
    {

        static int spaceBetween_Edges_LR = 2;
        static int spaceBetween_Edges_Bottom = 0;
        static int spaceBetween_Edges_Top = 4;

        /// <summary>
        /// Takes three arrays, and outs those same values in a bigger array with a "face box" around it
        /// </summary>
        /// <param name="faceArr_Chars"></param>
        /// <param name="faceArr_Chars_ColorsFG"></param>
        /// <param name="faceArr_Chars_ColorsBG"></param>
        /// <param name="faceArr_Chars_WithBox"></param>
        /// <param name="faceArr_ColorsFG_WithBox"></param>
        /// <param name="faceArr_ColorsBG_WithBox"></param>
        /// <returns></returns>
        public void Get_FaceBoxArrays(char[,] faceArr_Chars, char[,] faceArr_Chars_ColorsFG, char[,] faceArr_Chars_ColorsBG,
                                        out char[,] faceArr_Chars_WithBox,
                                        out char[,] faceArr_ColorsFG_WithBox,
                                        out char[,] faceArr_ColorsBG_WithBox)
        {
            int boxHeight = faceArr_Chars.GetUpperBound(0) + spaceBetween_Edges_Bottom + spaceBetween_Edges_Top + 1;
            int boxWidth = faceArr_Chars.GetUpperBound(1) + (2 * (spaceBetween_Edges_LR + 1)) + 1;
            
            faceArr_Chars_WithBox = FillArray_Chars();
            faceArr_ColorsFG_WithBox = FillArray_ColFG();
            faceArr_ColorsBG_WithBox = FillArray_ColBG();

           //-------------------------------------------------
            // Make the boxed version of each array
            char[,] FillArray_Chars()
            {
                char[,] boxArr = new char[boxHeight + 1, boxWidth];

                // Left and Right
                for (int i = 0; i < boxArr.GetUpperBound(0); i++)
                {
                    boxArr[i, 0] = Convert.ToChar(178);
                    boxArr[i, boxArr.GetUpperBound(1) - 1] = Convert.ToChar(178);
                }

                // Top and Bottom rows
                for (int i = 0; i < boxArr.GetUpperBound(1); i++)
                {
                    boxArr[0, i] = Convert.ToChar(219);

                    if (i == 0) { boxArr[2, i] = Convert.ToChar(219); }
                    else if (i == boxArr.GetUpperBound(1) - 1) { boxArr[2, i] = Convert.ToChar(219); }
                    else { boxArr[2, i] = Convert.ToChar(220); }

                    boxArr[boxArr.GetUpperBound(0) - 1, i] = Convert.ToChar(223);
                }

                for (int i = 0; i < faceArr_Chars.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < faceArr_Chars.GetUpperBound(1); j++)
                    {
                        boxArr[i + spaceBetween_Edges_Top, j + spaceBetween_Edges_LR + 1] = faceArr_Chars[i, j];
                    }
                }

                return boxArr;
            }
            char[,] FillArray_ColFG(char fgColor = 'W')
            {
                char[,] boxArr = new char[boxHeight + 1, boxWidth];

                // Left and Right
                for (int i = 0; i < boxArr.GetUpperBound(0); i++)
                {
                    boxArr[i, 0] = fgColor;
                    boxArr[i, boxArr.GetUpperBound(1) - 1] = fgColor;
                }

                // Top and Bottom rows
                for (int i = 0; i < boxArr.GetUpperBound(1); i++)
                {
                    boxArr[0, i] = fgColor;
                    boxArr[boxArr.GetUpperBound(0) - 1, i] = fgColor;
                }

                // Put input array "inside" of the box
                for (int i = 0; i < faceArr_Chars_ColorsFG.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < faceArr_Chars_ColorsFG.GetUpperBound(1); j++)
                    {
                        boxArr[i + spaceBetween_Edges_Top, j + spaceBetween_Edges_LR + 1] = faceArr_Chars_ColorsFG[i, j];
                    }
                }
                return boxArr;
            }
            char[,] FillArray_ColBG(char bgColor = 'X')
            {
                char[,] boxArr = new char[boxHeight + 1, boxWidth];

                // Left and Right
                for (int i = 0; i < boxArr.GetUpperBound(0); i++)
                {
                    boxArr[i, 0] = bgColor;
                    boxArr[i, boxArr.GetUpperBound(1) - 1] = bgColor;
                }

                // Top and Bottom rows
                for (int i = 0; i < boxArr.GetUpperBound(1); i++)
                {
                    boxArr[0, i] = bgColor;
                    boxArr[boxArr.GetUpperBound(0) - 1, i] = bgColor;
                }
                // Put input array "inside" of the box
                for (int i = 0; i < faceArr_Chars_ColorsBG.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < faceArr_Chars_ColorsBG.GetUpperBound(1); j++)
                    {
                        boxArr[i + spaceBetween_Edges_Top, j + spaceBetween_Edges_LR + 1] = faceArr_Chars_ColorsBG[i, j];
                    }
                }
                return boxArr;
            }
        }
    }  
}
