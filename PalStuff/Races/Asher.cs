using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Asher:Race
    {
        public Asher()
        {
            Initialize_Race();
        }


        protected override void Initialize_Race()
        {
            base.Initialize_Race();

            RacialName = RaceName.Asher;
            Name_Singular = "Asher";
            Name_Singular_A_An = "an";
            Name_Plural = "Ashers";
            Name_Adjective = "Ashen";

            description = Race_Description;
            description_lHighlightedWords = Race_Description_lHighlightedWords;
        }

        public static readonly string Race_Description = "The Asher people have skin tones composed of mottled grays and blacks, like the colors of charcoal ash. Their coarse hair is a shifting mix of stark whites, coal blacks, and flecked grays. @ @ " +
                            "Most Ashers live in their terraced towns situated high in the mountains. Any with Asher blood may enter or leave at will. However, that right is rarely exercised. " +
                            "Ashen society is deeply stratified and ritualistic, and most native Ashers see the world outside of their mountain havens as a profane and lawless place, while Ashen-blooded outsiders view Ashen Society as overly rigid and zealous." +
                            " @ @ The few native Ashers who do make their way out into common society are highly sought after as master crafters and artisans.";

        public static readonly List<string> Race_Description_lHighlightedWords = new List<string>()
        {
            "Asher",
            "Ashers",
            "Ashen"
        };
    }
}
