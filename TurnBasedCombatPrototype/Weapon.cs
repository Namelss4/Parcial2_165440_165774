using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombatPrototype
{
    internal class Weapon : Equipment

    {
        public Weapon(string name, int power, int durability, EClass classType) : base(name, power, durability, classType)
        {
        }

        public override void DecreaseDurability()
        {
            if(Durability-- < 1)
            {
                Durability = 0;
            }
            else
            {
                Durability--;
            }
                    
        }
    }
}
