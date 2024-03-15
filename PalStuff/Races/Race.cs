using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Race
    {
        // Race Enum
        public RaceName RacialName { get; set; }


        // Different ways the name can be appear based on context 
        // (ex. Elf, Elves, Elven)
        public string Name_Singular         { get; set; }
        public string Name_Singular_A_An    { get; set; }
        public string Name_Plural           { get; set; }
        public string Name_Adjective        { get; set; }
        

        
        public string Get_Name_Singular()   { return Name_Singular; }

        protected string description;
        public string Description { get { return description; } }

        protected List<string> description_lHighlightedWords;
        public List<string> Description_lHighlightedWords { get { return description_lHighlightedWords; } }


        protected virtual void Initialize_Race(){}

        public enum RaceName
        {
            Human,
            Asher,
            Sephrie,
            Tol_Roth
        }
        public enum RareRace
        {
            Ember_tol
        }
    }
}
