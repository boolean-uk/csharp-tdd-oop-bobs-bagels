using exercise.main;
using NUnit.Framework;
using System.ComponentModel;
using tdd_bobs_bagels.CSharp.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    public class Tests
    {
        [TestFixture]
        public class BasketTests
        {
            [Test]
            // Test for story 1
            public void Test1()
            {
                //arrange 
                Basket basket = new Basket();
                Bagel bagel = new Bagel("Onion");


                //act
                basket.Add(bagel);

                //assert
                Assert.That(basket.Items, Does.Contain(bagel));
            }

            [TestCase("onion")]
            // Test for story 2
            public void Test2(string type)
            {
                //arrange 
                Basket basket = new Basket();
                Bagel bagelName = new Bagel(type);
                basket.Add(bagelName);

                //act
                basket.Remove(bagelName);

                //assert
                Assert.That(basket.Items, Does.Not.Contain(bagelName));
            }
            [TestCase("sesame", "Onion", "Plain")]
            // Test for story 3
            public void Test3(string filling1, string filling2, string filling3)
            {
                //arrange 
                Basket basket = new Basket();
                Bagel bagel1 = new(filling1);
                Bagel bagel2 = new(filling2);
                Bagel bagel3 = new(filling3);
                Bagel bagel4 = new(filling3);
                Bagel bagel5 = new(filling3);
                Bagel bagel6 = new(filling3);




                //act
                basket.Add(bagel1);
                basket.Add(bagel2);
                basket.Add(bagel3);
                basket.Add(bagel4);
                basket.Add(bagel5);
                bool result = basket.Add(bagel6);

                //assert
                Assert.IsFalse(result);
            }

            [TestCase(100)]
            // Test for story 4
            public void Test4(int capacity)
            {
                //arrange 
                Basket basket = new Basket();


                //act
                basket.ChangeCapacity(100);

                int resultingCapacity = basket.Capacity;

                //assert
                Assert.IsTrue(resultingCapacity == capacity);
            }

            [TestCase("onion")]
            public void Test5(string bagelName)
            {
                //arrange 
                Basket basket = new Basket();
                Bagel bagel = new(bagelName);


                //act
                bool returnResult = basket.Remove(bagel);


                //assert
                Assert.IsTrue(returnResult == false);
            }

            [TestCase("onion")]
            public void BagelFlavorAssignTest(string expectedFlavour)
            {
                //arrange
                Bagel bagel = new Bagel("Onion");

                //act
                string bagelWithFlavor = bagel.CurrentFlavor;


                //assert
                Assert.IsTrue(bagelWithFlavor == expectedFlavour);

            }

            [Test]
            public void BagelTest1()
            {
                //arrange

                //act
                Bagel bagel = new Bagel("NonExsistant");



                //assert
                Assert.IsTrue(bagel.CurrentFlavor == "plain");

            }
            [TestCase(1.37f)]
            public void TotalTest(float expected)
            {
                //init
                Basket basket = new Basket();

                List<Bagel> bagels = new List<Bagel>()
                {
                    new Bagel("Onion"),
                    new Bagel("Plain"),
                    new Bagel("Sesame")
                };

                foreach (Bagel bagel in bagels)
                {
                    basket.Add(bagel);
                }

                //run
                float resulted = basket.Total();

                //assert
                Assert.IsTrue(expected == resulted);
            }
            [Test]
            public void GetPriceTest()
            {
                //init
                Bagel bagel = new("onion");
                float expected = 0.49f;

                //run
                float computed = bagel.GetPrice();

                //assert
                Assert.IsTrue(expected == computed);
            }
            [Test]
            public void fillingTest()
            {
                //init
                Bagel bagel = new("onion");
                float priceBefore = bagel.GetPrice();

                //run
                bagel.AddFilling("Bacon");
                float priceAfter = bagel.GetPrice();
                //assert

                Assert.GreaterOrEqual(priceAfter, priceBefore);

            }
            [Test]
            public void GetPriceFillingTest()
            {
                //init
                Filling filling = new Filling("Smoked Salmon");
                float expectedFillingPrice = 0.12f;


                //run
                float computedFillingPrice = filling.Price;


                //assert
                Assert.IsTrue(computedFillingPrice == expectedFillingPrice);
            }
            [Test]
            public void OrderOtherThingsTest()
            {
                //init

                //run
                Bagel bagel = new("white");

                //assert
                Assert.IsTrue(bagel.FalseOrder);
            }
        }
    }
}