using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin 
{
    class BoneDragon : Dragon, ICall
    {
        public BoneDragon() : base("BoneDragon", 150, 27, 28, damage: 30, 11) { }
        public string Roar()
        {
            return " Аниме!";
        }
    }
}
