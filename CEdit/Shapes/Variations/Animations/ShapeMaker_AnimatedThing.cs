using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Animations
{
    public class ShapeMaker_AnimatedThing
    {
        public Fire_Small Make_Fire()
        {

            char[,] myArr = PUBVAR.GetCharArr(Fire_Small.lFire_0);
            Fire_Small fire_Small = new Fire_Small(myArr);

            return fire_Small;
        }
    }
}
