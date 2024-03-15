using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chyoa.Sets.Prefabs;

namespace Chyoa.Sets.CharacterCreation
{
    public class S3_Choose_Weapon : Scene
    {
        CEdit.Shapes.Mtool mtool = new CEdit.Shapes.Mtool();
        public S3_Choose_Weapon(PalStuff.Pal _palTristall)
        {
            palTristall = _palTristall;
        }
        PalStuff.Pal palTristall;


        public override void Display_Scene()
        {
            int centerScreen = (PUBVAR.windowWidth / 2) - 20;


            EventMessage_NearbyWeapons();
            SpeechBoxPrompt_WhichWeapon();

            

            void SpeechBoxPrompt_WhichWeapon()
            {
                switch (Shared.GameMaster.PlayerPal.RaceName)
                {
                    case PalStuff.Races.Race.RaceName.Human:
                        palTristall.Assign_SpeechBox($"Can you fight, {Shared.GameMaster.PlayerPal.Name}? I could really use someone trustworthy to help clean up this mess!", true);
                        break;

                    case PalStuff.Races.Race.RaceName.Asher:
                        palTristall.Assign_SpeechBox("What's your weapon, friend?", true);
                        break;

                    case PalStuff.Races.Race.RaceName.Sephrie:
                        palTristall.Assign_SpeechBox("What's your weapon, friend?", true);
                        break;

                    case PalStuff.Races.Race.RaceName.Tol_Roth:
                        palTristall.Assign_SpeechBox("What's your weapon, friend?", true);
                        break;
                }
                
            }

            
            void EventMessage_NearbyWeapons()
            {
                Shared.EventColumn_Update.AddEvent_To_EventColumn("One of the nearby crates was overturned in the chaose and weapons are spilling out.", PUBVAR.Colors.DarkYellow, PUBVAR.Colors.White, 20, 100);
            }
            
            mtool.SM_Weapons.GetWeapon(CEdit.Shapes.ShapeMaker_Weapons.WeaponTypes.Sword,   out var sword);
            mtool.SM_Weapons.GetWeapon(CEdit.Shapes.ShapeMaker_Weapons.WeaponTypes.Axe,     out var axe);
            mtool.SM_Weapons.GetWeapon(CEdit.Shapes.ShapeMaker_Weapons.WeaponTypes.Hammer,  out var hammer);
            mtool.SM_Weapons.GetWeapon(CEdit.Shapes.ShapeMaker_Weapons.WeaponTypes.Unarmed, out var unarmed);

            // List of weapon choices
            List<CEdit.Shapes.Shape> listOfWeapons = new List<CEdit.Shapes.Shape>()
            {
                sword,
                axe,
                hammer,
                unarmed
            };

            // list of descriptions for each choice
            List<string> listOfDescriptions = new List<string>()
            {
                "Swords are well-balanced and reliable! @ @ Testing",
                "This is an axe",
                "This is a hammer",
                "This are dem hands"
            };

            // Get equal-sized textboxes
            List<CEdit.Shapes.Shape> lDescriShapes = SceneTools.UI_SelectFromOptions_GetSameSizeDescriptionBoxes(listOfDescriptions, PUBVAR.Colors.White, PUBVAR.Colors.DarkRed, 30, 5); 

            // Do the four-square selection
            SceneTools.UI_SelectFromOptions(SceneTool_Master.SelectionTypes.FourSquare, listOfWeapons, 10, 50, false, out CEdit.Shapes.Shape chosenShape, out int choice, 5, 1, lDescriShapes,35,5);



            Console.ReadKey();

        }
    }
}
