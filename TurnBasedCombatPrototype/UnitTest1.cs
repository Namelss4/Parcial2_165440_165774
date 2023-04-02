namespace TurnBasedCombatPrototype
{
    public class Tests
    {
        public int[] testArray;
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
            Armor armor1 = new Armor("Iron", 5, -20, Equipment.EClass.Beast);
            Weapon weapon1 = new Weapon("Axe", 3, 0, Equipment.EClass.Beast);

            char1.AttachEquipment(armor1);

            Weapon weapon2 = new Weapon("Axe", 3, 0, Equipment.EClass.Human);

            Assert.

            

        }

        //[Test]
        //public void Test2()
        //{
        //    testArray = new int[] { 1, 2, 3 };
        //    //FillTestArray(2);

        //    Assert.GreaterOrEqual(testArray.Length, 3);
        //}

        //[Test]
        //public void DecreaseArmorDurability()
        //{
        //    Character chare = new Character("olaf", 1, 2, 3, Character.EClass.Human);

        //    //Armor arm = new Armor("1",1,10,Equipment.EClass.Any);
        //    //arm.Durability = 0;

        //}

        [TearDown]
        public void TearDown()
        {
            testArray = null;
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