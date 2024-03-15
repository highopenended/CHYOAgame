using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chyoa.CEdit.Shapes.Variations.Weapons;

namespace Chyoa.CEdit.Shapes
{
    public class ShapeMaker_Weapons
    {
        Sword sword = new Sword();
        Axe axe = new Axe();
        Hammer hammer = new Hammer();
        Unarmed unarmed = new Unarmed();

        public void GetWeapon(WeaponTypes weaponType, out Shape Shape_Weapon)
        {
            char[,] arrChars;
            char[,] arrColorsFG;
            char[,] arrColorsBG;

            switch (weaponType)
            {
                case WeaponTypes.Sword:
                    arrChars    = sword.arr_Chars;
                    arrColorsFG = sword.arr_ColorsFG;
                    arrColorsBG = sword.arr_ColorsBG;
                    break;

                case WeaponTypes.Axe:
                    arrChars    = axe.arr_Chars;
                    arrColorsFG = axe.arr_ColorsFG;
                    arrColorsBG = axe.arr_ColorsBG;
                    break;

                case WeaponTypes.Hammer:
                    arrChars    = hammer.arr_Chars;
                    arrColorsFG = hammer.arr_ColorsFG;
                    arrColorsBG = hammer.arr_ColorsBG;
                    break;

                case WeaponTypes.Unarmed:
                    arrChars = unarmed.arr_Chars;
                    arrColorsFG = unarmed.arr_ColorsFG;
                    arrColorsBG = unarmed.arr_ColorsBG;
                    break;

                default:
                    arrChars    = sword.arr_Chars;
                    arrColorsFG = sword.arr_ColorsFG;
                    arrColorsBG = sword.arr_ColorsBG;
                    break;
            }

            Shape_Weapon = new Shape(arrChars, arrColorsFG, arrColorsBG);
        }
               
        public enum WeaponTypes
        {
            Sword,
            Axe,
            Hammer,
            Unarmed
        }
    }
}
