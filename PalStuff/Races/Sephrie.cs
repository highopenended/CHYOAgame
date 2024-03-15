using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Sephrie:Race
    {
        public Sephrie()
        {
            Initialize_Race();
        }
        

        protected override void Initialize_Race()
        {
            base.Initialize_Race();

            RacialName = RaceName.Sephrie;
            Name_Singular = "Sephrie";
            Name_Singular_A_An = "a";
            Name_Plural = "Sephries";
            Name_Adjective = "Sephrien";

            description = Race_Description;
            description_lHighlightedWords = Race_Description_lHighlightedWords;
        }


        public static readonly string Race_Description = "The sephrie are short, wiry, and nimble. Their willowy build and clever dexterity makes them expert survivalists and hunters in their woodland homes." +
                        " @ @ Those same traits make them excellent burglars and thieves. Indeed, many treat the Sephrie with no small measure of distrust. Despite this, their dry wits and glib tongues help them overcome prejudice and quickly befriend the formerly mistrustful. ";

        public static readonly List<string> Race_Description_lHighlightedWords = new List<string>()
        {
            "Sephrie",
            "Sephries",
            "Sephrien"
        };
    }
}
