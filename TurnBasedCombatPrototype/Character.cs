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
        private Armor armorEquip = null;
        private Weapon weaponEquip = null;


        public enum EClass
        {
            Human,
            Beast,
            Hybrid
        }

        public Character(string name, int atk, int def, int hp, EClass classType)
        {
            Name = name;
            if(atk > 1)
            {
                Atk = atk;
            }
            else
            {
                Atk = 1;
            }

            if (def > 1)
            {
                Def = def;
            }
            else
            {
                Def = 1;
            }

            if (hp > 1)
            {
                Hp = hp;
            }
            else
            {
                Hp = 1;
            }

            ClassType = classType;

            weaponEquip = null;

            armorEquip = null;

        }

        

        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Hp { get ; private set; }
        public Armor ArmorEquip { get => armorEquip; set =>  armorEquip = ArmorEquip; }
        public Weapon WeaponEquip { get => weaponEquip; set => weaponEquip = WeaponEquip; }
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

        public void AttachEquipment(Equipment eq)
        {
            if(eq is Armor)
            {
                
                if(eq.ClassType.ToString() == ClassType.ToString() || eq.ClassType == Equipment.EClass.Any)
                {

                    armorEquip = (Armor)eq;

                    Def = Def + eq.Power;

                    //if (armor1 == null)
                    //{
                    //    armor1 = (Armor)eq;
                    //}
                    //else
                    //{
                    //    armor1 = null;
                    //    armor1 = (Armor)eq;
                    //}

                } 
            }
            else if(eq is Weapon)
            {
                if (eq.ClassType.ToString() == ClassType.ToString() || eq.ClassType == Equipment.EClass.Any)
                {
                    weaponEquip = (Weapon)eq;

                    Atk = Atk + eq.Power;
                }               
            }
        }

        public void Attack(Character enemy) //We read the prompt over and over again and there's no mention on how to use the Def stat, it says the damage goes directly to the hp of the enemy or the durability of its armor.
        {
            if(weaponEquip == null)
            {
                if(enemy.armorEquip == null)
                {
                    if (enemy.Hp - this.Atk < 0)
                    {
                        enemy.Hp = 0;
                    }
                    else
                    {
                        enemy.Hp = enemy.Hp - this.Atk;
                    }
                }
                else
                {
                    if (enemy.ArmorEquip.Durability > 0)
                    {
                        enemy.ArmorEquip.DecreaseDurability(this.Atk);

                        //if (enemy.ArmorEquip.Durability < 1)
                        //{
                        //    this.Def = this.Def - armorEquip.Power;
                        //    enemy.armorEquip = null;
                        //}
                    }
                    else
                    {
                        this.Def = this.Def - armorEquip.Power;
                        enemy.ArmorEquip = null;
                    }
                }
            }
            else
            {
                if(enemy.armorEquip == null)
                {
                    if(enemy.Hp - this.Atk < 0)
                    {
                        enemy.Hp = 0;
                    }
                    else
                    {
                        enemy.Hp = enemy.Hp - this.Atk;
                    }     
                }
                else
                {
                    if (enemy.ArmorEquip.Durability > 0)
                    {
                        enemy.ArmorEquip.DecreaseDurability(this.Atk);

                        //if (enemy.ArmorEquip.Durability < 1)
                        //{
                        //    this.Def = this.Def - armorEquip.Power;
                        //    enemy.armorEquip = null;
                        //}
                    }
                    else
                    {
                        this.Def = this.Def - armorEquip.Power;
                        enemy.armorEquip = null;
                    }                  
                }

                if (this.weaponEquip.Durability > 0)
                {
                    this.weaponEquip.Durability = this.weaponEquip.Durability - 1;

                    if(this.weaponEquip.Durability < 1)
                    {
                        this.Atk = this.Atk - weaponEquip.Power;
                        this.weaponEquip = null;
                    }
                }
                else
                {
                    this.Atk = this.Atk - weaponEquip.Power;
                    this.weaponEquip = null;
                }    
            }
        }
    }
}
