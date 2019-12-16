using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin
{
    abstract class Unit
    {
        public string Name { get; }
        public uint HitPoints { get; protected set; }
        public uint Attack { get; }
        public uint Defence { get; set; }
        public uint Damage { get; set; }
        public double Initiative { get; }
        public bool EffectImmunity { get; protected set; }

        protected List<TypeOfMagic> accessibleMagic;

        public List<TypeOfMagic> AccessibleMagic
        {
            get
            {
                var newMagicList = new List<TypeOfMagic>();
                accessibleMagic.ForEach((magic) => newMagicList.Add(magic));
                return newMagicList;
            }
        }

        protected List<TypeOfEffect> congenitalEffects;

        public List<TypeOfEffect> CongenitalEffects
        {
            get
            {
                var newEffectList = new List<TypeOfEffect>();
                congenitalEffects.ForEach((effect) => newEffectList.Add(effect));
                return newEffectList;
            }
        }

        public Unit(string name, uint hitPoints, uint attack, uint defence, uint damage,
            double initiative)
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.Attack = attack;
            this.Defence = defence;
            this.Damage = damage;
            this.Initiative = initiative;
            accessibleMagic = new List<TypeOfMagic>();
            congenitalEffects = new List<TypeOfEffect>();
        }

        
    }
}
