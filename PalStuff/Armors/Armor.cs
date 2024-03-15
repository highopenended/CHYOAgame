using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.PalStuff.Armors
{
    public class Armor
    {
        public ArmorClasses ArmorClass { get; }

        public int ArmorLevel { get; }

        public int FlatDamageReduction { get { return ArmorLevel * 3; } }

        public enum ArmorClasses
        {
            None,
            Leather,
            Chain,
            Plate
        }
    }
}

