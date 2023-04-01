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
        public void Test1()
        {
            //testArray = new int[] { 1, 2, 3 };
            //FillTestArray(0);

            Assert.Positive(testArray[1]);
            Assert.NotNull(testArray);
        }

        [Test]
        public void Test2()
        {
            //testArray = new int[] { 1, 2, 3 };
            //FillTestArray(2);

            Assert.GreaterOrEqual(testArray.Length, 3);
        }

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