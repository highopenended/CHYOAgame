using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes
{
    public class ShapeMaker_CustomBox
    {
        Variations.TextBoxShapes.StringEdit.TextBoxer TextBoxer = new Variations.TextBoxShapes.StringEdit.TextBoxer();


        public Shape Get_CustomBox(int width, int height, ShapeMaker_Text.BorderStyles borderStyle)
        {
            List<string> ListOfEmptySpaces = new List<string>();



            // Get the proper size of the "text" so the box comes out to the size requested by user
            TextBoxer.GetBorderMeasurements(borderStyle, out int bHeight_Top, out int bHeight_Bot, out int bWidthLeft, out int bWidth_Right);
            width = width - bWidthLeft - bWidth_Right;
            string strSpaces = string.Concat(Enumerable.Repeat(" ", width));


            // Create the list of strings
            for (int i = 0; i < height; i++)
            {
                ListOfEmptySpaces.Add(strSpaces);
            }

            ArrayMaker arrayMaker = new ArrayMaker();
            List<string> emptyBoxList = TextBoxer.GetBoxedList_OneBigBox(ListOfEmptySpaces, width, borderStyle, false, out _, out _, out _, out _, false);
            char[,] arrChars = arrayMaker.GetCharArr(emptyBoxList);

            return new Shape(arrChars);
        }
    }
}
