using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedCombatPrototype
{
    internal class Character
    {
        private string name = String.Empty;

        public Character(string name, uint atk, uint def, uint hp)
        {
            Name = name;
            Atk = atk;
            Def = def;
            Hp = hp;
        }

        public enum EClass
        {
            Human,
            Beast,
            Hybrid
        }

        public uint Atk { get; private set; }
        public uint Def { get; private set; }
        public uint Hp { get; private set; }
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
            private set
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
    }
}
