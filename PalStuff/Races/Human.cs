using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Human : Race
    {
        public Human()
        {
            Initialize_Race();
        }


        protected override void Initialize_Race()
        {
            base.Initialize_Race();

            RacialName = RaceName.Human;
            Name_Singular = "Human";
            Name_Singular_A_An = "a";
            Name_Plural = "Humans";
            Name_Adjective = "Human";

            description = Race_Description;
            description_lHighlightedWords = Race_Description_lHighlightedWords;
        }

        public static readonly string Race_Description = "A standard human.";
        public static readonly List<string> Race_Description_lHighlightedWords = new List<string>()
        {
            "Human",
            "Humans"
        };
    }
}

