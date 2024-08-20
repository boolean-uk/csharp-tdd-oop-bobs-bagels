using exercise.main;
using NUnit.Framework;
using System.ComponentModel;
using tdd_bobs_bagels.CSharp.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    public class Extension1Tests
    {
        [TestFixture]
        public class ExtensionTests
        {
          [TestCase("sesame", "Onion", "Plain","Black","White")]
            // Test for story 3
            public void PreExtensionTest(string filling1, string filling2, string filling3, string type, string type1)
            {
                //arrange 
                Basket basket = new Basket();
                Bagel bagel1 = new(filling1);
                Bagel bagel2 = new(filling2);
                Bagel bagel3 = new(filling3);
                Bagel bagel4 = new(filling3);
                Coffee coffee1 = new(type);
                Coffee coffee2 = new(type1);
                basket.ChangeCapacity(10);
                basket.Add(bagel1);
                basket.Add(bagel2);
                basket.Add(bagel3);
                basket.Add(bagel4);
                basket.Add(coffee1);
                basket.Add(coffee2);
                float expectedTotal = 3.94f;
                //act
                float actualTotal = basket.Total();

                //assert
                Assert.That(actualTotal, Is.EqualTo(expectedTotal));
            }
            [Test]
            public void DiscountTest()
            {
                //arrange
                Basket basket = new();
                List<Bagel> bagelList = new();
                for (int i = 0; i < 6; i++)
                {
                    Bagel bagel = new("onion");
                    bagelList.Add(bagel);
                };
                Coffee coffee = new("White");
                float expectedTotal = 3.68f;

                //act
               

                foreach (Bagel bagel in bagelList)
                {
                    basket.Add(bagel);
                }

                basket.Add(coffee);
                basket.Discount();
                float actualTotal = basket.Total();
                //assert
                Assert.That(actualTotal, Is.EqualTo(expectedTotal));
            }
            [Test]
            public void DiscountTest1()
            {
                //arrange
                Basket basket = new();
                List<Bagel> bagelList = new();
                for (int i = 0; i < 7; i++)
                {
                    Bagel bagel = new("onion");
                    bagelList.Add(bagel);
                };
                Coffee coffee = new("White");
                float expectedTotal = 3.94f;

                //act


                foreach (Bagel bagel in bagelList)
                {
                    basket.Add(bagel);
                }

                basket.Add(coffee);
                basket.Discount();
                float actualTotal = basket.Total();
                //assert
                Assert.That(actualTotal, Is.EqualTo(expectedTotal));
            }
        }
    }
}