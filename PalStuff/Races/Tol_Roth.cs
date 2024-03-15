using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Tol_Roth:Race
    {
        public Tol_Roth()
        {
            Initialize_Race();
        }


        protected override void Initialize_Race()
        {
            base.Initialize_Race();

            RacialName = RaceName.Tol_Roth;
            Name_Singular = "Tol'Roth";
            Name_Singular_A_An = "a";
            Name_Plural = "Tol'Roth";
            Name_Adjective = "Tol'Roth";

            description = Race_Description;
            description_lHighlightedWords = Race_Description_lHighlightedWords;
        }

        public static readonly string Race_Description = "The Tol'Roth are said to be the first humans, and can be distinguished by their height and size. Almost all Tol'Roth are at least 6' tall, with many towering over 7' tall." +
                            "They are typically a dusky tan with black flowing hair and dark green or brown eyes. @ @ The Tol'Roth maintain a zealous culture of personal honor. " +
                            "They do not suffer insults and their size and ferocity makes them some of the fiercest warriors in the empire.";
        

        //********** Add rare races later?
        public static readonly List<string> Race_Description_lHighlightedWords = new List<string>()
        {
            "Tol'Roth"
        };
    }
}
