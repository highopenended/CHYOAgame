using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Startup
{
    public static class OpeningScreen
    {
        public static void Display_Fire()
        {
            CEdit.Shapes.Variations.Animations.ShapeMaker_AnimatedThing FireMaker = new CEdit.Shapes.Variations.Animations.ShapeMaker_AnimatedThing();

            var myFire_Red = new CEdit.Shapes.Variations.Animations.Fire_Medium(CEdit.Shapes.Variations.Animations.Fire_Medium.fireColors.Red);
            var myFire_Blue = new CEdit.Shapes.Variations.Animations.Fire_Medium(CEdit.Shapes.Variations.Animations.Fire_Medium.fireColors.Blue);
            var myFire_Green = new CEdit.Shapes.Variations.Animations.Fire_Medium(CEdit.Shapes.Variations.Animations.Fire_Medium.fireColors.Green);
            var myFire_Magenta = new CEdit.Shapes.Variations.Animations.Fire_Medium(CEdit.Shapes.Variations.Animations.Fire_Medium.fireColors.Magenta);

            myFire_Red.SetShapeCoordinates(40, 40);
            myFire_Blue.SetShapeCoordinates(40, 70);
            myFire_Green.SetShapeCoordinates(40, 100);
            myFire_Magenta.SetShapeCoordinates(40, 130);

            myFire_Red.Initialize_AddToMasterList(true);
            myFire_Blue.Initialize_AddToMasterList(true);
            myFire_Green.Initialize_AddToMasterList(true);
            myFire_Magenta.Initialize_AddToMasterList(true);
        }
    }
}
