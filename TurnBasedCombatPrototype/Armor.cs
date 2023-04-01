using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombatPrototype
{
    internal class Armor : Equipment
    {
        public Armor(string name, uint power, uint durability) : base(name, power, durability)
        {
        }

        public override void DecreaseDurability(Character chara)
        {
            
        }
    }
}
