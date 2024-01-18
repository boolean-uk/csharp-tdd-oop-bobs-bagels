using exercise.main;

namespace exercise.tests
{
    internal class DiscountTests
    {
        Basket _basket;
        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();
            _basket.ChangeCapacity(100);
        }

        [TestCase(1, 0.49f)]
        [TestCase(6, 2.49f)]
        [TestCase(12, 3.99f)]
        [TestCase(18, 6.48f)]
        [TestCase(13, 4.48f)]
        [TestCase(16, 5.95f)]
        [TestCase(7, 2.98f)]
        public void DiscountBagelTest(int a, float expectedResult)
        {
            for (int i = 0; i < a; i++)
            {
                _basket.AddItem("BGLO");
            }
            Assert.That(_basket.TotalCost(), Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1,  0.88f)]
        [TestCase(0, 6, 2.34f)]
        [TestCase(12, 12, 7.98f)]
        [TestCase(4, 4, 3.52f)]
        [TestCase(6, 12 , 6.48f)]
        [TestCase(13, 5,  6.43f)]
        public void DiscountMultipleBagelTest(int a, int b, float expectedResult)
        {
            for (int i = 0; i < a; i++)
            {
                _basket.AddItem("BGLO");
            }
            for (int i = 0; i < b; i++)
            {
                _basket.AddItem("BGLP");
            }
            Assert.That(_basket.TotalCost(), Is.EqualTo(expectedResult));
        }

        /*
       // [TestCase(1, 1, 1.25f)]
        [TestCase(0, 2, 0.78f)]
        [TestCase(2, 2, 2.50f)]
        [TestCase(1, 2, 1.64f)]
        public void CoffeeAndBagelTest(int coffee, int bagel, float expectedResult)
        {
            for (int i = 0; i < coffee; i++)
            {
                _basket.AddItem("COFB");
            }
            for (int i = 0; i < bagel; i++)
            {
                _basket.AddItem("BGLP");
            }
            Assert.That(_basket.TotalCost(), Is.EqualTo(expectedResult));
        }
        [TestCase(1, 1, 0, 1.25f)]
        [TestCase(1, 0, 1, 1.25f)]
        [TestCase(0, 2, 0, 0.78f)]
        [TestCase(2, 2, 2, 3.48f)]
        [TestCase(1, 2, 2, 2.62f)]
        public void CoffeeAndMultipleBagelTest(int coffee, int bagel, int otherbagel, float expectedResult)
        {
            for (int i = 0; i < coffee; i++)
            {
                _basket.AddItem("COFB");
            }
            for (int i = 0; i < bagel; i++)
            {
                _basket.AddItem("BGLP");
            }
            for (int i = 0; i < otherbagel; i++)
            {
                _basket.AddItem("BGLE");
            }
            Assert.That(_basket.TotalCost(), Is.EqualTo(expectedResult));
        }
        */


    }
}
