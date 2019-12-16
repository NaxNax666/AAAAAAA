using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin
{
    class Skeleton:Unit,ICall,IPowerUp
    {
        public Skeleton() : base("Skeleton", 5, 1, 2, 2, 10) { }
        public string Roar()
        {
            return " За донбасс!";
        }
        public void NiBBa()
        {
            this.HitPoints *= 2;
        }
    }
}
