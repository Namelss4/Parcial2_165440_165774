namespace TurnBasedCombatPrototype
{
    public class Tests
    {
        //public int[] testArray;
        //public int testStep;

        //[SetUp]
        //public void Setup()
        //{
        //    testArray = new int[] { 1, 2, 3 };
        //}

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
            Character char1 = new Character("olaf", 2, 9, 0, Character.EClass.Beast);
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
            Character char1 = new Character("olaf", 2, 9, 0, Character.EClass.Beast);
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

        [TearDown]
        public void TearDown()
        {
           
        }

        //private void FillTestArray(int testStep)
        //{
        //    switch (testStep)
        //    {
        //        case 2:
        //            testArray = new int[] { 1, 2, 3 };
        //            break;

        //        default:
        //            testArray = new int[] { 1, 2, 3 };
        //            break;
        //    }
        //}
    }
}