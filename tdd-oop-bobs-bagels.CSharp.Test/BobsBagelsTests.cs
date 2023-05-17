using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_tdd_oop_bobs_bagels.Source;
using NUnit.Framework;
using static System.Formats.Asn1.AsnWriter;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    public class BobsBagelsTests
    {
        [Test]
        public void SelectRole()
        {
            // I'd like to select a role (member of the public, customer or manager)

            // arrange
            Main main = new Main();

            string role = "member";

            // act
            main.SelectRole(role);

            // assert
            Assert.AreEqual(main.SelectRole(role), "member");
        }

        [Test]
        public void AddItemToBasket()
        {
            // I'd like to add a specific type of bagel to my basket.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, 3);

            string bagel = main.Products[rInt].SKU;

            string role = "member";
            main.SelectRole(role);

            // act
            main.AddItem(bagel);

            // assert
            Assert.AreEqual(main.Basket.First().SKU, main.Products[rInt].SKU);
        }

        [Test]
        public void RemoveItemFromBasket()
        {
            // I'd like to remove a bagel from my basket.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, 3);

            string bagel = main.Products[rInt].SKU;

            string role = "member";
            main.SelectRole(role);

            main.AddItem(bagel);

            Assert.AreEqual(bagel, main.Products[rInt].SKU);

            int length = main.Basket.Count;

            // act
            main.RemoveItem(bagel);

            // assert
            Assert.AreEqual(main.Basket.Count, length - 1);
        }

        [Test]
        public void FullBasket()
        {
            // I'd like to know when my basket is full when I try adding an item beyond my basket capacity.

            // arrange
            Main main = new Main();
            main.SeedData();

            string role = "member";
            main.SelectRole(role);

            string bagel = main.Products[0].SKU;
            string bagel1 = main.Products[1].SKU;
            string bagel2 = main.Products[2].SKU;
            string bagel3 = main.Products[3].SKU;

            // act
            main.AddItem(bagel);
            main.AddItem(bagel1);
            main.AddItem(bagel2);
            main.AddItem(bagel3);

            // assert
            Assert.AreEqual(3, main.Basket.Count);
            /*Assert.IsTrue(main.Bagels.Contains(item2));*/
        }

        [Test]
        public void ChangeBasketMax()
        {
            // I’d like to change the capacity of baskets.

            // arrange
            Main main = new Main();
            main.SeedData();

            string role = "manager";
            main.SelectRole(role);

            int max = 2;

            string bagel = main.Products[0].SKU;
            string bagel1 = main.Products[1].SKU;
            string bagel2 = main.Products[2].SKU;
            string bagel3 = main.Products[3].SKU;

            // act
            main.ChangeBasketMax(max);

            main.AddItem(bagel);
            main.AddItem(bagel1);
            main.AddItem(bagel2);
            main.AddItem(bagel3);

            // assert
            Assert.LessOrEqual(main.Basket.Count, max);
            Assert.IsTrue(main.Basket.Contains(main.Products[1]));
        }

        [Test]
        public void ItemInBasket()
        {
            // I'd like to know if I try to remove an item that doesn't exist in my basket.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, main.Products.Count);

            string item = main.Products[rInt].SKU;

            int length = 0;

            // act
            main.RemoveItem(item);

            // assert
            Assert.AreEqual(main.Basket.Count, length);
        }

        [Test]
        public void TotalCostBasket()
        {
            // I'd like to know the total cost of items in my basket.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, main.Products.Count);
            int rInt1 = r.Next(0, main.Products.Count);

            string item = main.Products[rInt].SKU;
            string item1 = main.Products[rInt1].SKU;

            string role = "customer";
            main.SelectRole(role);

            main.AddItem(item);
            main.AddItem(item1);

            // act
            main.TotalCostBasket();

            // assert
            Assert.AreEqual(main.Products[rInt].Price + main.Products[rInt1].Price, main.total);
        }

        [Test]
        public void ItemCost()
        {
            // I'd like to know the total cost of items in my basket.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, main.Products.Count);

            string item = main.Products[rInt].SKU;

            string role = "customer";
            main.SelectRole(role);

            // act
            main.ItemCost(item);

            // assert
            Assert.AreEqual(main.Products[rInt].Price, main.cost);
        }

        /*[Test]
        public void AddFillingToBagel()
        {
            // I'd like to be able to choose fillings for my bagel.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(0, 3);
            int rIntF = r.Next(8, 13);

            IItem bagel = main.Products[rInt];
            IItem filling = main.Products[rIntF];

            // act
            bagel.AddExtras(filling);

            // assert
            Assert.AreEqual(bagel.Extras.First().Variant, main.Products[rIntF].Variant);
        }*/

        [Test]
        public void IsStocked()
        {
            // I want customers to only be able to order things that we stock in our inventory.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(4, main.Products.Count);

            string item = main.Products[rInt].SKU;

            string role = "customer";
            main.SelectRole(role);

            int stock = main.Products[rInt].Stock;

            // act
            main.AddItem(item);
            main.AddItem(item);
            main.AddItem(item);

            // assert
            Assert.AreEqual(stock, main.Basket.Count);
        }

        [Test]
        public void OfferDeal()
        {
            // I want to offer my customers the deal 6 for 2,49 or 12 for 3,99.

            // arrange
            Main main = new Main();
            main.SeedData();

            string role = "manager";
            main.SelectRole(role);

            main.ChangeBasketMax(13);

            Random r = new Random();
            int rInt = r.Next(0, 3);
            int rInt1 = r.Next(3, main.Products.Count);

            string bagel = main.Products[rInt].SKU;
            string item = main.Products[rInt1].SKU;

            main.AddItem(item);

            int bagels = 6;
            decimal bagelOfferPrice = 2.49M;

            // act
            for (int i = 0; i < bagels; i++)
            {
                main.AddItem(bagel);
            }

            main.TotalCostBasket();

            // assert
            Assert.AreEqual(bagelOfferPrice + main.Products[rInt1].Price, main.total);
        }
    }
}
