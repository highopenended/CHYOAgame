using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Startup
{
    public static class MainUI_DisplayMaker
    {
        public static void Make_UI()
        {
            Create_EventColumn();

            void Create_EventColumn()
            {
                CEdit.Shapes.ShapeMaker_Text TextBoxMaker = new CEdit.Shapes.ShapeMaker_Text();

                int width = Shared.EventColumn_Update.EventColumnWidth;
                int widthInt = (width - 4) * (PUBVAR.windowHeight + 2);
                string emptyLine = string.Concat(Enumerable.Repeat(" ", widthInt));
                
                
                CEdit.Shapes.Shape myBox = TextBoxMaker.CreateShape_StaticTextbox(emptyLine, width, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style01);
                myBox.SetShapeCoordinates(0, Shared.EventColumn_Update.EventColumnLeft);
                CEdit.DisplayLists.AddToWaitList_AddToMasterList(myBox);
            }
        }
    }
}
