
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes
{
    public class ShapeMaker_SelectionBox
    {
        /// <summary>
        /// Returns a "Selection Box" shape which is a box that is slightly bigger than the shape it's meant to surround.
        /// </summary>
        /// <param name="shape_ThatNeedsSelectionBox"></param>
        /// <returns></returns>
        public Shape CreateShape_SelectionBox(Shape shape_ThatNeedsSelectionBox, PUBVAR.Colors selectionBoxColor = PUBVAR.Colors.Cyan)
        {
            int sBox_Height = shape_ThatNeedsSelectionBox.Height;
            int sBox_Width = shape_ThatNeedsSelectionBox.Width;

            int extraWidth = 3;
            int extraHeight = 3;

            char[,] newArr_Chars = new char[sBox_Height + extraHeight, sBox_Width + extraWidth];
            char[,] newArr_ColorsFG = new char[sBox_Height + extraHeight, sBox_Width + extraWidth];
            char[,] newArr_ColorsBG = new char[sBox_Height + extraHeight, sBox_Width + extraWidth];

            FillArrs_LeftAndRight_Borders();
            FillArrs_TopAndBot_Borders();

            Shape newShape = new Shape(newArr_Chars, newArr_ColorsFG, newArr_ColorsBG);

            SetStartingCoordinates();

            return newShape;

            // -----------------------------------

            void FillArrs_LeftAndRight_Borders()
            {
                for (int i = 0; i < newArr_Chars.GetUpperBound(0); i++)
                {
                    newArr_ColorsBG[i, 0] = PUBVAR.GetColorChar(selectionBoxColor);
                    newArr_ColorsBG[i, newArr_ColorsBG.GetUpperBound(1)-1] = PUBVAR.GetColorChar(selectionBoxColor);
                }
            }
            void FillArrs_TopAndBot_Borders()
            {
                for (int i = 0; i < newArr_Chars.GetUpperBound(1); i++)
                {
                    newArr_ColorsBG[0, i] = PUBVAR.GetColorChar(selectionBoxColor);
                    newArr_ColorsBG[newArr_ColorsBG.GetUpperBound(0) - 1, i] = PUBVAR.GetColorChar(selectionBoxColor);
                }
            }
            void SetStartingCoordinates()
            {
                newShape.SetShapeCoordinates(shape_ThatNeedsSelectionBox.Top - 1, shape_ThatNeedsSelectionBox.Left - 1);
            }
        }
    }
}
