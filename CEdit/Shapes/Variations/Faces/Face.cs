using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.Faces
{
    public class Face : Shape
    {
        ShapeMaker_Text TextBoxMaker = new ShapeMaker_Text();

        // CONSTRUCTOR
        public Face(List<char[,]> lArrayOfCharacters, List<char[,]> lArrayOfColors_FG, List<char[,]> lArrayOfColors_BG)
        {
            Initialize_ArrayLists();
            Initialize_DefaultValues();            

            void Initialize_ArrayLists()
            {
                cycleArrays_Chars = lArrayOfCharacters;
                cycleArrays_ColorsFG = lArrayOfColors_FG;
                cycleArrays_ColorsBG = lArrayOfColors_BG;

                // ColorsFG Null : Create empty arrays for the list if there isn't any info
                if (cycleArrays_ColorsFG == null)
                {
                    cycleArrays_ColorsFG = new List<char[,]>();
                    for (int i = 0; i < lArrayOfCharacters.Count; i++)
                    {
                        SetToEmptyArray(out char[,] tempArr);
                        cycleArrays_ColorsFG.Add(tempArr);
                    }
                }

                // ColorsBG Null : Create empty arrays for the list if there isn't any info
                if (cycleArrays_ColorsBG == null)
                {
                    cycleArrays_ColorsBG = new List<char[,]>();
                    for (int i = 0; i < lArrayOfCharacters.Count; i++)
                    {
                        SetToEmptyArray(out char[,] tempArr);
                        cycleArrays_ColorsBG.Add(tempArr);
                    }
                }                
                
                // Set initial arrays as the first of the cycle
                ArrChars = lArrayOfCharacters[0];
                ArrColors_FG = lArrayOfColors_FG[0];
                ArrColors_BG = lArrayOfColors_BG[0];
            } 
            void Initialize_DefaultValues()
            {
                InternalMovement_IsComplete = false;
                InternalMovement_PauseCounter = 0;
                InternalMovement_PauseCounter_Max = 1;
            }
        }

        // A "pause" counter to make movement less twitchy by forcing a pause between frames.
        protected int InternalMovement_PauseCounter { get; set; }
        protected int InternalMovement_PauseCounter_Max { get; set; }


        bool IsWaiting_MouthMovement = false;
        int waitTicks_BeforeSpeechBox = 0;
        public void Wait_Then_Add_Speechbox(PalStuff.Pal caller, string textToSpeak, bool checkForEnterKeyPress, int ticksToWait)
        {
            hold_Caller = caller;
            hold_textToSpeak = textToSpeak;
            hold_checkForEnterKeyPress = checkForEnterKeyPress;
            waitTicks_BeforeSpeechBox = ticksToWait;
            IsWaiting_MouthMovement = true;
            InternalMovement_IsComplete = false;
        }

        PalStuff.Pal hold_Caller;
        string hold_textToSpeak;
        bool hold_checkForEnterKeyPress;



        protected override void MoveOneTick_InternalMovement()
        {
            // Update pause (if there is one) before speechbox is added and begins
            if (IsWaiting_MouthMovement)
            {
                if (waitTicks_BeforeSpeechBox > 0)
                {
                    waitTicks_BeforeSpeechBox--;
                }
                else
                {
                    IsWaiting_MouthMovement = false;
                    waitTicks_BeforeSpeechBox = 0;
                    InternalMovement_IsComplete = false;
                    hold_Caller.Assign_SpeechBox(hold_textToSpeak, hold_checkForEnterKeyPress, 0, true);
                }
            }




            int beepLevel = 4000;
            if (SpeechBox != null)
            {

                SpeechBox.SetShapeCoordinates(Top + Height, Left - 3);
                if (!SpeechBox.InternalMovement_IsComplete)
                {
                    if (waitTicks_BeforeSpeechBox <= 0)
                    {
                        MoveMouth();

                    }
                    else
                    {
                        waitTicks_BeforeSpeechBox--;
                    }
                }
                else
                {
                    ArrChars = cycleArrays_Chars[0];
                    ArrColors_FG = cycleArrays_ColorsFG[0];
                    ArrColors_BG = cycleArrays_ColorsBG[0];
                }
            }



            void MoveMouth()
            {
                if (InternalMovement_PauseCounter >= InternalMovement_PauseCounter_Max)
                {
                    //Beeper.Beep(beepLevel, 1);
                    Set_NextFrame();
                    InternalMovement_PauseCounter = 0;
                }
                else { InternalMovement_PauseCounter++; }
            }            
        }


        //-----------------
        // MOUTH MOVEMENT
        //-----------------
        bool mouth_IsMoving;


        /// <summary>
        /// Mouth begins it's infinite cycle of opening and closing (talking)
        /// </summary>
        public void StartMovement_Mouth()
        {
            mouth_IsMoving = true;
            Update_InternalMovementStatus();
        }

        /// <summary>
        /// Mouth ends it's infinite cycle of opening and closing (talking)
        /// </summary>
        public void StopMovement_Mouth()
        {
            mouth_IsMoving = false;
            Update_InternalMovementStatus();
        }


        //-----------------
        // EYE MOVEMENT
        //-----------------
        bool Eyes_AreMoving { get; set; }

        /// <summary>
        /// Eyes begin their infinite cycle of shifting and blinking (natural movement)
        /// </summary>
        public void StartMovement_Eyes()
        {
            Eyes_AreMoving = true;
            Update_InternalMovementStatus();
        }

        /// <summary>
        /// Eyes end their infinite cycle of shifting and blinking (natural movement)
        /// </summary>
        public void StopMovement_Eyes()
        {
            Eyes_AreMoving = false;
            Update_InternalMovementStatus();
        }


        private void Update_InternalMovementStatus()
        {
            if(!mouth_IsMoving && !Eyes_AreMoving)
                 { InternalMovement_IsComplete = true; }
            else { InternalMovement_IsComplete = false; }
        }

        public TextBoxShapes.Typer_TextBox SpeechBox { get; private set; }
        public void Assign_SpeechBox(string TextToSay)
        {
            has_SpeechBox = true;
            SpeechBox = TextBoxMaker.CreateShape_TyperTextbox(TextToSay,Width-3, 2, PUBVAR.Colors.White, PUBVAR.Colors.Yellow, ShapeMaker_Text.BorderStyles.Style_SpeechBox, false, true);
            SpeechBox.SetShapeCoordinates(Top + Height + 2, Left-2);
            SpeechBox.Initialize_AddToMasterList(true);            
        }

        
        /// <summary>
        /// Complete the internal movement of the the speechbox (if present).  Basically completes the typing out process.
        /// </summary>
        public void Complete_Speechbox_InternalMovement()
        {
            if(has_SpeechBox) { SpeechBox.Tick_ImmediatelyCompleteMovement_Internal(); }
        }

        /// <summary>
        /// Delete the current speechbox
        /// </summary>
        public void Delete_SpeechBox_Current()
        {
            has_SpeechBox = false;
            SpeechBox.AddMovementPlan_DeleteThisShape();
        }
        
        private bool has_SpeechBox;
        public bool Has_SpeechBox { get { return has_SpeechBox; } }
                
        
        /// <summary>
        /// Sets the next frame arrays in the cycle
        /// </summary>
        void Set_NextFrame()
        {
            Set_NextFrame_Arrays();
            Update_FrameCounter();

            /// Get the next 3 arrays for the next frame.
            void Set_NextFrame_Arrays()
            {
                ArrChars = GetNextArr_Char();
                ArrColors_FG = GetNextArr_ColorFG();
                ArrColors_BG = GetNextArr_ColorBG();
            }

            // Update the counter
            void Update_FrameCounter()
            {
                if ((currentFrame_Counter + 1) < cycleArrays_Chars.Count)
                        { currentFrame_Counter++; }
                else    { currentFrame_Counter = 0; }
            }
        }

        int currentFrame_Counter = 0;

        List<char[,]> cycleArrays_Chars = new List<char[,]>();
        List<char[,]> cycleArrays_ColorsFG = new List<char[,]>();
        List<char[,]> cycleArrays_ColorsBG = new List<char[,]>();

        public char[,] GetNextArr_Char()    { return cycleArrays_Chars[currentFrame_Counter]; }
        public char[,] GetNextArr_ColorFG() { return cycleArrays_ColorsFG[currentFrame_Counter]; }
        public char[,] GetNextArr_ColorBG() { return cycleArrays_ColorsBG[currentFrame_Counter]; }
    }
}
