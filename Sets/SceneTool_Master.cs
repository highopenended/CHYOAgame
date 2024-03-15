using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets
{
    public class SceneTool_Master
    {
        CEdit.Shapes.ShapeMaker_Text ShapeMaker_Textbox = new CEdit.Shapes.ShapeMaker_Text();

        List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfSequenceTextboxes = new List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox>();
        List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfSequenceTextboxes_AlreadyDisplayed = new List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox>();


        /// <summary>
        /// Get a list of textbox shapes that can then be used with the "CycleThrough_ListOfTextBoxes" function.  Simpler than custom-making each shape.
        /// </summary>
        /// <param name="listOfStrings"></param>
        /// <param name="maxBoxWidth"></param>
        /// <param name="typingSpeed"></param>
        /// <param name="borderColor"></param>
        /// <param name="textColor"></param>
        /// <param name="stringAlreadyComplete"> Determines whether textbox should slowly type out or already be complete </param>
        /// <returns></returns>
        public List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> Get_ListOfTextboxShapes_Typer(List<string> listOfStrings, int maxBoxWidth, int typingSpeed, PUBVAR.Colors borderColor, PUBVAR.Colors textColor, bool stringAlreadyComplete)
        {
            var listOfTextboxShapes = new List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox>();

            for (int i = 0; i < listOfStrings.Count; i++)
            {
                string prompt = listOfStrings[i];
                var TextBox_Prompt = ShapeMaker_Textbox.CreateShape_TyperTextbox(prompt, maxBoxWidth, typingSpeed, borderColor, textColor, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true);
                listOfTextboxShapes.Add(TextBox_Prompt);
            }
            if (stringAlreadyComplete)
            {
                for (int i = 0; i < listOfTextboxShapes.Count; i++)
                {
                    listOfTextboxShapes[i].Tick_ImmediatelyCompleteMovement_Internal();
                }
            }

            return listOfTextboxShapes;
        }

        /// <summary>
        /// Cycle through a list of textboxes.  Used for scene description.
        /// </summary>
        /// <param name="listOfTextboxShapes"></param>
        /// <param name="textBoxLeft"></param>
        /// <param name="textBoxTop"></param>
        public void CycleThrough_ListOfTextBoxes(List<CEdit.Shapes.Variations.TextBoxShapes.Typer_TextBox> listOfTextboxShapes, int textBoxLeft = 50, int textBoxTop = 10)
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
                    else { cycleSubCounter = true; }
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
                    else { waitTime = maxWaitTime; }
                }
                else // Last box already has move, so it needs shorter waiting time
                {
                    box.AddMovementPlan_Wait(10);
                    box.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, 30);
                    box.AddMovementPlan_DeleteThisShape();
                }

            }

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
                        MoveExistingBoxesUp();
                        GetNextBox();
                        break;
                }

                // Move existing textbox shapes to give room for the new message
                void MoveExistingBoxesUp()
                {

                    if ((cycleCounter) < listOfSequenceTextboxes.Count)
                    {
                        int nextBoxHeight;
                        if (cycleCounter + 1 < listOfSequenceTextboxes.Count)
                        { nextBoxHeight = listOfSequenceTextboxes[cycleCounter + 1].Height; }
                        else { nextBoxHeight = 5; }



                        for (int i = 0; i < listOfSequenceTextboxes_AlreadyDisplayed.Count; i++)
                        {
                            // Move further on first step
                            if (i == listOfSequenceTextboxes_AlreadyDisplayed.Count - 1)
                            {
                                listOfSequenceTextboxes_AlreadyDisplayed[i].Tick_ChangeStepDistancesUDLR(2, 1);
                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down, nextBoxHeight - 1);
                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Down_Right, 15);

                                listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Right, 8);

                                if ((cycleCounter) >= listOfSequenceTextboxes.Count - 1)
                                {
                                    //listOfSequenceTextboxes_AlreadyDisplayed[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MoveDirection.Down, 30);
                                }
                            }
                            else
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
                    else
                    {
                        continueLoop = false;
                    }
                }
            }

            // Initialize all of the textboxes
            void Initialize_Textboxes()
            {
                for (int i = 0; i < listOfTextboxShapes.Count; i++)
                {
                    listOfTextboxShapes[i].SetShapeCoordinates(textBoxTop, textBoxLeft);
                    listOfTextboxShapes[i].Initialize_AddToMasterList();
                    listOfSequenceTextboxes.Add(listOfTextboxShapes[i]);
                }
            }
        }



        /// <summary>
        /// Make the list of descriptions to swap in and out to the single 'motionless' description box (Or sets as null)
        /// </summary>
        /// <param name="listOfDescriptions"></param>
        /// <param name="descrBox_Top"></param>
        /// <param name="descrBox_Left"></param>
        /// <param name="descrBox_Width"></param>
        /// <param name="descrBox_Height"></param>
        public List<CEdit.Shapes.Shape> UI_SelectFromOptions_GetSameSizeDescriptionBoxes(List<string> listOfDescriptions, PUBVAR.Colors textColor, PUBVAR.Colors borderColor,
                                            int descrBox_Width, int descrBox_Height,
                                            List<List<string>> listOfDescriptions_highlightWords = null, PUBVAR.Colors highlightColor = PUBVAR.Colors.White)
        {
            List<CEdit.Shapes.Shape> lMatchingSize_DescriptionBoxes = new List<CEdit.Shapes.Shape>();
            if (listOfDescriptions != null)
            {
                for (int i = 0; i < listOfDescriptions.Count; i++)
                {
                    if (listOfDescriptions_highlightWords == null)
                    {
                        lMatchingSize_DescriptionBoxes.Add(ShapeMaker_Textbox.CreateShape_StaticTextbox(listOfDescriptions[i], descrBox_Width, descrBox_Height, textColor, borderColor,
                                                                                                      null, highlightColor,
                                                                                                      CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                    }
                    else
                    {
                        lMatchingSize_DescriptionBoxes.Add(ShapeMaker_Textbox.CreateShape_StaticTextbox(listOfDescriptions[i], descrBox_Width, descrBox_Height, textColor, borderColor,
                                                                                                        listOfDescriptions_highlightWords[i], highlightColor,
                                                                                                        CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                    }
                }
            }
            else
            {
                lMatchingSize_DescriptionBoxes = null;
            }

            return lMatchingSize_DescriptionBoxes;
        }





        public void UI_SelectFromOptions(SelectionTypes selectionType, List<CEdit.Shapes.Shape> listOfShapes_Choices,
                                        int choices_StartTop, int choices_StartLeft,
                                        bool escapeIsAllowed, out CEdit.Shapes.Shape ChosenShape, out int chosenIndex, 
                                        int extraSpaceBetweenChoices_LR = 1, int extraSpaceBetweenChoices_UD = 1,
                                        List<CEdit.Shapes.Shape> listOfDescriptionShapes = null,
                                        int descrBox_Top = 0, int descrBox_Left = 0)
        {
           

            Set_Coordinates_Choices(selectionType, listOfShapes_Choices, choices_StartTop, choices_StartLeft, extraSpaceBetweenChoices_LR, extraSpaceBetweenChoices_UD);
            Set_Coordinates_DescriptionBoxes(listOfDescriptionShapes, descrBox_Top, descrBox_Left);
            AddAllShapesToMasterList(listOfShapes_Choices, listOfDescriptionShapes);
            SelectFirstShape_ByDefault(listOfShapes_Choices, listOfDescriptionShapes);



            int currentIndex = 0;
            for (; ; )
            {
                GetNext_SelectedIndex(currentIndex, listOfShapes_Choices.Count, selectionType, out int nextIndex, out bool pressedEnter, out bool pressedEscape);
               
                // ENTER
                if (pressedEnter)           
                {
                    ChosenShape = listOfShapes_Choices[currentIndex];
                    chosenIndex = currentIndex;
                    return;
                }
                // ESCAPE
                else if (pressedEscape && escapeIsAllowed)     
                { 
                    ChosenShape = null;
                    chosenIndex = currentIndex;
                    return;                    
                }
                // CHANGED SELECTION
                else
                {
                    SetNext_SelectedShape(listOfShapes_Choices, currentIndex, nextIndex);
                    SetNext_DescriptionBox(listOfDescriptionShapes, currentIndex, nextIndex);

                    currentIndex = nextIndex;
                }
            }
        }



        /// <summary>
        /// Make the list of descriptions to swap in and out to the single 'motionless' description box (Or sets as null)
        /// </summary>
        /// <param name="listOfDescriptions"></param>
        /// <param name="descrBox_Top"></param>
        /// <param name="descrBox_Left"></param>
        /// <param name="descrBox_Width"></param>
        /// <param name="descrBox_Height"></param>
        void MakeDescriptionTextBoxShapes(List<string> listOfDescriptions, PUBVAR.Colors textColor, PUBVAR.Colors borderColor, out List<CEdit.Shapes.Shape> lMatchingSize_DescriptionBoxes, List<List<string>> listOfDescriptions_highlightWords, 
                                            int descrBox_Width, int descrBox_Height)
        {            
            if (listOfDescriptions != null)
            {
                lMatchingSize_DescriptionBoxes = new List<CEdit.Shapes.Shape>();
                for (int i = 0; i < listOfDescriptions.Count; i++)
                {
                    lMatchingSize_DescriptionBoxes.Add(ShapeMaker_Textbox.CreateShape_StaticTextbox(listOfDescriptions[i], descrBox_Width, descrBox_Height, textColor, borderColor,
                                                                                                    listOfDescriptions_highlightWords[i], PUBVAR.Colors.Green, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                }
            }
            else
            {
                lMatchingSize_DescriptionBoxes = null;
            }
        }

        /// <summary>
        /// Set the coordinates of each choice shape so that they line up top to bottom
        /// </summary>
        /// <param name="listOfShapes"></param>
        /// <param name="choices_StartTop"></param>
        /// <param name="choices_StartLeft"></param>
        void Set_Coordinates_Choices(SelectionTypes selectionType, List<CEdit.Shapes.Shape> listOfShapes, int choices_StartTop, int choices_StartLeft, int extraSpaceBetweenChoices_LR, int extraSpaceBetweenChoices_UD)
        {
            int currentTop = choices_StartTop;
            int currentLeft = choices_StartLeft;
            int prevBoxHeight;
            int prevBoxWidth;

            switch (selectionType)
            {
                //------------------------------------------
                //  Top-to-Bottom style choice list
                //------------------------------------------
                case SelectionTypes.UpDown:

                    for (int i = 0; i < listOfShapes.Count; i++)
                    {
                        var currentShape = listOfShapes[i];

                        currentShape.SetShapeCoordinates(currentTop, currentLeft);
                        prevBoxHeight = currentShape.Height;

                        currentTop += (prevBoxHeight + 1);
                    }
                    break;

                //------------------------------------------
                //  Left-to-Right style choice list
                //------------------------------------------
                case SelectionTypes.LeftRight:

                    for (int i = 0; i < listOfShapes.Count; i++)
                    {
                        var currentShape = listOfShapes[i];

                        currentShape.SetShapeCoordinates(currentTop, currentLeft);
                        prevBoxWidth = currentShape.Width;

                        currentLeft += (prevBoxWidth + extraSpaceBetweenChoices_LR);
                    }
                    break;

                //------------------------------------------
                //  4Square style choice list
                //------------------------------------------
                case SelectionTypes.FourSquare:
                    if (listOfShapes.Count != 4) { throw new Exception("Foursquare can only be used with EXACTLY four shapes"); }

                    // Standardize the spacing of the boxes
                    int leftTwo_Width = Math.Max(listOfShapes[0].Width, listOfShapes[1].Width);
                    int topTwo_Height = Math.Max(listOfShapes[0].Height, listOfShapes[1].Height);

                    int top_1   = choices_StartTop;
                    int left_1  = choices_StartLeft;
                    int top_2   = choices_StartTop + topTwo_Height + extraSpaceBetweenChoices_UD;                    
                    int left_2  = choices_StartLeft + leftTwo_Width + extraSpaceBetweenChoices_LR;

                    listOfShapes[0].SetShapeCoordinates(top_1, left_1);
                    listOfShapes[1].SetShapeCoordinates(top_1, left_2);
                    listOfShapes[2].SetShapeCoordinates(top_2, left_1);
                    listOfShapes[3].SetShapeCoordinates(top_2, left_2);
                    break;
            }
        }

        /// <summary>
        /// Set the coordinates of the description boxes for each choice (coordinates will be exactly the same since it will 'swap out' the next box with the existing one
        /// </summary>
        /// <param name="lSameSizeDescriptionBoxes"></param>
        /// <param name="descrBox_Top"></param>
        /// <param name="descrBox_Left"></param>
        void Set_Coordinates_DescriptionBoxes(List<CEdit.Shapes.Shape> lSameSizeDescriptionBoxes, int descrBox_Top, int descrBox_Left)
        {
            if(lSameSizeDescriptionBoxes != null)
            {
                for (int i = 0; i < lSameSizeDescriptionBoxes.Count; i++)
                {
                    lSameSizeDescriptionBoxes[i].SetShapeCoordinates(descrBox_Top, descrBox_Left);
                }
            }
        }

        /// <summary>
        /// Add all the choice shapes to the mastershape list
        /// </summary>
        /// <param name="listOfShapes_Choices"></param>
        void AddAllShapesToMasterList(List<CEdit.Shapes.Shape> listOfShapes_Choices, List<CEdit.Shapes.Shape> listOfShapes_DescriptionBoxes)
        {
            for (int i = 0; i < listOfShapes_Choices.Count; i++)
            {
                listOfShapes_Choices[i].Initialize_AddToMasterList(true);                 
            }

            if (listOfShapes_DescriptionBoxes != null)
            {
                for (int i = 0; i < listOfShapes_Choices.Count; i++)
                {
                    listOfShapes_DescriptionBoxes[i].Initialize_AddToMasterList(false);
                }
            }

        }

        /// <summary>
        /// Select first shape choice on list by default
        /// </summary>
        /// <param name="listOfShapes_Choices"></param>
        void SelectFirstShape_ByDefault(List<CEdit.Shapes.Shape> listOfShapes_Choices, List<CEdit.Shapes.Shape> listOfShapes_DescriptionBoxes)
        {
            listOfShapes_Choices[0].Select_ThisShape();
            if (listOfShapes_DescriptionBoxes != null) { listOfShapes_DescriptionBoxes[0].Tick_MakeVisible(); }
        }

        /// <summary>
        /// Read user keypress and return the next index.  If enter or escape is pressed, then their outputs will be true
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="numberOfChoices"></param>
        /// <param name="nextIndex"></param>
        /// <param name="pressedEnter"></param>
        /// <param name="pressedEscape"></param>
        void GetNext_SelectedIndex(int currentIndex, int numberOfChoices, SelectionTypes selectionType, out int nextIndex, out bool pressedEnter, out bool pressedEscape)
        {
            nextIndex = currentIndex;
            pressedEnter = false;
            pressedEscape = false;


            // Read the key and return newly selected shape and also return status of escape and enter keys
            ConsoleKey keyPress = Console.ReadKey().Key;

            switch(selectionType)
            {
                //--------------------
                //  Up + Down
                //--------------------
                case SelectionTypes.UpDown:

                    switch (keyPress)
                    {
                        // UP
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            nextIndex = SelectNext_Up(currentIndex);
                            break;

                        // DOWN
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            nextIndex = SelectNext_Down(currentIndex);
                            break;

                        // ENTER
                        case ConsoleKey.Enter:
                            pressedEnter = true;
                            return;

                        // ESCAPE
                        case ConsoleKey.Escape:
                            pressedEscape = true;
                            break;
                    }
                    break;

                //--------------------
                //  Left + Right
                //--------------------
                case SelectionTypes.LeftRight:

                    switch (keyPress)
                    {
                        // LEFT 
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            nextIndex = SelectNext_Left(currentIndex);
                            break;

                        // RIGHT
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            nextIndex = SelectNext_Right(currentIndex);
                            break;

                        // ENTER
                        case ConsoleKey.Enter:
                            pressedEnter = true;
                            return;

                        // ESCAPE
                        case ConsoleKey.Escape:
                            pressedEscape = true;
                            break;
                    }
                    break;


                //--------------------
                // 4Square Box
                //--------------------
                case SelectionTypes.FourSquare:
                    switch (keyPress)
                    {
                        // UP or DOWN
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            nextIndex = SelectNext_UpDown_4square(currentIndex);
                            break;

                        // LEFT or RIGHT
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            nextIndex = SelectNext_LeftRight_4square(currentIndex);
                            break;

                        // ENTER
                        case ConsoleKey.Enter:
                            pressedEnter = true;
                            return;

                        // ESCAPE
                        case ConsoleKey.Escape:
                            pressedEscape = true;
                            break;
                    }
                    break;
            }


           

            //===========================================
            //  GET THE NEXT INDEX BASED ON KEY PRESS
            //===========================================
            // This is for one direction lists

            int SelectNext_Up(int checkIndex)
            {
                if (checkIndex - 1 >= 0)
                        { checkIndex--; }
                else    { checkIndex = numberOfChoices - 1; }
                return checkIndex;
            }

            int SelectNext_Down(int checkIndex)
            {
                if (checkIndex + 1 < numberOfChoices)
                        { checkIndex++; }
                else    { checkIndex = 0; }
                return checkIndex;
            }

            int SelectNext_Left(int checkIndex)
            {
                if (checkIndex - 1 >= 0)
                        { checkIndex--; }
                else    { checkIndex = numberOfChoices - 1; }
                return checkIndex;
            }

            int SelectNext_Right(int checkIndex)
            {
                if (checkIndex + 1 < numberOfChoices)
                        { checkIndex++; }
                else    { checkIndex = 0; }
                return checkIndex;
            }

            //===========================================
            //  GET THE NEXT INDEX BASED ON KEY PRESS
            //===========================================
            // This is for 4Square lists
            int SelectNext_UpDown_4square(int checkIndex)
            {
                switch(checkIndex)
                {
                    case 0: return 2;
                    case 1: return 3;
                    case 2: return 0;
                    case 3: return 1;
                    default: return 0;
                }
            }

            int SelectNext_LeftRight_4square(int checkIndex)
            {
                switch (checkIndex)
                {
                    case 0: return 1;
                    case 1: return 0;
                    case 2: return 3;
                    case 3: return 2;
                    default: return 0;
                }
            }

        }

        /// <summary>
        /// Deselects currently selected shapes, and selects next shape (highlight boxes)
        /// </summary>
        /// <param name="listOfShapes_Choices"></param>
        /// <param name="currentIndex"></param>
        /// <param name="nextIndex"></param>
        void SetNext_SelectedShape(List<CEdit.Shapes.Shape> listOfShapes_Choices, int currentIndex, int nextIndex)
        {
            listOfShapes_Choices[currentIndex].Deselect_ThisShape();
            listOfShapes_Choices[nextIndex].Select_ThisShape();
        }

        /// <summary>
        /// Makes current description box invisible and makes next box visible (Creates the illusion of the text and whatnot changing, but the descriptor box should stay the same size)
        /// </summary>
        /// <param name="lMatchingSize_DescriptionBoxes"></param>
        /// <param name="currentIndex"></param>
        /// <param name="nextIndex"></param>
        void SetNext_DescriptionBox(List<CEdit.Shapes.Shape> lMatchingSize_DescriptionBoxes, int currentIndex, int nextIndex)
        {
            if(lMatchingSize_DescriptionBoxes != null)
            {
                lMatchingSize_DescriptionBoxes[currentIndex].Tick_MakeInvisible();
                lMatchingSize_DescriptionBoxes[nextIndex].Tick_MakeVisible();
            }
        }



        public enum SelectionTypes
        {
            LeftRight,
            UpDown,
            FourSquare
        }
    }
}
