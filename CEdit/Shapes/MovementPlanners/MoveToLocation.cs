using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.MovementPlanners
{
    public class MoveToLocation
    {
        public void AddPlan(Shape shapeToGivePlan, int destRow, int destCol)
        {
            SingleDirection singleDirectionPlanner = new SingleDirection();

            //shapeToGivePlan.Destination_Left = destCol;
            //shapeToGivePlan.Destination_Top = destRow;


            List<Shape.MovementsAndActions> movePlan = new List<Shape.MovementsAndActions>();

            // True = Up    || False = Down
            Shape.MovementsAndActions UpDown_Dir;

            // True = Left  || False = Right
            Shape.MovementsAndActions LeftRight_Dir;

            // Diagonal Move Direction (combine cardinals to get diagonals when possible)
            Shape.MovementsAndActions Diagonal_Dir;

            // Cardinal Move Direction (The straight line movement left over after calculating diagonal steps)
            Shape.MovementsAndActions CardinalRemainder_Dir;


            // Get the distances for both axiis (positive and negative indicate opposite directions)
            int UpDown_Distance     = destRow - shapeToGivePlan.Top;
            int LeftRight_Distance  = destCol - shapeToGivePlan.Left;


            // Get Up-Down and Left-Right bools based on the distance info
            if (UpDown_Distance < 0)
                    { UpDown_Dir = Shape.MovementsAndActions.Up; }
            else    { UpDown_Dir = Shape.MovementsAndActions.Down; }

            if (LeftRight_Distance < 0)
                    { LeftRight_Dir = Shape.MovementsAndActions.Left; }
            else    { LeftRight_Dir = Shape.MovementsAndActions.Right; }


            // Absolute Value the up-down and left-right distance values
            UpDown_Distance = Math.Abs(UpDown_Distance);
            LeftRight_Distance = Math.Abs(LeftRight_Distance);

            // Get the step counts for both axiis (based on step size)
            int UpDown_Steps = UpDown_Distance / shapeToGivePlan.StepDistance_UD;
            int LeftRight_Steps = LeftRight_Distance / shapeToGivePlan.StepDistance_LR;


            // Get the diagonal and cardinal direction move counts
            int diagonalSteps = Math.Min(UpDown_Steps, LeftRight_Steps);
            int cardinalSteps = Math.Max(UpDown_Steps, LeftRight_Steps) - diagonalSteps;

            // Get diagonal direction
            if(UpDown_Dir == Shape.MovementsAndActions.Up)
            {
                if(LeftRight_Dir == Shape.MovementsAndActions.Left)
                        { Diagonal_Dir = Shape.MovementsAndActions.Up_Left; }
                else    { Diagonal_Dir = Shape.MovementsAndActions.Up_Right; }
            }
            else
            {
                if (LeftRight_Dir == Shape.MovementsAndActions.Left)
                        { Diagonal_Dir = Shape.MovementsAndActions.Down_Left; }
                else    { Diagonal_Dir = Shape.MovementsAndActions.Down_Right; }
            }
            
            // Get cardinal remainder direction
            if(UpDown_Steps >= LeftRight_Steps)
                    { CardinalRemainder_Dir = UpDown_Dir; }
            else    { CardinalRemainder_Dir = LeftRight_Dir; }


            // --- Add the steps to step plan

            // Add Diagonal Steps (if any)
            if (diagonalSteps > 0) { singleDirectionPlanner.AddPlan(shapeToGivePlan, Diagonal_Dir, diagonalSteps); }
            

            // Add Cardinal Steps (if any)

            if (cardinalSteps > 0) { singleDirectionPlanner.AddPlan(shapeToGivePlan, CardinalRemainder_Dir, cardinalSteps); }


            shapeToGivePlan.Destination_Left = destCol;
            shapeToGivePlan.Destination_Top = destRow;
        }
    }
}
