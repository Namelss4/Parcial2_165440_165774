using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombatPrototype
{
    internal class Equipment
    {
        private string name = String.Empty;

        public Equipment(string name, uint power, uint durability)
        {
            Name = name;
            Power = power;
            Durability = durability;
        }

        public enum EClass
        {
            Human,
            Beast,
            Hybrid,
            Any
        }

        public uint Power { get; set; }
        public uint Durability { get; set; }

        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(name))
                {
                    return "NoName";
                }

                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    name = "NN";
                }
                else
                {
                    name = value;
                }

            }
        }


        public virtual void DecreaseDurability()
        {
        }

        public virtual void DecreaseDurability(Character chara)
        {
        }

    }
}
