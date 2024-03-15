using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff
{

    public class Pal
    {
        public Pal(string name, CEdit.Shapes.ShapeMaker_Face.PremadeFaces palsFace)
        {
            Name = name;
            Speed = 1;
            Health = 10;

            Initialize_AssignNewFace(palsFace);
        }

        public Pal(string name)
        {
            Name = name;
            Speed = 1;
            Health = 10;
        }


        //======================================
        //      Stats
        //======================================
        public string Name { get; set; }
        public int Speed { get; private set; }
        public int Health { get; private set; }

        // -100 to +100
        public int Opinion_Of_Player { get { return opinion_Of_Player; } }
        int opinion_Of_Player = 0;


        /// <summary>
        /// -100 to +100
        /// </summary>
        /// <param name="amnt"></param>
        public void Increase_OpinionOfPlayer(int amnt, string explanation = "")
        {
            if (opinion_Of_Player + amnt <= 100)
                    { opinion_Of_Player += amnt; }
            else    { opinion_Of_Player = 100; }

            List<string> highlightWords = new List<string>()
            {
                "+" + amnt
            };

            string fullString;
            if(explanation == "")
            {
                fullString = $"{ Name }'s opinion of you has increased! @ Relationship : +{amnt} @ @ [ { opinion_Of_Player } / 100 ] @ ";
            }
            else
            {
                fullString = $" [ { explanation } ] @ @ { Name }'s opinion of you has increased! @ Relationship : +{amnt} @ @ [ { opinion_Of_Player } / 100 ] @ ";
                highlightWords.Add(explanation);
            }

            Shared.EventColumn_Update.AddEvent_To_EventColumn(fullString, PUBVAR.Colors.Green, PUBVAR.Colors.White, -1, -1, highlightWords, PUBVAR.Colors.Green);
        }

        /// <summary>
        /// -100 to +100
        /// </summary>
        /// <param name="amnt"></param>
        public void Decrease_OpinionOfPlayer(int amnt, string explanation = "")
        {
            amnt = Math.Abs(amnt);

            if (opinion_Of_Player - amnt >= -100)
                    { opinion_Of_Player -= amnt; }
            else    { opinion_Of_Player = -100; }

            List<string> highlightWords = new List<string>()
            {
                "-" + amnt
            };

            string fullString;
            if (explanation == "")
            {
                fullString = $"{ Name }'s opinion of you has decreased... @ Relationship : -{amnt} @ @ [ { opinion_Of_Player } / 100 ] @ ";
            }
            else
            {
                fullString = $" [ { explanation } ] @ @ { Name }'s opinion of you has decreased... @ Relationship : -{amnt} @ @ [ { opinion_Of_Player } / 100 ] @ ";
                highlightWords.Add(explanation);
            }


            Shared.EventColumn_Update.AddEvent_To_EventColumn(fullString, PUBVAR.Colors.Red, PUBVAR.Colors.White, -1, -1, highlightWords, PUBVAR.Colors.Red);;
        }

        //======================================
        //      Race
        //======================================
        public Races.Race Race { get; private set; }
        public Races.Race.RaceName RaceName { get; private set; }

        public void Initialize_PalRace(Races.Race _race)
        {
            Race = _race;
            RaceName = Race.RacialName;
            string message = $"Your race has been chosen!  You are {Race.Name_Singular_A_An} {Race.Name_Singular}";
            List<string> highlightWords = new List<string>() { Race.Name_Singular };
            Shared.EventColumn_Update.AddEvent_To_EventColumn(message, PUBVAR.Colors.Green,PUBVAR.Colors.White, -1, -1, highlightWords);
        }


        //======================================
        //      Face
        //======================================


        // Pal's framed face icon
        public CEdit.Shapes.Variations.Faces.Face myFace;
        void Initialize_AssignNewFace(CEdit.Shapes.ShapeMaker_Face.PremadeFaces faceToApply)
        {
            CEdit.Shapes.ShapeMaker_Face faceBoxMaker = new CEdit.Shapes.ShapeMaker_Face();
            myFace = faceBoxMaker.GetShape_Face_Premade(faceToApply);
        }




        /// <summary>
        /// Add a speech box underneath the character's face ( and returns a bool saying whether a key was hit before or after the internal movement was complete
        /// </summary>
        /// <param name="textToSpeak"> The text to appear in a box under face </param>
        /// <param name="checkForEnterKeyPress"> if true, then this function takes control until you hit a key and then completes </param>
        /// <returns></returns>
        public void Assign_SpeechBox(string textToSpeak, bool checkForEnterKeyPress = true, int WaitTimeBeforeStarting = 0, bool AutoProceed = false)
        {


            // Check for wait time.  If there is any, then this pal's Face shape will call this function again after the time has passed
            if (WaitTimeBeforeStarting <= 0)
            {

                // For determining whether or not there should be a completion of the textbox, then ADDITIONAL key press to proceed, or if the textbox is already complete and the initial key press should immediately proceed.
                bool PressedEnter_After_InternalMovementComplete = false;

                // Delete existing speechbox if there is one
                if (myFace.Has_SpeechBox) { myFace.Delete_SpeechBox_Current(); }

                myFace.Assign_SpeechBox(textToSpeak);
                if (checkForEnterKeyPress)
                {
                    bool continueLoop = true;
                    while (continueLoop)
                    {
                        // Autoproceed is only on if there was a wait time before adding the speechbox
                        if (AutoProceed)
                            { doThing(); }
                        else if (PUBVAR.MyReadKey() != null)
                            { doThing(); }
                    }

                    void doThing()
                    {
                        if (myFace.SpeechBox.InternalMovement_IsComplete || AutoProceed)
                        {
                            PressedEnter_After_InternalMovementComplete = true;
                            myFace.SpeechBox.InternalMovement_WillBeComplete_NextTick = false;
                        }
                        else
                        {
                            PressedEnter_After_InternalMovementComplete = false;
                        }

                        myFace.Complete_Speechbox_InternalMovement();
                        continueLoop = false;
                        AutoProceed = false;
                    }
                }

                // Adds a "pause" after a key press where the textbox completes it's internal text before moving on to the next textbox
                if (!PressedEnter_After_InternalMovementComplete) { Console.ReadKey(); }
            }
            else
            {
                myFace.Wait_Then_Add_Speechbox(this, textToSpeak, checkForEnterKeyPress, WaitTimeBeforeStarting);
            }
        }


        /// <summary>
        /// Delete the current speech box (both from master list and from this Pal)
        /// </summary>
        public void Delete_SpeechBox_Current()
        {
            myFace.Delete_SpeechBox_Current();
        }



        /// <summary>
        /// Set the shape coordinates for this face
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        public void Set_Face_Coordinates(int top, int left)
        {
            myFace.SetShapeCoordinates(top, left);
        }

        /// <summary>
        /// Make this pal's facebox visible
        /// </summary>
        public void Face_MakeVisible()
        {
            if (myFace != null)
            {
                CEdit.DisplayLists.AddToWaitList_AddToMasterList(myFace);
                myFace.Tick_MakeVisible();
            }
        }

        /// <summary>
        /// Make this pal's facebox visible
        /// </summary>
        public void Face_MakeInvisible()
        {
            if (myFace != null) { myFace.Tick_MakeInvisible(); }
        }

        /// <summary>
        /// Start the infinite mouth movement cycle
        /// </summary>
        public void Face_StartMovement_Mouth()
        {
            myFace.StartMovement_Mouth();
        }

        /// <summary>
        /// Stop the infinite mouth movement cycle
        /// </summary>
        public void Face_StopMovement_Mouth()
        {
            myFace.StopMovement_Mouth();
        }
        

        //======================================
        //      Equipment
        //======================================
        public Armors.Armor EquippedArmor { get; private set; }
        public Weapons.Weapon EquippedWeapon { get; private set; }

        public void Equip_Armor(Armors.Armor armorToEquip)
        {
            EquippedArmor = armorToEquip;
        }
        public void Equip_Weapon(Weapons.Weapon weaponToEquip)
        {
            EquippedWeapon = weaponToEquip;
        }


        /// <summary>
        /// Return either a static minimum of dmg reduction, or a percentage reduction -- whichever is greater
        /// </summary>
        /// <param name="DamageBeforeArmor"></param>
        /// <returns></returns>
        public float Get_Armor_DamageReductionAmnt(float DamageBeforeArmor)
        {
            float damage_PercentReduce = (float)((EquippedArmor.ArmorLevel * .1) * DamageBeforeArmor);
            float damage_FlatReduce = EquippedArmor.ArmorLevel * 3;

            return Math.Max(damage_PercentReduce, damage_FlatReduce);
        }

        /// <summary>
        /// Use this method to reduce a pal's health (min of 0)
        /// </summary>
        /// <param name="ReduceByAmnt"></param>
        public void ReduceHealth(int ReduceByAmnt)
        {
            if ((Health - ReduceByAmnt) >= 0)
                    { Health -= ReduceByAmnt; }
            else    { Health = 0; }
        }
    }
}
