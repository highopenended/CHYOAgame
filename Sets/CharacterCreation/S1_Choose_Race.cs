using System;
using System.Collections.Generic;
using Chyoa.Sets.Prefabs;

namespace Chyoa.Sets.CharacterCreation
{
    public class S1_Choose_Race : Scene
    {
        public S1_Choose_Race(PalStuff.Pal _palTristall)
        {
            palTristall = _palTristall;
        }

        PalStuff.Pal palTristall;


  
        List<string> lRaceNames = new List<string>()
            {
                "Human",
                "Asher",
                "Sephrie",
                "Tol'Roth"
            };
        List<string> lDescrips = new List<string>()
            {
                PalStuff.Races.Human.Race_Description,
                PalStuff.Races.Asher.Race_Description,
                PalStuff.Races.Sephrie.Race_Description,
                PalStuff.Races.Tol_Roth.Race_Description,
            };

        int ChoiceBoxes_StartTop;
        int ChoiceBoxes_StartLeft;
        int ChoiceBoxes_Width;
        int ChoiceBoxes_Height;
        int widestChoiceBox;

        int descriptionBox_Width;
        int descriptionBox_Height;
        int descriptionBox_Top;
        int descriptionBox_Left;

        List<List<string>> listOfLists_HighlightedWords = new List<List<string>>
        {
            PalStuff.Races.Human.Race_Description_lHighlightedWords,
            PalStuff.Races.Asher.Race_Description_lHighlightedWords,
            PalStuff.Races.Sephrie.Race_Description_lHighlightedWords,
            PalStuff.Races.Tol_Roth.Race_Description_lHighlightedWords
        };
        List<CEdit.Shapes.Shape> lShapes = new List<CEdit.Shapes.Shape>();
        List<CEdit.Shapes.Shape> lDescriptionBoxes = new List<CEdit.Shapes.Shape>();


        CEdit.Shapes.Shape selectedShape;
        int selectedIndex;

        PalStuff.Pal newCharacterPal;


