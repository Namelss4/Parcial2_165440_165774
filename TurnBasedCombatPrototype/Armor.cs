using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombatPrototype
{
    internal class Armor : Equipment
    {
        public Armor(string name, int power, int durability, EClass classType) : base(name, power, durability, classType)
        {
        }

        public override void DecreaseDurability(Character chara)
        {
            //uint temp = chara.Atk / 2;

            if((chara.Atk / 2) == 0)
            {
                Durability--;
            }
            else
            {
                Durability -= chara.Atk / 2;
            }

        }
    }
}
