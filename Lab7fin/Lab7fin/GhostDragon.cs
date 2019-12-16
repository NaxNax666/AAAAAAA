using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin
{
    class GhostDragon : Dragon
    {
        public GhostDragon() : base("GhostDragon", 150, 27, 100, damage: 60, 11) {
            this.accessibleMagic.Add(TypeOfMagic.Attenuation);
            this.accessibleMagic.Add(TypeOfMagic.Curse);
            this.accessibleMagic.Add(TypeOfMagic.PunishingStrike);
        }
    }
}
