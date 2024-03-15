using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.MovementPlanners
{
    public class SingleDirection
    {
        /// <summary>
        /// Add a single direction movement plan to the end of the current movement plan
        /// </summary>
        /// <param name="shapeToGivePlan"></param>
        /// <param name="direction"></param>
        /// <param name="steps"></param>
        public void AddPlan(Shape shapeToGivePlan, Shape.MovementsAndActions direction, int steps)
        {

            switch (direction)
            {
                case Shape.MovementsAndActions.Up:
                    shapeToGivePlan.Destination_Top -= (steps * shapeToGivePlan.StepDistance_UD);
                    break;

                case Shape.MovementsAndActions.Down:
                    shapeToGivePlan.Destination_Top += (steps * shapeToGivePlan.StepDistance_UD);
                    break;

                case Shape.MovementsAndActions.Left:
                    shapeToGivePlan.Destination_Left -= (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Right:
                    shapeToGivePlan.Destination_Left += (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Up_Left:
                    shapeToGivePlan.Destination_Top -= (steps * shapeToGivePlan.StepDistance_UD);
                    shapeToGivePlan.Destination_Left -= (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Up_Right:
                    shapeToGivePlan.Destination_Top -= (steps * shapeToGivePlan.StepDistance_UD);
                    shapeToGivePlan.Destination_Left += (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Down_Left:
                    shapeToGivePlan.Destination_Top += (steps * shapeToGivePlan.StepDistance_UD);
                    shapeToGivePlan.Destination_Left -= (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Down_Right:
                    shapeToGivePlan.Destination_Top += (steps * shapeToGivePlan.StepDistance_UD);
                    shapeToGivePlan.Destination_Left += (steps * shapeToGivePlan.StepDistance_LR);
                    break;

                case Shape.MovementsAndActions.Static:
                    // Change nothing (waiting)
                    break;
            }



            for (int i = 0; i < steps; i++)
            {
                shapeToGivePlan.Tick_lMovementPlan.Add(direction);
            }
        }
    }
}
