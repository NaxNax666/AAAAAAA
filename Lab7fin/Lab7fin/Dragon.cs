using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin
{
     class Dragon:Unit
    {
        public Dragon(string name, uint hitPoints, uint attack, uint defence, uint damage,
            double initiative) : base(name, hitPoints, attack, defence, damage, initiative) {
            this.EffectImmunity = true;
        }
        public Dragon Clone()
        {
            Dragon currentUnit = new Dragon(this.Name, this.HitPoints, this.Attack, this.Defence, this.Damage, this.Initiative);
            foreach (var magic in AccessibleMagic)
            {
                currentUnit.accessibleMagic.Add(magic);
            }
            foreach (var effect in CongenitalEffects)
            {
                currentUnit.congenitalEffects.Add(effect);
            }
            return currentUnit;
        }

    }
}
