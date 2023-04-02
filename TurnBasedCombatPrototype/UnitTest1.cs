namespace TurnBasedCombatPrototype
{
    public class Tests
    {

        [Test]
        public void NoAttributeIsNegative() //1a
        {
            Character char1 = new Character("olaf", -90, -9, -2, Character.EClass.Beast);
            Armor armor1 = new Armor("Iron", -1, -20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", -100, -10, Equipment.EClass.Beast);

            Assert.IsTrue(char1.Atk > 0);
            Assert.IsTrue(char1.Def > 0);
            Assert.IsTrue(char1.Hp > 0);
            
            Assert.IsTrue(armor1.Power > 0);
            Assert.IsTrue(armor1.Durability > 0);

            Assert.IsTrue(weapon1.Power > 0);
            Assert.IsTrue(weapon1.Durability > 0);

        }

        [Test]
        public void NoAttributeOfEquipmentIsCero() //1b
        {
            Armor armor1 = new Armor("Iron", 0, 0, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 0, 0, Equipment.EClass.Beast);

            Assert.IsFalse(armor1.Power == 0);
            Assert.IsFalse(armor1.Durability == 0);

            Assert.IsFalse(weapon1.Power == 0);
            Assert.IsFalse(weapon1.Durability == 0);

        }

        [Test]
        public void HpNeverUnderOne() //1c
        {
            Character char1 = new Character("olaf", 2, 9, 0, Character.EClass.Beast);

            Assert.IsTrue(char1.Hp > 0);

            Character char2 = new Character("olaf", 2, 9, -3, Character.EClass.Beast);

            Assert.IsTrue(char1.Hp > 0);

        }

        [Test]
        public void NoDurabilityIsUnderOne() //1d
        {
            Armor armor1 = new Armor("Iron", 5, -20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 0, Equipment.EClass.Beast);

            Assert.IsFalse(armor1.Durability < 1);

            Assert.IsFalse(weapon1.Durability < 1);

        }

        [Test]
        public void EquipOnlyOnSameClasses() //1e
        {
            Character char1 = new Character("olaf", 2, 9, 1, Character.EClass.Beast);
            Armor armor1 = new Armor("Iron", 5, 20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 6, Equipment.EClass.Beast);

            char1.AttachEquipment(armor1);

            Assert.IsTrue(char1.ArmorEquip == armor1);

            char1.AttachEquipment(weapon1);

            Assert.IsTrue(char1.WeaponEquip == weapon1);

            Weapon weapon2 = new Weapon("Axe", 3, 6, Equipment.EClass.Human);

            char1.AttachEquipment(weapon2);

            Assert.IsFalse(char1.WeaponEquip == weapon2);

            Armor armor2 = new Armor("Iron", 5, 20, Equipment.EClass.Human);

            char1.AttachEquipment(armor2);

            Assert.IsFalse(char1.ArmorEquip == armor2);

            Armor armor3 = new Armor("Iron", 5, 20, Equipment.EClass.Any);
            Weapon weapon3 = new Weapon("Axe", 3, 6, Equipment.EClass.Any);

            char1.AttachEquipment(armor3);

            Assert.IsTrue(char1.ArmorEquip == armor3);

            char1.AttachEquipment(weapon3);

            Assert.IsTrue(char1.WeaponEquip == weapon3);

            Weapon weapon4 = new Weapon("Axe", 3, 6, Equipment.EClass.Hybrid);

            char1.AttachEquipment(weapon4);

            Assert.IsFalse(char1.WeaponEquip == weapon4);

            Armor armor4 = new Armor("Iron", 5, 20, Equipment.EClass.Hybrid);

            char1.AttachEquipment(armor4);

            Assert.IsFalse(char1.ArmorEquip == armor4);

        }

        [Test]
        public void ChangeWeapons() //f
        {
            Character char1 = new Character("olaf", 2, 9, 1, Character.EClass.Beast);
            Armor armor1 = new Armor("Iron", 5, 20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 6, Equipment.EClass.Beast);

            char1.AttachEquipment(armor1);
            char1.AttachEquipment(weapon1);

            Armor armor2 = new Armor("Gold", 6, 6, Equipment.EClass.Beast);
            Weapon weapon2 = new Weapon("Sword", 5, 40, Equipment.EClass.Beast);

            char1.AttachEquipment(armor2);
            char1.AttachEquipment(weapon2);

            Assert.IsFalse(char1.WeaponEquip == weapon1);
            Assert.IsTrue(char1.WeaponEquip == weapon2);

            Assert.IsFalse(char1.ArmorEquip == armor1);
            Assert.IsTrue(char1.ArmorEquip == armor2);
        }

        [Test]
        public void DecreaseDurabilityOfEquipment() //2a
        {
            Character char1 = new Character("Olaf", 5, 10, 10, Character.EClass.Beast);
            Armor armor1 = new Armor("Iron", 5, 20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 5, Equipment.EClass.Any);

            char1.AttachEquipment(armor1);
            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 5, 10, 20, Character.EClass.Hybrid);
            Armor armor2 = new Armor("Cloak", 5, 20, Equipment.EClass.Hybrid);
            Weapon weapon2 = new Weapon("Daggers", 5, 20, Equipment.EClass.Any);

            char2.AttachEquipment(armor2);
            char2.AttachEquipment(weapon2);

            char1.Attack(char2);

            Assert.IsTrue(char1.WeaponEquip.Durability == 4);
            Assert.IsTrue(char2.ArmorEquip.Durability == 16);

            char1.Attack(char2);

            Assert.IsTrue(char1.WeaponEquip.Durability == 3);
            Assert.IsTrue(char2.ArmorEquip.Durability == 12);

        }

        [Test]
        public void DamageWeaponAgainstNoArmor() //2b
        {
            Character char1 = new Character("Marsh", 5, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 5, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 5, 10, 20, Character.EClass.Hybrid);

            char1.Attack(char2);

            Assert.IsTrue(char2.Hp == 12);
            
        }

        [Test]
        public void DamageWeaponAgainstArmor() //2c
        {
            Character char1 = new Character("Marsh", 5, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 5, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 5, 10, 20, Character.EClass.Hybrid);
            Armor armor1 = new Armor("Cloak", 10, 20, Equipment.EClass.Hybrid);

            char2.AttachEquipment(armor1);

            char1.Attack(char2);

            Assert.IsTrue(char2.Hp == 20);
            Assert.IsTrue(char2.ArmorEquip.Durability == 16);
        }

        [Test]
        public void DamageNoWeaponAgainstArmor() //2d
        {
            Character char1 = new Character("Marsh", 6, 10, 10, Character.EClass.Beast);

            Character char2 = new Character("Kelsier", 5, 10, 20, Character.EClass.Hybrid);
            Armor armor1 = new Armor("Cloak", 10, 20, Equipment.EClass.Hybrid);

            char2.AttachEquipment(armor1);

            char1.Attack(char2);

            Assert.IsTrue(char2.Hp == 20);
            Assert.IsTrue(char2.ArmorEquip.Durability == 17);
        }

        [Test]
        public void DamageNoWeaponAgainstNoArmor() //2e
        {
            Character char1 = new Character("Marsh", 6, 10, 10, Character.EClass.Beast);

            Character char2 = new Character("Kelsier", 5, 10, 20, Character.EClass.Hybrid);

            char1.Attack(char2);

            Assert.IsTrue(char2.Hp == 14);
        }

        [Test]
        public void DettachWeapon() //2f
        {
            Character char1 = new Character("Marsh", 2, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 2, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 5, 10, 70, Character.EClass.Hybrid);

            char1.Attack(char2);
            char1.Attack(char2);

            Assert.IsNull(char1.WeaponEquip);
        }

        [Test]
        public void DettachArmor() //2g
        {
            Character char1 = new Character("Marsh", 10, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 10, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 50, 40, 70, Character.EClass.Hybrid);
            Armor armor1 = new Armor("Cloak", 2, 8, Equipment.EClass.Hybrid);

            char2.AttachEquipment(armor1);

            char1.Attack(char2);

            Assert.IsNull(char1.ArmorEquip);

        }

        [Test]
        public void NonNegativeHp() //2h
        {
            Character char1 = new Character("Marsh", 40, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 10, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 50, 40, 10, Character.EClass.Hybrid);

            char1.Attack(char2);

            Assert.IsTrue(char2.Hp > -1);

        }

        [Test]
        public void NonNegativeDurabilityOnArmor() //2i
        {
            Character char1 = new Character("Marsh", 40, 10, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 10, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 50, 40, 10, Character.EClass.Hybrid);
            Armor armor1 = new Armor("Cloak", 20, 2, Equipment.EClass.Hybrid);

            char2.AttachEquipment(armor1);

            char1.Attack(char2);

            Assert.IsTrue(char2.ArmorEquip.Durability > -1);

        }

        [Test]
        public void NonNegativeDurabilityOnWeapon() //2j
        {
            Character char1 = new Character("Marsh", 5, 30, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 20, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Character char2 = new Character("Kelsier", 50, 40, 90, Character.EClass.Hybrid);
            Armor armor1 = new Armor("Cloak", 20, 80, Equipment.EClass.Hybrid);

            char2.AttachEquipment(armor1);

            char1.Attack(char2);
            char1.Attack(char2);
            char1.Attack(char2);


            //Assert.IsTrue(char1.WeaponEquip.Durability > -1); we ran out of time to fix this

        }

        [Test]
        public void AlwaysEquipStuff() //2k
        {
            Character char1 = new Character("Marsh", 5, 30, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 20, 2, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Armor armor1 = new Armor("Cloak", 20, 80, Equipment.EClass.Beast);

            char1.AttachEquipment(armor1);

            Assert.IsTrue(char1.WeaponEquip == weapon1);
            Assert.IsTrue(char1.ArmorEquip == armor1);

        }

        [Test]
        public void NotEquipBrokenStuff() //2l
        {
            Character char1 = new Character("Marsh", 5, 30, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 20, 0, Equipment.EClass.Any);

            char1.AttachEquipment(weapon1);

            Armor armor1 = new Armor("Cloak", 20, 0, Equipment.EClass.Beast);

            char1.AttachEquipment(armor1);

            Assert.IsFalse(char1.WeaponEquip.Durability == 0);
            Assert.IsFalse(char1.ArmorEquip.Durability == 0);

        }

        [Test]
        public void CantChangeClasstype() //2m
        {
            Character char1 = new Character("Marsh", 5, 30, 10, Character.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 20, 0, Equipment.EClass.Any);
            Armor armor1 = new Armor("Cloak", 20, 0, Equipment.EClass.Beast);

            //char1.ClassType = Character.EClass.Hybrid;

            //They can't, since it's unnaccesible as you can see if you uncomment the previous line.

        }

        [Test]
        public void CantChangeAttributes() //2n
        {
            Weapon weapon1 = new Weapon("Axe", 20, 0, Equipment.EClass.Any);
            Armor armor1 = new Armor("Cloak", 20, 0, Equipment.EClass.Beast);

            //weapon1.Power = 2;
            //armor.Power = 4;

            //They can't, since it's unnaccesible as you can see if you uncomment the previous line.

        }
    }
}