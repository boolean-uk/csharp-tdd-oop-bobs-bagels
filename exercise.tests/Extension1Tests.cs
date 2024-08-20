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
            [Test]
            
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

            
        }
    }
}