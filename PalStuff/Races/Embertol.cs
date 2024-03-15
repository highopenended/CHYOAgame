using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Races
{
    public class Embertol:Race
    {
        public Embertol()
        {
            Initialize_Race();
        }


        protected override void Initialize_Race()
        {
            base.Initialize_Race();

            //RacialName = RaceName.Ember_tol;

            Name_Singular = "Ember'tol";
            Name_Plural = "Ember'tolm";
            Name_Adjective = "Ember'Tol";

            description = "The Ember'tol are said to be the first humans, and can be distinguished by their height and size. Most Ember'tol are at least 6', with some towering at nearly 7'. " +
                            "They are typically a dusky tan with black flowing hair and dark green or brown eyes. Though the Ember'tol maintain a culture of peace and zealous loyalty, their size and hidden ferocity makes them some of the fiercest warriors";

        }
    }
}
