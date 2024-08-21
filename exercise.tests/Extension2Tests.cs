using exercise.main;
using NUnit.Framework;
using System.ComponentModel;
using tdd_bobs_bagels.CSharp.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    public class Tests3
    {
        [TestFixture]
        public class Extension2Tests
        {
            [Test]
            public void ReceiptTest()
            {
                
                //arrange
                Basket basket = new();
                Bagel bagel = new("onion");
                bagel.AddFilling("egg");
                Coffee coffee = new("White");
                basket.Add(bagel);
                basket.Add(coffee);

                //act
                string receipt = basket.PrintReciept();

                //assert
                Assert.IsTrue(receipt.Contains("white"));

            }
        }
    }
    
}