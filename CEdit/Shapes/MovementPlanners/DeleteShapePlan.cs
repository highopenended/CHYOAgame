using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.MovementPlanners
{
    public class DeleteShapePlan
    {
        public void AddPlan(Shape shapeToGivePlan, bool deleteExistingPlans)
        {
            if(deleteExistingPlans)
            {
                DisplayLists.AddToWaitList_RemoveFromMasterList(shapeToGivePlan);
            }
            shapeToGivePlan.Tick_lMovementPlan.Add(Shape.MovementsAndActions.Delete);
        }
    }
}
