using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets.SceneTools
{
    public class DescriptionBox_Cycler
    {
        List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfSequenceTextboxes = new List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox>();
        List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfSequenceTextboxes_AlreadyDisplayed = new List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox>();



        /// <summary>
        /// Cycle through a list of description textboxes, cycle through on key-press, then drop them all off the screen after the last one
        /// </summary>
        /// <param name="listOfShapes"></param>
        /// <param name="textBoxLeft"></param>
        /// <param name="textBoxTop"></param>
        public void CycleThrough_ListOfTextBoxes(List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfShapes, int textBoxLeft = 50, int textBoxTop = 10)
        {

            Initialize_Textboxes();

            int cycleCounter = 0;

            // Make the first box immediately visible
            CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox currentTextBox = listOfSequenceTextboxes[cycleCounter];
            currentTextBox.Tick_MakeVisible();
            currentTextBox.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, 10);


            // || True  = Movement was incomplete upon key-press, so the key-press will instantly complete it
            // || False = Movement was already complete upon key-press, so the key-press will continue to the next box
            bool cycleSubCounter;

            bool continueLoop = true;
            while (continueLoop)
            {
                if (PUBVAR.MyReadKey() != null)
                {
                    if (currentTextBox.AllMovementComplete)
                            { cycleSubCounter = false; }
                    else    { cycleSubCounter = true; }
                    TakeNext_SubStep();
                }
            }


            int waitTime = 10;
            int maxWaitTime = 20;
            for (int i = 0; i < listOfSequenceTextboxes_AlreadyDisplayed.Count; i++)
            {
                var box = listOfSequenceTextboxes_AlreadyDisplayed[i];
                if (i < listOfSequenceTextboxes_AlreadyDisplayed.Count - 1)
                {
                    box.AddMovementPlan_Wait(waitTime);
                    box.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, 30);
                    box.AddMovementPlan_DeleteThisShape();

                    if (waitTime + 3 <= maxWaitTime)
                            { waitTime += 3; }
                    else    { waitTime = maxWaitTime; }
                }
                else // Last box already has to move, so it needs shorter waiting time
                {
                    box.AddMovementPlan_Wait(10);
                    box.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, 30);
                    box.AddMovementPlan_DeleteThisShape();
                }
            }


            // Move on to the next step 
            void TakeNext_SubStep()
            {
                switch (cycleSubCounter)
                {
                    // Movement was incomplete upon key-press, so the key-press will instantly complete it
                    case true:
                        currentTextBox.Tick_ImmediatelyCompleteMovement_All();
                        break;

                    // Movement was already complete upon key-press, so the key-press will continue to the next box
                    case false:
                        listOfSequenceTextboxes_AlreadyDisplayed.Add(currentTextBox);
                        currentTextBox.MakeColorArray_MonoColor();
                        Move_ExistingBoxes_Down();
                        GetNextBox();
                        break;
                }


                // Move existing textbox shapes to give room for the new message
                void Move_ExistingBoxes_Down()
                {
                    if ((cycleCounter) < listOfSequenceTextboxes.Count)
                    {
                        int nextBoxHeight;
                        if (cycleCounter + 1 < listOfSequenceTextboxes.Count)
                                { nextBoxHeight = listOfSequenceTextboxes[cycleCounter + 1].Height; }
                        else    { nextBoxHeight = 5; }

                        for (int i = 0; i < listOfSequenceTextboxes_AlreadyDisplayed.Count; i++)
                        {
                            // Newest box moves the furthest
                            if (i == listOfSequenceTextboxes_AlreadyDisplayed.Count - 1)
                            {
                                listOfSequenceTextboxes_AlreadyDisplayed[i].Tick_ChangeStepDistancesUDLR(2, 1);
                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, nextBoxHeight - 1);
                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down_Right, 15);

                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Right, 8);
                            }
                            else // Other boxes only move down slightly
                            {
                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, nextBoxHeight - 1);
                            }
                        }
                    }
                }


                void GetNextBox()
                {
                    if ((cycleCounter) < listOfSequenceTextboxes.Count - 1)
                    {
                        cycleCounter++;
                        currentTextBox = listOfSequenceTextboxes[cycleCounter];
                        currentTextBox.Tick_MakeVisible();
                        currentTextBox.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, 10);
                    }
                    else { continueLoop = false;  }
                }
            }


            // Initialize all of the textboxes
            void Initialize_Textboxes()
            {
                for (int i = 0; i < listOfShapes.Count; i++)
                {
                    listOfShapes[i].SetShapeCoordinates(textBoxTop, textBoxLeft);
                    listOfShapes[i].Initialize_AddToMasterList();
                    listOfSequenceTextboxes.Add(listOfShapes[i]);
                }
            }
        }
    }
}
