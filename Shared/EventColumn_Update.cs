using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chyoa.CEdit.Shapes.Variations.TextBoxShapes;

namespace Chyoa.Shared
{
    public static class EventColumn_Update
    {

        public static readonly int EventColumnLeft = PUBVAR.windowWidth - 60;
        public static readonly int AlertLeft = EventColumnLeft + 2;
        public static readonly int EventColumnWidth = 50;
        public static readonly int EventMessage_Lifetime = 250;
        public static readonly int EventMessage_WaitToCorrectCoords = 100;
        static CEdit.Shapes.ShapeMaker_Text TextBoxMaker = new CEdit.Shapes.ShapeMaker_Text();

        

        static List<Typer_TextBox> lEventMessages = new List<Typer_TextBox>();

        /// <summary>
        /// Adds a new event message to the event column.  Pushes the other messages down one spot
        /// </summary>
        /// <param name="EventMessage"> The message you wish to display </param>
        /// <param name="borderColor"> The event message borders </param>
        /// <param name="textColor"> The event message text colors </param>
        /// <param name="lHighlightedWords"> a list of words to highlight</param>
        /// <param name="highlightColor"> What color to highlight the words </param>
        public static void AddEvent_To_EventColumn(string EventMessage, PUBVAR.Colors borderColor, PUBVAR.Colors textColor, int topStart = -1, int leftStart = -1, List<string> lHighlightedWords = null, PUBVAR.Colors highlightColor = PUBVAR.Colors.Green)
        {

            string currentTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;






            EventMessage = currentTime + " @ @ " + EventMessage;
            Get_NewTextBox(out Typer_TextBox NewTextBox);
            Add_NewTextBox_To_List(NewTextBox);
            Set_StartingCoordinates(NewTextBox);
            Update_All_BoxCoordinates(NewTextBox.Height);

            CEdit.DisplayLists.AddToWaitList_AddToMasterList(NewTextBox);




            //_________________________________________________
            //      INTERNAL METHODS



            // Get the new typer text box shape for this new message
            void Get_NewTextBox(out Typer_TextBox newTextBox)
            {
                //EventMessage = GetRandomErrorMessage();
                newTextBox = TextBoxMaker.CreateShape_TyperTextbox(EventMessage, EventColumnWidth - 5, 7, borderColor, textColor, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style0, false, true, lHighlightedWords, highlightColor);
                newTextBox.CountDown_EventColumn = EventMessage_Lifetime;
            }
            
            // Add the new box to the list
            void Add_NewTextBox_To_List(Typer_TextBox newTextBox)
            {
                List<Typer_TextBox> tempList = new List<Typer_TextBox>();
                tempList.Add(newTextBox);
                for (int i = 0; i < lEventMessages.Count; i++)
                {
                    tempList.Add(lEventMessages[i]);
                }

                lEventMessages.Clear();
                for (int i = 0; i < tempList.Count; i++)
                {
                    lEventMessages.Add(tempList[i]);
                }
            }



            // Set the starting coordinates of a new event message
            
            void Set_StartingCoordinates(Typer_TextBox newTextBox)
            {
                // -1 means to just start in the event column (instead of somewhere else on the screen)
                int startLeft;
                if (leftStart == -1)
                        { startLeft = AlertLeft; }
                else    { startLeft = leftStart; }

                // -1 means to just start in the event column (instead of somewhere else on the screen)
                int startTop;
                if (topStart == -1)
                        { startTop = (1 - newTextBox.Height); }
                else    { startTop = topStart; }

               

                newTextBox.SetShapeCoordinates(startTop, startLeft);
                NewTextBox.TrueTopCoord_EventColumn = (1 - newTextBox.Height);

                if (startLeft != AlertLeft) { NewTextBox.NeedsCoordinateCorrection_EventColumn = true; }
            }

            // Add movement plans to all the shapes
            void Update_All_BoxCoordinates(int newTextBoxHeight)
            {
                for (int i = 0; i < lEventMessages.Count; i++)
                {
                    int downMoveDistance = newTextBoxHeight + 1;
                    if (lEventMessages[i].Left == AlertLeft)
                    {
                        lEventMessages[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, downMoveDistance);
                    }
                    else
                    {
                        lEventMessages[i].TrueTopCoord_EventColumn += downMoveDistance;
                    }
                }
            }
            string GetRandomErrorMessage()
            {
                int checkNumber = myRand.Next(0, 10);

                switch(checkNumber)
                {
                    case 0:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkYellow;
                        return "This is a test message.";

                    case 1:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkYellow;
                        return "This is a different test message.";

                    case 2:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkRed;
                        return "You can't go that way...";

                    case 3:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkRed;
                        return "You can't afford that!";

                    case 4:
                        borderColor = PUBVAR.Colors.Red;
                        textColor = PUBVAR.Colors.Red;
                        return "Your health has dropped to zero...";

                    case 5:
                        borderColor = PUBVAR.Colors.Cyan;
                        textColor = PUBVAR.Colors.Magenta;
                        return "You see a very large idiot. It's a mirror. Sick burn. You got sickly burned.";

                    case 6:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkMagenta;
                        return "I'm sick of being tired and tired of being sick.";

                    case 7:
                        borderColor = PUBVAR.Colors.DarkGray;
                        textColor = PUBVAR.Colors.Yellow;
                        return "...Did you hear something?";

                    case 8:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkYellow;
                        return "Where the hell am I!?";

                    case 9:
                        borderColor = PUBVAR.Colors.Blue;
                        textColor = PUBVAR.Colors.Green;
                        return "You found a new item!";

                    default:
                        borderColor = PUBVAR.Colors.White;
                        textColor = PUBVAR.Colors.DarkYellow;
                        return "What even is that?";
                }
            }            
        }


