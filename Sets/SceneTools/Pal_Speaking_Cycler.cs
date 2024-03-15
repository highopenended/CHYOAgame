using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets.SceneTools
{
    public class Pal_Speaking_Cycler
    {

        public Pal_Speaking_Cycler(PalStuff.Pal speakingPal)
        {
            SpeakingPal = speakingPal;
        }
        readonly PalStuff.Pal SpeakingPal;       
    }
}
