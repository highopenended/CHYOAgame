using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit.Shapes.Variations.TextBoxShapes
{
    public class UserInput_TypeLine : Shape
    {

        public UserInput_TypeLine(StringEdit.Blinker consoleBlinker, char[,] arrayOfCharacters, char[,] arrayOfColors_FG = null, char[,] arrayOfColors_BG = null) : base(arrayOfCharacters, arrayOfColors_FG, arrayOfColors_BG)
        {
            isLocked = false;
            currentIndex = 0;
            ConsoleBlinker = consoleBlinker;

            ConsoleBlinker.Initialize_AddToMasterList(true);            
        }

        public StringEdit.Blinker ConsoleBlinker;


        public bool isLocked { get; set; }
        public int currentIndex { get; private set; }

        string returnString = "";

        public void UpdateNextKeyInput(char nextChar)
        {
            switch (nextChar)
            {
                // BACKSPACE
                case '\b':
                    if (currentIndex - 1 >= 0)
                    {
                        ArrChars[0, currentIndex-1] = '_';
                        currentIndex--;
                        ConsoleBlinker.SetShapeCoordinates(Top, (Left + currentIndex));
                        returnString = returnString.Substring(0, returnString.Length - 1);
                    }
                    break;

                case PUBVAR.omitChar:
                    // Do nothing
                    break;

                case '\r':
                    if (Check_IsStringIsAcceptable())
                    {
                        acceptableNameHasBeenChosen = true;
                    }
                    break;

                                       
                default:
                    if (currentIndex + 1 <= Width)
                    {
                        if (PUBVAR.checkIfAllowedCharacter(nextChar))
                        {
                            ArrChars[0, currentIndex] = nextChar;
                            ConsoleBlinker.SetShapeCoordinates(Top, (Left + currentIndex) + 1);
                            currentIndex++;
                            returnString += nextChar;
                        }
                    }
                    break;
            }
        }

        // Make sure the string input by the user is acceptable
        bool Check_IsStringIsAcceptable()
        {
            if (returnString.Length < 2)
            {
                string eventMessage = "Come on. At least make it two letters...";
                Shared.EventColumn_Update.AddEvent_To_EventColumn(eventMessage, PUBVAR.Colors.DarkYellow, PUBVAR.Colors.Red);
                return false;
            }
            else
            {
                return true;
            }
        }


        bool acceptableNameHasBeenChosen = false;

        /// <summary>
        /// Check if the name is ready to be received or not (call before calling GetOutputName_AfterCheckForCompletion)
        /// </summary>
        /// <returns></returns>
        public bool CheckForCompletion()
        {
            if (acceptableNameHasBeenChosen)
                    { return true; }
            else    { return false; }
        }


        /// <summary>
        /// Get the final chosen name (only after calling CheckForCompletion)
        /// </summary>
        /// <returns></returns>
        public string GetOutputName_AfterCheckForCompletion()
        {
            if(acceptableNameHasBeenChosen)
            {
                acceptableNameHasBeenChosen = false;
                return returnString;
            }
            else { return null; }
        }



        protected override void Complete_InternalMovement()
        {
            base.Complete_InternalMovement();
        }
    }
}
