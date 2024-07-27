using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets.CharacterCreation
{
    public class Set_Manager: Prefabs.SetManager
    {
        //========================
        //      Set Pals
        //========================

        public static readonly PalStuff.Pal palTristall = new PalStuff.Pal("Tristall", CEdit.Shapes.ShapeMaker_Face.PremadeFaces.Tristall);


        //========================
        //      Scenes
        //========================

        S1_Choose_Race      Scene_ChooseRace    = new S1_Choose_Race(palTristall);
        S2_Choose_Name      Scene_ChooseName    = new S2_Choose_Name(palTristall);      
        S3_Choose_Weapon    Scene_ChooseWeapon  = new S3_Choose_Weapon(palTristall);
        Choose_Armor        Scene_ChooseArmor   = new Choose_Armor();

        public override void Start_Scene()
        {
            Scene_ChooseRace.Display_Scene();
            Scene_ChooseName.Display_Scene();
            Scene_ChooseWeapon.Display_Scene();
        }
    }
}
