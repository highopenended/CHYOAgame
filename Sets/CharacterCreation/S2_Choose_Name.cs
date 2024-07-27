using System.Collections.Generic;
using Chyoa.Sets.Prefabs;
using Chyoa.Shared;

namespace Chyoa.Sets.CharacterCreation
{
    public class S2_Choose_Name: Scene
    {

        public S2_Choose_Name(PalStuff.Pal _palTristall)
        {
            palTristall = _palTristall;
        }
        PalStuff.Pal palTristall;

        // OldName will be the same as NewName unless it was a special name
        string OldName = "";
        string NewName = "";
        

        CEdit.Shapes.Variations.TextBoxShapes.UserInput_TypeLine typingLine;
        CEdit.Shapes.Shape typingLine_Box;
        CEdit.Shapes.Shape TypingLine_HeaderShape;
        CEdit.Shapes.Shape newName_Shape;
        CEdit.Shapes.Shape finalBox;

        /// <summary>
        /// Move the name shape up to top right corner
        /// </summary>
        public override void Display_Scene()
        {

            int centerScreen_Width = (PUBVAR.windowWidth / 2) - 20;


            MoveTristall_IntoPosition();
            SpeechBoxPrompt_WhatsYourName();

            Create_TypingLine();
            DeterminePlayersName();

            MoveShape_NameBox();
            Remove_TypingLineShapes();

            Tristall_ResponseToName();
            



            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //      Internal Methods


            void MoveTristall_IntoPosition()
            {
                palTristall.myFace.AddMovementPlan_MoveToLocation(10, 10);
            }

            void SpeechBoxPrompt_WhatsYourName()
            {
                switch(GameMaster.PlayerPal.RaceName)
                {
                    case PalStuff.Races.Race.RaceName.Human:
                        palTristall.Assign_SpeechBox("What is your name, friend?");
                        break;

                    case PalStuff.Races.Race.RaceName.Asher:
                        palTristall.Assign_SpeechBox("What is your name, friend?");
                        break;

                    case PalStuff.Races.Race.RaceName.Sephrie:
                        palTristall.Assign_SpeechBox("I assume you have a name?  Let's have it...");
                        break;

                    case PalStuff.Races.Race.RaceName.Tol_Roth:
                        palTristall.Assign_SpeechBox("You have a name?");
                        break;
                }
            }

            void Create_TypingLine()
            {
                // Create the line, the box around it, and the header
                typingLine = mTool.SM_Text.CreateShape_TypingLine(25, centerScreen_Width + 8, 15);
                typingLine_Box = mTool.SM_CustomBox.Get_CustomBox(30, 8, CEdit.Shapes.ShapeMaker_Text.BorderStyles.Style_SpeechBox);
                TypingLine_HeaderShape = mTool.SM_Text.CreateShape_StringOnly("CHOOSE A NAME");



      



                // Set the proper coordinates
                typingLine_Box.SetShapeCoordinates(20, centerScreen_Width);
                TypingLine_HeaderShape.SetShapeCoordinates(19, centerScreen_Width + 8);

                // Add to master list
                typingLine.Initialize_AddToMasterList(true);
                typingLine_Box.Initialize_AddToMasterList(true);
                TypingLine_HeaderShape.Initialize_AddToMasterList(true);
            }

            void DeterminePlayersName()
            {
                bool continueLooping = true;
                while (continueLooping)
                {
                    // char myKey = Console.ReadKey(true).KeyChar;
                    var key = PUBVAR.MyReadKey();
                    if (key != null)
                    {
                        char myKey = key.Value.KeyChar;
                        typingLine.UpdateNextKeyInput(myKey);
                    }

                    OldName = typingLine.GetOutputName_AfterCheckForCompletion();
                    if (OldName != null)
                    {

                        NewName = SpecialNameCheck(OldName);

                        string fullMessage = $"A brave new adventurer by the name of {NewName} has emerged!";
                        GameMaster.PlayerPal.Name = NewName;

                        EventColumn_Update.AddEvent_To_EventColumn(fullMessage, PUBVAR.Colors.Green, PUBVAR.Colors.White, -1, -1, new List<string>() { Shared.GameMaster.PlayerPal.Name });
                        continueLooping = false;
                    }
                }
                
                string SpecialNameCheck(string checkName)
                {
                    switch(checkName.ToUpper())
                    {
                        case "SEAMUS":
                        case "SHAE":
                        case "SWAGLORD":
                        case "SWAG LORD":
                        case "BOOTY":
                            return "Ranchfoot";
                        case "TRISTALL":
                            if(GameMaster.PlayerPal.Race.RacialName == PalStuff.Races.Race.RaceName.Sephrie)
                            {
                                return "Shit Helmet";
                            }
                            else
                            {
                                return "Idiot";
                            };
                        default:
                            return checkName;
                    }
                }
            }

            void MoveShape_NameBox()
            {

                int newLeft = EventColumn_Update.EventColumnLeft - NewName.Length - 11;

                //newName_Shape.AddMovementPlan_DeleteThisShape(true);

                finalBox = mTool.SM_Text.CreateShape_StaticTextbox(GameMaster.PlayerPal.Name, GameMaster.PlayerPal.Name.Length,1,PUBVAR.Colors.White,PUBVAR.Colors.Blue);
                finalBox.SetShapeCoordinates(typingLine_Box.Top, centerScreen_Width);
                finalBox.Initialize_AddToMasterList(true);
                finalBox.AddMovementPlan_MoveToLocation(1, newLeft);
            }





            
            void Remove_TypingLineShapes()
            {
                typingLine.AddMovementPlan_DeleteThisShape(true);
                typingLine.ConsoleBlinker.AddMovementPlan_DeleteThisShape(true);
                typingLine_Box.AddMovementPlan_DeleteThisShape(true);
                typingLine_Box.AddMovementPlan_DeleteThisShape(true);
                TypingLine_HeaderShape.AddMovementPlan_DeleteThisShape(true);
            }

            void Tristall_ResponseToName()
            {
                string response;

                Determine_Response();
                palTristall.Assign_SpeechBox(response);


                void Determine_Response()
                {
                    response = "DefaultName";
                    switch (OldName.ToUpper())
                    {
                        case "TRISTALL":
                            switch (GameMaster.PlayerPal.Race.RacialName)
                            {
                                case PalStuff.Races.Race.RaceName.Human:
                                case PalStuff.Races.Race.RaceName.Asher:
                                case PalStuff.Races.Race.RaceName.Tol_Roth:
                                    response = $"Are you trying to be funny? There is no chance we have the same name. How about I just called you {GameMaster.PlayerPal.Name} instead?";
                                    break;
                                case PalStuff.Races.Race.RaceName.Sephrie:
                                    response = $"You're a real funny guy, aren't you? Leave it to a {GameMaster.PlayerPal.Race.RacialName} to make jokes at a time like this. How about I just call you {GameMaster.PlayerPal.Name} instead?";
                                    break;
                            }
                            break;
                        default:
                            switch (GameMaster.PlayerPal.Race.RacialName)
                            {
                                case PalStuff.Races.Race.RaceName.Human:
                                    response = $"{ GameMaster.PlayerPal.Name }, ey? A fine name!";
                                    break;
                                case PalStuff.Races.Race.RaceName.Asher:
                                    response = $"Did you say... { GameMaster.PlayerPal.Name }? I guess you Ashers always have had interesting names.";
                                    break;
                                case PalStuff.Races.Race.RaceName.Tol_Roth:
                                    response = $"{ GameMaster.PlayerPal.Name }? Go figure a {GameMaster.PlayerPal.Race.Name_Singular} would have a name like that...";
                                    break;
                                case PalStuff.Races.Race.RaceName.Sephrie:
                                    response = $"{ GameMaster.PlayerPal.Name }? I suppose it will do.";
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
