using NUnit.Framework;
using tdd_oop_bobs_bagels.CSharp.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BobsBagelsExtensionTests
    {
        // add a specific type of coffee to my basket
        [TestCase("Black")]
        [TestCase("White")]
        [TestCase("Capuccino")]
        [TestCase("Latte")]
        public void AddACoffeeToBasketTest(string coffeeType)
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            // act
            bool result = basket.AddCoffee(coffeeType);
            // assert
            Assert.IsTrue(result);
        }

        // 10. only be able to order things that we stock in our inventory
        [Test]
        public void DontAddANonExistingCoffeeTypeToBasketTest()
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            // act
            bool result = basket.AddCoffee("Ristretto");
            // assert
            Assert.IsFalse(result);
        }

        // add a specific type of filling to my basket
        [TestCase("Bacon")]
        [TestCase("Egg")]
        [TestCase("Cheese")]
        [TestCase("Cream Cheese")]
        [TestCase("Smoked Salmon")]
        [TestCase("Ham")]
        public void AddAFillingToBasketTest(string fillingType)
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            // act
            bool result = basket.AddFilling(fillingType);
            // assert
            Assert.IsTrue(result);
        }

        // 10. only be able to order things that we stock in our inventory
        [Test]
        public void DontAddANonExistingFillingTypeToBasketTest()
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            // act
            bool result = basket.AddFilling("Tomato");
            // assert
            Assert.IsFalse(result);
        }

        // remove a coffee from my basket
        [Test]
        public void RemoveACoffeeFromBasketTest()
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            basket.AddBagel("Plain");
            basket.AddCoffee("Capuccino");
            basket.AddBagel("Everything");
            // act
            bool result = basket.RemoveCoffee("Capuccino");
            // assert
            Assert.IsTrue(result);
            Assert.IsTrue(basket.ItemsInBasket == 2);
        }

        // 10. only be able to order things that we stock in our inventory
        [Test]
        public void DontRemoveANonExistingCoffeeTypeFromBasketTest()
        {
            // arrange
            BobsBagelsApp basket = new BobsBagelsApp();
            basket.AddBagel("Plain");
            basket.AddCoffee("Capuccino");
            basket.AddBagel("Everything");
            // act
            bool result = basket.RemoveCoffee("Black");
            // assert
            Assert.IsFalse(result);
        }

    }
}