        public static void Update_On_Tick()
        {
            Update_Timers();
            Update_Removals();
            Update_Coordinates();
        }

        static void Update_Timers()
        {
            for (int i = 0; i < lEventMessages.Count; i++)
            {
                lEventMessages[i].Step_Countdown();
                if(lEventMessages[i].CountDown_EventColumn <= 0)
                {
                    lEventMessages[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Right, 50);
                    lEventMessages[i].AddMovementPlan_DeleteThisShape();                    
                }
            }
        }

        static void Update_Removals()
        {
            List<Typer_TextBox> tempList_Shapes = new List<Typer_TextBox>();


            for (int i = 0; i < lEventMessages.Count; i++)
            {
                bool AddToList = true;
                for (int j = 0; j < ListToRemove_Shapes.Count; j++)
                {
                    if (lEventMessages[i] == ListToRemove_Shapes[j])
                    {
                        AddToList = false;
                    }
                }
                if (AddToList)
                {
                    tempList_Shapes.Add(lEventMessages[i]);
                }
            }
            lEventMessages.Clear();
            ListToRemove_Shapes.Clear();

            for (int i = 0; i < tempList_Shapes.Count; i++)
            {
                lEventMessages.Add(tempList_Shapes[i]);
            }
        }

        // If the shape's left isn't where it should be and the timer has gone far enough, it will auto correct
        static void Update_Coordinates()
        {
            for (int i = 0; i < lEventMessages.Count; i++)
            {
                if (lEventMessages[i].Left != AlertLeft)
                {
                    if (lEventMessages[i].CountDown_EventColumn <= (EventMessage_Lifetime - EventMessage_WaitToCorrectCoords))
                    {
                        if (lEventMessages[i].NeedsCoordinateCorrection_EventColumn)
                        {
                            lEventMessages[i].NeedsCoordinateCorrection_EventColumn = false;
                            lEventMessages[i].Clear_MovementPlan();


                            int dest_Row = lEventMessages[i].TrueTopCoord_EventColumn;
                            int dest_Col = AlertLeft;
                            lEventMessages[i].AddMovementPlan_MoveToLocation(dest_Row, dest_Col);
                        }
                    }                   
                }
            }
        }


        static List<Typer_TextBox> ListToRemove_Shapes = new List<Typer_TextBox>();
        static Random myRand = new Random();
    }
}
