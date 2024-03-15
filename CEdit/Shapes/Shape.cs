using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes
{
    public class Shape
    {
        ShapeMaker_SelectionBox SelectionBoxMaker = new ShapeMaker_SelectionBox();

        public Shape()
        {
            Initialize_GeneralInfo();
        }

        public string Description { get; set; }


        public Shape(char[,] arrayOfCharacters, char[,] arrayOfColors_FG = null, char[,] arrayOfColors_BG = null)
        {
            ArrChars = arrayOfCharacters;

            if(arrayOfColors_FG == null)

                    { SetToEmptyArray(out ArrColors_FG); }
            else    { ArrColors_FG = arrayOfColors_FG; }

            if(arrayOfColors_BG == null)
                    { SetToEmptyArray(out ArrColors_BG); }
            else    { ArrColors_BG = arrayOfColors_BG; }

            Initialize_GeneralInfo();
        }

        // Some general initialization stuff (to be used in each constructor)
        void Initialize_GeneralInfo()
        {
            ShapeStatus = ShapeStatuses.Static;

            StepCounter = -1;

            StepDistance_LR = 2;
            StepDistance_UD = 1;
            IsVisible = true;

            Destination_Left = 0;
            Destination_Top = 0;
        }


        public void UpdateOnTick()
        {
            Update_MovementSpeed();
            Update_NewMovementPlans();
            Update_ShapeCoordinates();
            Update_InternalMovement();

            //____________________________________________
            //  INTERNAL METHODS

            // Check for changes to movement speed
            void Update_MovementSpeed()
            {
                if(Changed_StepDistances)
                {
                    StepDistance_LR = Change_StepDistance_LR;
                    StepDistance_UD = Change_StepDistance_UD;
                    Changed_StepDistances = false;

                    lMovementPlan.Clear();
                    Tick_lMovementPlan.Clear();
                    AddMovementPlan_MoveToLocation(Destination_Top, Destination_Left);
                    StepCounter = 0;
                }
            }


            // Add queued movement plans to the movement plan list
            void Update_NewMovementPlans()
            {
                if (Tick_lMovementPlan.Count > 0)
                {
                    for (int i = 0; i < Tick_lMovementPlan.Count; i++)
                    {
                        lMovementPlan.Add(Tick_lMovementPlan[i]);
                    }
                    Tick_lMovementPlan.Clear();
                }
            }

            // Tell each shape to "move" to it's new coordinates by updating it's own Left and Top
            void Update_ShapeCoordinates()
            {                
                if (!ArrivedAtDestination)
                {
                    MoveOneTick_FullShapeMove();                    
                }
            }

            // Internal Movement of shape is updated (ex. self-typing text, spinning, etc.)
            void Update_InternalMovement()
            {
                if (!InternalMovement_IsComplete)
                {
                    if (changed_InternalMovementCompleted)
                    {
                        Complete_InternalMovement();
                        changed_InternalMovementCompleted = false;
                    }
                    else
                    {
                        MoveOneTick_InternalMovement();
                    }
                }
            }
        }



        /// <summary>
        /// Handles standard movement of the entire shape (array) in a direction (or not at all)
        /// </summary>
        void MoveOneTick_FullShapeMove()
        {
            StepCounter++;

            if (StepCounter >= lMovementPlan.Count)
            {
                ArriveAtDestination();
            }
            else
            {
                MovementsAndActions nextMove = lMovementPlan[StepCounter];

                switch (nextMove)
                {
                    case MovementsAndActions.Up:
                        Top -= StepDistance_UD;
                        break;

                    case MovementsAndActions.Down:
                        Top += StepDistance_UD;
                        break;

                    case MovementsAndActions.Left:
                        Left -= StepDistance_LR;
                        break;

                    case MovementsAndActions.Right:
                        Left += StepDistance_LR;
                        break;

                    case MovementsAndActions.Up_Left:
                        Top -= StepDistance_UD;
                        Left -= StepDistance_LR;
                        break;

                    case MovementsAndActions.Up_Right:
                        Top -= StepDistance_UD;
                        Left += StepDistance_LR;
                        break;

                    case MovementsAndActions.Down_Left:
                        Top += StepDistance_UD;
                        Left -= StepDistance_LR;
                        break;

                    case MovementsAndActions.Down_Right:
                        Top += StepDistance_UD;
                        Left += StepDistance_LR;
                        break;

                    case MovementsAndActions.Delete:
                        DisplayLists.AddToWaitList_RemoveFromMasterList(this);
                        break;
                }
            }
            
        }



        /// <summary>
        /// Handles internal shape movement (self-typing text, spinning, etc.) without affecting the position of the overall shape array
        /// </summary>
        protected virtual void MoveOneTick_InternalMovement() { }



        public int Top { get; private set; }
        public int Left { get; private set; }

        public void SetShapeCoordinates(int top, int left)
        {
            Left = left; Destination_Left = left;
            Top = top; Destination_Top = top;
        }



        //==================================================
        //  Shape Visibility
        //==================================================

        public bool IsVisible               { get; private set; }
        public void Tick_MakeVisible()      { IsVisible = true; }
        public void Tick_MakeInvisible()    { IsVisible = false; }


        // A selection box that is around the shape to show that it's selected.
        Shape SelectionBox { get; set; }

        public bool IsSelected              { get; private set; }

        public void Select_ThisShape()
        {
            if (SelectionBox == null)
            {
                SelectionBox = SelectionBoxMaker.CreateShape_SelectionBox(this);
                SelectionBox.Initialize_AddToMasterList();
            }

            SelectionBox.Tick_MakeVisible();
        }

        public void Deselect_ThisShape()
        {
            if (SelectionBox == null)
            {
                SelectionBox = SelectionBoxMaker.CreateShape_SelectionBox(this);
                SelectionBox.Initialize_AddToMasterList();
            }

            SelectionBox.Tick_MakeInvisible();
        }
        //==================================================
        //  Shape Movement
        //==================================================

        public ShapeStatuses ShapeStatus { get; set; }

        public int Height { get { return ArrChars.GetUpperBound(0); } }
        public int Width { get { return ArrChars.GetUpperBound(1); } }

        public char[,] ArrChars;
        public char[,] ArrColors_FG;
        public char[,] ArrColors_BG;

        public List<MovementsAndActions> Tick_lMovementPlan = new List<MovementsAndActions>();
        List<MovementsAndActions> lMovementPlan = new List<MovementsAndActions>();


        // True if all external and internal movement is complete
        public bool AllMovementComplete
        {
            get
            {
                if(ArrivedAtDestination && InternalMovement_IsComplete)
                        { return true; }
                else    { return false; }
            }
        }

        public int Destination_Left { get; set; }
        public int Destination_Top { get; set; }

        bool ArrivedAtDestination { get; set; }

        public bool InternalMovement_IsComplete { get; set; }
        public bool InternalMovement_WillBeComplete_NextTick { get; set; }

        protected int StepCounter { get; set; }


        public void Tick_ChangeStepDistancesUDLR(int NewStepDistance_LR, int NewStepDistance_UD, bool changeImmediately = false)
        {
            Change_StepDistance_LR = NewStepDistance_LR;
            Change_StepDistance_UD = NewStepDistance_UD;
            Changed_StepDistances = true;

            if (changeImmediately)
            {
                StepDistance_LR = NewStepDistance_LR;
                StepDistance_UD = NewStepDistance_UD;
            }
        }

        bool Changed_StepDistances;
        int Change_StepDistance_LR;
        int Change_StepDistance_UD;

        public int StepDistance_LR { get; private set; }
        public int StepDistance_UD { get; private set; }




        //____________________________________________
        //  Taking movement steps 




        /// <summary>
        /// Next Tick : Immediately complete all movement, external and internal
        /// </summary>
        public void Tick_ImmediatelyCompleteMovement_All()
        {
            Tick_ImmediatelyCompleteMovement_External();
            Tick_ImmediatelyCompleteMovement_Internal();
        }

        /// <summary>
        /// Next Tick : Immediately complete the external movement of the shape (reach destination instantly)
        /// </summary>
        public void Tick_ImmediatelyCompleteMovement_External()
        {
            SetShapeCoordinates(Destination_Top, Destination_Left);
            Clear_MovementPlan();
        }
        
        /// <summary>
        /// Next Tick : Immediately complete the internal movement of the shape like internal text typing
        /// </summary>
        public void Tick_ImmediatelyCompleteMovement_Internal()
        {
            changed_InternalMovementCompleted = true;
            InternalMovement_WillBeComplete_NextTick = true;
        }
        bool changed_InternalMovementCompleted;


        
        /// <summary>
        /// End all movement, clear movement plan, set shape to static, etc.
        /// </summary>
        void ArriveAtDestination()
        {

            if (ShapeStatus == ShapeStatuses.Moving) { ShapeStatus = ShapeStatuses.Static; }

            Left = Destination_Left;
            Top = Destination_Top;

            ArrivedAtDestination = true;

            lMovementPlan.Clear();
            StepCounter = -1;
        }



        /// <summary>
        /// Finish any internal movement immediately instead of waiting 
        /// </summary>
        protected virtual void Complete_InternalMovement() { }




        //==================================================
        //  MOVEMENT PLANNING
        //==================================================

        // ----- Movement Planners
        readonly MovementPlanners.SingleDirection   Planner_SingleDirection = new MovementPlanners.SingleDirection();
        readonly MovementPlanners.MoveToLocation    Planner_MoveToLocation = new MovementPlanners.MoveToLocation();
        readonly MovementPlanners.WaitTicks         Planner_Wait = new MovementPlanners.WaitTicks();
        readonly MovementPlanners.DeleteShapePlan   Planner_DeleteThisShape = new MovementPlanners.DeleteShapePlan();
               


        /// <summary>
        /// Add plan to move in a single direction for X steps
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="steps"></param>
        public void AddMovementPlan_SingleDirection(MovementsAndActions direction, int steps)
        {
            AddMovementPlan_CallAtStart();
            Planner_SingleDirection.AddPlan(this, direction, steps);            
        }


        /// <summary>
        /// Add a movement plan that is autogenerated to move this shape to a destination
        /// </summary>
        /// <param name="destRow"> The destination row </param>
        /// <param name="destCol"> The destination column </param>
        public void AddMovementPlan_MoveToLocation(int destRow, int destCol)
        {
            AddMovementPlan_CallAtStart();
            Planner_MoveToLocation.AddPlan(this, destRow, destCol);            
        }

        public void AddMovementPlan_Wait(int waitTicks)
        {
            AddMovementPlan_CallAtStart();
            Planner_Wait.AddPlan(this, waitTicks);
        }


        /// <summary>
        /// Add this is remove this shape from the master shape list
        /// </summary>
        public void AddMovementPlan_DeleteThisShape(bool DeleteExistingPlans = false)
        {
            Planner_DeleteThisShape.AddPlan(this, DeleteExistingPlans);
            ArrivedAtDestination = false;
        }

        private void AddMovementPlan_CallAtStart()
        {
            ShapeStatus = ShapeStatuses.Moving;
            ArrivedAtDestination = false;
        }




        /// <summary>
        /// Clear this shape's movement plan immediately (without completing it)
        /// </summary>
        public void Clear_MovementPlan()
        {
            ArriveAtDestination();    
        }



        /// <summary>
        /// Outputs an array that is sized based on the ArrChar bounds and that is empty
        /// </summary>
        /// <param name="arrayToSet"></param>
        protected void SetToEmptyArray(out char[,] arrayToSet)
        {
            arrayToSet = new char[ArrChars.GetUpperBound(0) + 1, ArrChars.GetUpperBound(1) + 1];

            for (int i = 0; i < ArrChars.GetUpperBound(0); i++)
            {
                for (int j = 0; j < ArrChars.GetUpperBound(1); j++)
                {
                    arrayToSet[i, j] = '\0';
                }
            }
        }


        /// <summary>
        /// Adds this item to the master draw list (next tick)
        /// </summary>
        /// <param name="immediatelyVisible"></param>
        public void Initialize_AddToMasterList(bool immediatelyVisible = false)
        {
            if (immediatelyVisible)
                    { IsVisible = true; }
            else    { IsVisible = false; }

            DisplayLists.AddToWaitList_AddToMasterList(this);
        }


        /// <summary>
        /// Makes the color array all a single color (like a grayed out textbox for instance)
        /// </summary>
        /// <param name="color"></param>
        public void MakeColorArray_MonoColor(PUBVAR.Colors color = PUBVAR.Colors.DarkGray)
        {
            char colorChar = PUBVAR.GetColorChar(color);

            for (int i = 0; i < ArrColors_FG.GetUpperBound(0); i++)
            {
                for (int j = 0; j < ArrColors_FG.GetUpperBound(1); j++)
                {
                    ArrColors_FG[i, j] = colorChar;
                }
            }
        }




        public enum MovementsAndActions
        {
            Up,
            Down,
            Left,
            Right,
            Up_Left,
            Up_Right,
            Down_Left,
            Down_Right,
            Static,
            Delete
        }

        public enum ShapeStatuses
        {
            Moving,
            Static,
            AbsoluteTop,
            AbsoluteBottom
                //******* HERE :: Make condition for abs bottom
        }
    }
}
