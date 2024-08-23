using exercise.main;
using NUnit.Framework;
using System.ComponentModel;
using tdd_bobs_bagels.CSharp.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    public class Tests4
    {
        [TestFixture]
        public class Extension3Tests
        {
            [Test]
            public void ReceiptDiscountTest()
            {

                //arrange
                Basket basket = new();
                Bagel bagel = new("onion");
                bagel.AddFilling("egg");
                Coffee coffee = new("White");
                basket.Add(bagel);
                basket.Add(coffee);

                //act
                string expected = basket.TotalAfterDiscount().ToString();


                //assert
                Assert.IsTrue(basket.PrintReceipt().ToString().Contains($"{expected}"));
            }
        }
    }
}