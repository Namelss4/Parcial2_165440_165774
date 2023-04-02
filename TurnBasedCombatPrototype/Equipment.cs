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
        //private uint durability;

        public enum EClass
        {
            Human,
            Beast,
            Hybrid,
            Any
        }

        public Equipment(string name, int power, int durability, EClass classType)
        {
            Name = name;

            if (Power > 0)
            {
                Power = power;
            }
            else
            {
                Power = 1;
            }

            if (Durability > 0)
            {
                Durability = durability;
            }
            else
            {
                Durability = 1;
            }

            ClassType = classType;
        }

        

        public int Power { get; private set; }
        //public uint Durability { get { return durability; } set { durability = value; } }
        public int Durability { get; internal set; }

        public EClass ClassType { get; private set; }

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
