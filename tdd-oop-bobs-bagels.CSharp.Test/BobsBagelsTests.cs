 using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void AddBagel()
        {
            // arrange

            Basket bagel = new Basket(3);



            // act
            bagel.Items.Add("Cheese");


            // assert
            Assert.IsTrue(1 == bagel.Items.Count);

        }

        [Test]
        public void RemoveBagel()
        {
            // arrange
            Basket bagel = new Basket(3);
            bagel.Items.Add("Cheese");
            bagel.Items.Add("Ham");
            bagel.Items.Add("Peanut Butter");

            // act
            string result = bagel.RemoveBagel("Ham");

            // assert
            Assert.AreEqual(result, "Item removed");

            //// act

            //bagel.RemoveBagel("Ham");

            //// assert
            //Assert.IsTrue(3 == bagel.Items.Count);

        }

        //[Test]
        //public void MaximumBagel()
        //{
        //    // arrange
        //    Basket bagel = new Basket(3);
        //    bagel.Items.Add("Cheese");
        //    bagel.Items.Add("Ham");
        //    bagel.Items.Add("Peanut Butter");

        //    // act
        //    bagel.Items.Add("Mozzarella");
        //    bagel.Items.Add("Mozzarella");
        //    bagel.Items.Add("Mozzarella");


        //    // assert
        //    Assert.IsTrue (bagel.Items.Count <= 3);



        [Test]
        public void MaximumBagelTwo()
        {
            Basket bagel = new Basket(4);
            bagel.AddAnotherBagel("Cheese");
            bagel.AddAnotherBagel("Blood");
            bagel.AddAnotherBagel("Sweat");
            bagel.AddAnotherBagel("Tears");
            //bagel.AddAnotherBagel("Tears");

            bool result = bagel.AddAnotherBagel("Ham");

            Assert.IsFalse(result);

        }

        [Test]
        public void IncreaseMaximumBagel()
        {
            // arrange
            Basket bagel = new Basket(5);
            bagel.AddAnotherBagel("Cheese");
            bagel.AddAnotherBagel("Blood");
            bagel.AddAnotherBagel("Sweat");
            bagel.AddAnotherBagel("Tears");

            bool result = bagel.AddAnotherBagel("Ham");

            Assert.IsTrue(result);

        }

        [Test]
        public void SearchBagels()
        {
            // arange
            Basket bagel = new Basket(3);
            bagel.Items.Add("Cheese");
            bagel.Items.Add("Ham");
            bagel.Items.Add("Peanut Butter");
            bagel.Items.Remove("Bacon");

            // act
            string result = bagel.SearchBagelByName("Bacon");

            // assert
            Assert.AreEqual(result, "Are you insane?!");

        }

        [Test]
        public void CostOfCurrentBasket()
        {
            // arrange
            Basket item = new Basket(5);
            item.AddToBasket("BGLO");
            item.AddToBasket("BGLE");
            item.AddToBasket("BGLS");
            item.AddToBasket("COFC");




            // act
            decimal result = item.CalculateTotalCost();

            // assert

            Assert.AreEqual(result,2.76m );
        }


        [Test]
        public void IndividualBagelCost()
        {
            // arrange
            Invertory prices = new Invertory();


            // act

            decimal result = prices.SKUList.Where(x => x.Key == "COFC").FirstOrDefault().Value;


            // assert

            Assert.IsTrue(1.29m == result);
        }

        [Test]
        public void BagelFillings()
        {
            // arrange

            Basket bagel = new Basket(3);



            // act
            bagel.AddToBasket("BGLP");
            bagel.AddToBasket("FILC");


            // assert
            Assert.IsTrue(2 == bagel.Items.Count);

        }

        [Test]
        public void FillingPrices()
        {
            Invertory invertory = new Invertory();

            decimal result = invertory.GetPrice("FILC");

            Assert.IsTrue (result == 0.12m);
        }

        [Test]
        public void WeirdRequests()
        {
            // arrange
            Basket item = new Basket(5);
           

            // act
            
            item.AddToBasket("ABCD");

            // assert

            Assert.AreEqual(0, item.Items.Count);
        }
    }
}
