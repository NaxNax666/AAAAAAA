using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7fin
{
    class Army
    {
        public string ArmyName { get; }
        public uint BDcount{ get; set;}
        public uint GDcount { get; set; }
        public uint Scount { get; set; }
        private BoneDragon Alesha { get; }
        private GhostDragon Lexa { get; }
        private Skeleton Rabotyaga { get; }


        public Army(string Name, uint BD, uint GD, uint S)
        {
            this.BDcount = BD;
            this.GDcount = GD;
            this.Scount = S;
            this.ArmyName = Name;
            this.Alesha = new BoneDragon();
            this.Lexa = new GhostDragon();
            this.Rabotyaga = new Skeleton();
        }
        

        public Army Clone()
        {
            return new Army(this.ArmyName ,this.BDcount, this.GDcount, this.Scount);
        }
        public bool IsArmyAlive()
        {
            if (this.BDcount!=0|| this.GDcount !=0|| this.Scount !=0)
                return true;
            else
                return false;
        }
        private uint AliveStacks(int i)
        {
            uint result = 0;
            switch (i)
            {

                case 0:
                    result = BDcount;
                    break;
                case 1:
                    result = GDcount;
                    break;
                case 2:
                    result = Scount;
                    break;
            }
            return result;
        }
        private uint StackDamage(int i)
        {
            uint result = this.AliveStacks(i);
            switch (i)
            {
                case 0:
                    result *= Alesha.Damage;
                    break;
                case 1:
                    result *= Lexa.Damage;
                    break;
                case 2:
                    result *= Rabotyaga.Damage;
                    break;
            }

            return result;
        }
        private uint StackHp(int i)
        {
            uint result = AliveStacks(i);
            switch (i)
            {
                case 0:
                    result *= Alesha.HitPoints;
                    break;
                case 1:
                    result *= Lexa.HitPoints;
                    break;
                case 2:
                    result *= Rabotyaga.HitPoints;
                    break;
            }
            return result;
        }
        public void GetDamage(int i, int j, Army Attacker)
        {
            uint Damage = Attacker.StackDamage(j);
            uint HP = StackHp(i);
            if (Damage >= HP)
            {
                switch (i)
                {
                    case 0:
                        this.BDcount = 0;
                        break;
                    case 1:
                        this.GDcount = 0;
                        break;
                    case 2:
                        this.Scount = 0;
                        break;
                }
            }
            else
            {
                uint alive = HP - Damage;
                switch (i)
                {
                    case 0:
                        this.BDcount = alive / Alesha.HitPoints;
                        break;
                    case 1:
                        this.GDcount = alive / Lexa.HitPoints;
                        break;
                    case 2:
                        this.Scount = alive /  Rabotyaga.HitPoints;
                        break;
                }

            }
        }
        public string Attack (int i)
        {
            string result="Атакует "+this.ArmyName+"\r\n";
            switch (i)
            {
                case 0:
                    result = "Костяные Драконы атакуют крича" + Alesha.Roar();
                    break;
                case 1:
                    result = "Призрачные драконы молча атакуют";
                    break;
                case 2:
                    result = "Скелеты атакуют крича" + Rabotyaga.Roar();
                    break;
            }
            return result;
        }
        public void Defence(int i)
        {
            switch(i)
            {
                case 0:
                    this.Alesha.Defence += 10;
                break;
                case 1:
                    this.Lexa.Defence += 20;
                break;
                case 2:
                    this.Rabotyaga.NiBBa();
                break;
            }
        }
        public void GetCast(int i, int j, Army Attacker, TypeOfMagic Cast)
        {
            if (j != 1)
            {
                return;
            }
            else
            {
                switch (Cast)
                {
                    case TypeOfMagic.Attenuation:
                        this.Rabotyaga.Damage -= 1;
                        break;
                    case TypeOfMagic.Curse:
                        this.Rabotyaga.Defence -= 5; 
                        break;
                    case TypeOfMagic.PunishingStrike:
                        switch (i)
                        {
                            case 0:
                                BDcount -= 5;
                                break;
                            case 1:
                                GDcount -= 1;
                                break;
                            case 2:
                                Scount -= 15;
                                break;
                        }
                        break;
                }
            }
        }

    }
}
