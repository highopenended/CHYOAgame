using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.MovementPlanners
{
    public class WaitTicks
    {
        public void AddPlan(Shape shapeToGivePlan, int waitTicks)
        {
            for (int i = 0; i < waitTicks; i++)
            {
                shapeToGivePlan.Tick_lMovementPlan.Add(Shape.MovementsAndActions.Static);
            }
        }
    }
}