        public override void Display_Scene()
        {

            //Sequence_OpeningDescription();
            SpeechBoxPrompt_WhoAreYou();

            Set_ChoiceBoxes_CoordInfo();
            Initialize_ChoiceBoxes();
            Set_WidestChoiceBox();

            Set_DescriptionBox_Coords();
            Initialize_DescriptionBoxes();

            Await_UserChoice();
            Create_NewPal();

            Move_Shapes_Offscreen();
            Move_Tristall_And_SelectedOption();
            SpeechBox_Tristall_Response();




            //=================================================================
            //  The opening scene cycle-through.
            //=================================================================
            void Sequence_OpeningDescription()
            {
                List<string> listOfstrings = new List<string>();

                listOfstrings.Add("You slowly regain consciousness, clinging to lucidity with difficulty. @ @ @ @ You have a splitting headache and your breathing is ragged. @ ");
                listOfstrings.Add("Where are you?");
                listOfstrings.Add("Squinting through bleary eyes, you see a wagon nearby engulfed in angry flames.");
                listOfstrings.Add("Wait...");
                listOfstrings.Add("That's your wagon!");
                listOfstrings.Add("You struggle to your feet and begin stumbling towards the burning wreckage.");
                listOfstrings.Add("Before you can take more than a couple of steps, there's a bright flash accompanied by a booming explosion.");
                listOfstrings.Add("You are thrown backwards to the ground.");
                listOfstrings.Add("The heat from the blast is amazingly intense and you are forced to turn away. @ @ Another larger blast ensues.");
                listOfstrings.Add("You start to scramble away on hands and knees as chunks of flaming debris rain down around you. You try yelling for help, but the stinging smoke burns your eyes and throat and all you manage is a ragged cough.");
                listOfstrings.Add("You crack your eyes open and see figures running around in frantic confusion. The only sound is a high-pitched ringing sound.");
                listOfstrings.Add("As the ringing sound begins to fade, a chaotic chorus of shouts and clanging metal assaults your ears.");
                listOfstrings.Add("Still trying to make sense of your surroundings, you suddenly notice a man in singed clothing rushing towards you. @ @ Through the smoldering holes in his cloak, you're able to make out the dull gleam of plate armor. He holds a silver-engraved war hammer in his hand.");

                var listOfSequenceTextboxes = SceneTools.Get_ListOfTextboxShapes_Typer(listOfstrings, 70, 2, PUBVAR.Colors.Red, PUBVAR.Colors.White, false);
                SceneTools.CycleThrough_ListOfTextBoxes(listOfSequenceTextboxes);
            }


            //=================================================================
            //  Create Tristall and ask who player is (Race).
            //=================================================================
            void SpeechBoxPrompt_WhoAreYou()
            {
                palTristall.Set_Face_Coordinates(-10, 10);
                palTristall.Face_MakeVisible();
                palTristall.myFace.AddMovementPlan_MoveToLocation(10, 10);
                palTristall.Assign_SpeechBox("Hey, you! Still alive? My name is Tristall.");
                palTristall.Assign_SpeechBox("Who are you?");
                palTristall.myFace.AddMovementPlan_MoveToLocation(10, 10);
            }


            //=================================================================
            //  Decide where first choice box will be and the others will
            //  follow based on size.
            //=================================================================
            void Set_ChoiceBoxes_CoordInfo()
            {
                ChoiceBoxes_Width = 25;
                ChoiceBoxes_Height = 3;
                ChoiceBoxes_StartTop = 10;
                ChoiceBoxes_StartLeft = 50;
            }


            //=================================================================
            //  Create and initialize the choice boxes the user can 
            //  scroll through.
            //=================================================================
            void Initialize_ChoiceBoxes()
            {
                string opt1_Human = "I am a merchant from Silverpass. @ [Human]";
                string opt2_Asher = "I am a merchant from High Purpose. @ [Asher]";
                string opt3_Sephrie = "I am a merchant from Far Wood. @ [Sephrie]";
                string opt4_TolRoth = "I am a merchant from Southkeep. @ [Tol'Roth]";
                
                lShapes.Add(mTool.SM_Text.CreateShape_StaticTextbox(opt1_Human, ChoiceBoxes_Width, ChoiceBoxes_Height,PUBVAR.Colors.White, PUBVAR.Colors.Blue, listOfLists_HighlightedWords[0], PUBVAR.Colors.Yellow, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                lShapes.Add(mTool.SM_Text.CreateShape_StaticTextbox(opt2_Asher, ChoiceBoxes_Width, ChoiceBoxes_Height, PUBVAR.Colors.White, PUBVAR.Colors.Blue, listOfLists_HighlightedWords[1], PUBVAR.Colors.Yellow, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                lShapes.Add(mTool.SM_Text.CreateShape_StaticTextbox(opt3_Sephrie, ChoiceBoxes_Width, ChoiceBoxes_Height, PUBVAR.Colors.White, PUBVAR.Colors.Blue, listOfLists_HighlightedWords[2], PUBVAR.Colors.Yellow, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));
                lShapes.Add(mTool.SM_Text.CreateShape_StaticTextbox(opt4_TolRoth, ChoiceBoxes_Width, ChoiceBoxes_Height, PUBVAR.Colors.White, PUBVAR.Colors.Blue, listOfLists_HighlightedWords[3], PUBVAR.Colors.Yellow, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true));                
            }


            //=================================================================
            //  Sets the widestChoiceBox for determining where the 
            //  description box's left should be.
            //=================================================================
            void Set_WidestChoiceBox()
            {
                for (int i = 0; i < lShapes.Count; i++)
                {
                    if (lShapes[i].Width > widestChoiceBox)
                    {
                        widestChoiceBox = lShapes[i].Width;
                    }
                }
            }


            //=================================================================
            //  Set coordinates of static the description box.
            //=================================================================
            void Set_DescriptionBox_Coords()
            {
                descriptionBox_Width = 50;
                descriptionBox_Height = 20;
                descriptionBox_Top = 10;
                descriptionBox_Left = ChoiceBoxes_StartLeft + widestChoiceBox + 5;
            }


            //=================================================================
            //  Several SAME SIZE AND COORDINATE boxes that will 'cycle' 
            //  as the user swaps between choices.
            //=================================================================
            void Initialize_DescriptionBoxes()
            {
                lDescriptionBoxes = SceneTools.UI_SelectFromOptions_GetSameSizeDescriptionBoxes(lDescrips, PUBVAR.Colors.DarkYellow, PUBVAR.Colors.White, descriptionBox_Width, descriptionBox_Height, listOfLists_HighlightedWords, PUBVAR.Colors.Yellow);                
            }


            //=================================================================
            //  Get the shape & index that the user chooses.
            //=================================================================
            void Await_UserChoice()
            {                
                SceneTools.UI_SelectFromOptions(SceneTool_Master.SelectionTypes.UpDown, lShapes, ChoiceBoxes_StartTop, ChoiceBoxes_StartLeft, false, out selectedShape, out selectedIndex, 1, 1, lDescriptionBoxes, descriptionBox_Top, descriptionBox_Left);
            }


            //=================================================================
            //  Create Pal based on user's choice of race.
            //=================================================================
            void Create_NewPal()
            {
                newCharacterPal = new PalStuff.Pal("HOLDER");
                string raceName = lRaceNames[selectedIndex];

                switch (raceName)
                {
                    case "Human":
                        newCharacterPal.Initialize_PalRace(new PalStuff.Races.Human());
                        break;

                    case "Asher":
                        newCharacterPal.Initialize_PalRace(new PalStuff.Races.Asher());
                        break;

                    case "Sephrie":
                        newCharacterPal.Initialize_PalRace(new PalStuff.Races.Sephrie());
                        break;

                    case "Tol'Roth":
                        newCharacterPal.Initialize_PalRace(new PalStuff.Races.Tol_Roth());
                        break;
                }

                Shared.GameMaster.PlayerPal = newCharacterPal;
            }


            //=================================================================
            //  Move all the shapes offscreen and then delete them in 
            //  preperation for the next scene.
            //=================================================================
            void Move_Shapes_Offscreen()
            {
                for (int i = 0; i < lDescriptionBoxes.Count; i++)
                {
                    lDescriptionBoxes[i].Tick_ChangeStepDistancesUDLR(10,5, true);
                    lDescriptionBoxes[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Up, 30);
                }

                for (int i = 0; i < lShapes.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        lShapes[i].Deselect_ThisShape();
                    }
                    else
                    { 
                        lShapes[i].Tick_ChangeStepDistancesUDLR(10, 5, true);
                        lShapes[i].AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Up, 30);
                    }


                }
            }


            //=================================================================
            //  Chosen option is moved to the top right (so player can see it)
            //  and Tristall is moved to the center of the screen.
            //=================================================================
            void Move_Tristall_And_SelectedOption()
            {

                palTristall.myFace.Tick_ChangeStepDistancesUDLR(5, 1, true);
                palTristall.myFace.AddMovementPlan_SingleDirection(CEdit.Shapes.Shape.MovementsAndActions.Right, 10);

                int newLeft = Shared.EventColumn_Update.EventColumnLeft - selectedShape.Width;
                selectedShape.AddMovementPlan_MoveToLocation(5, newLeft);
            }
            

            //=================================================================
            //  Tristall's response to player's choice of race.
            //=================================================================
            void SpeechBox_Tristall_Response()
            {
                switch(Shared.GameMaster.PlayerPal.Race.RacialName)
                {
                    // HUMAN
                    case PalStuff.Races.Race.RaceName.Human:
                        palTristall.Assign_SpeechBox("Did you say you were from Silverpass? @ @ By the balance it's good to see a fellow Passer this far from the capital. Eleesea knows there are few enough men of honor around here.");
                        palTristall.Increase_OpinionOfPlayer(30, $"{ palTristall.Name } is also from Silverpass");
                        break;

                    // ASHER
                    case PalStuff.Races.Race.RaceName.Asher:
                        palTristall.Assign_SpeechBox("An Asher, ey?  Couldn't tell with you all covered in soot. Don't see many of you outside of the mountains.");
                        break;
                    
                    // SEPHRIE
                    case PalStuff.Races.Race.RaceName.Sephrie:
                        palTristall.Assign_SpeechBox("Tch. @ @ I should have known there was a filthy profaner around here with all this bad luck I've been having. Well, it can't be helped.");
                        palTristall.Decrease_OpinionOfPlayer(30, $"{ palTristall.Name } doesn't like Sephries");
                        break;                        

                    // TOL'ROTH
                    case PalStuff.Races.Race.RaceName.Tol_Roth:
                        palTristall.Assign_SpeechBox("Ah... I should've known from your bloody size. Well let's put that to use.");
                        palTristall.Increase_OpinionOfPlayer(10);
                        break;
                }
            }
        }
    }
}
