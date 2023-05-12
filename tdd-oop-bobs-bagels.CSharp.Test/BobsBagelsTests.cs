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
        public void AddBagelToBasket()
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
            main.AddBagel(bagel);

            // assert
            Assert.AreEqual(main.Basket.First().SKU, main.Products[rInt].SKU);
        }

        [Test]
        public void RemoveBagelFromBasket()
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

            main.AddBagel(bagel);

            Assert.AreEqual(bagel, main.Products[rInt].SKU);

            int length = main.Basket.Count;

            // act
            main.RemoveBagel(bagel);

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

            string bagel = main.Products[0].Name;
            string bagel1 = main.Products[1].Name;
            string bagel2 = main.Products[2].Name;
            string bagel3 = main.Products[3].Name;

            // act
            main.AddBagel(bagel);
            main.AddBagel(bagel1);
            main.AddBagel(bagel2);
            main.AddBagel(bagel3);

            // assert
            Assert.LessOrEqual(main.Basket.Count, 3);
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

            string bagel = main.Products[0].Name;
            string bagel1 = main.Products[1].Name;
            string bagel2 = main.Products[2].Name;
            string bagel3 = main.Products[3].Name;

            // act
            main.ChangeBasketMax(max);

            main.AddBagel(bagel);
            main.AddBagel(bagel1);
            main.AddBagel(bagel2);
            main.AddBagel(bagel3);

            // assert
            Assert.LessOrEqual(main.Basket.Count, max);
            /*Assert.IsTrue(main.Basket.Contains(item1));*/
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

            string item = main.Products[rInt].Name;

            int length = main.Basket.Count;

            // act
            main.RemoveBagel(item);

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

            main.AddBagel(item);
            main.AddBagel(item1);

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

        [Test]
        public void AddFillingToBasket()
        {
            // I'd like to be able to choose fillings for my bagel.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(9, 14);

            string filling = main.Products[rInt].SKU;

            string role = "member";
            main.SelectRole(role);

            // act
            main.AddFilling(filling);

            // assert
            Assert.AreEqual(main.Basket.First().SKU, main.Products[rInt].SKU);
        }

        [Test]
        public void FillingCost()
        {
            // I'd like to know the cost of each filling before I add it to my bagel order.

            // arrange
            Main main = new Main();
            main.SeedData();

            Random r = new Random();
            int rInt = r.Next(9, 14);

            string filling = main.Products[rInt].SKU;

            string role = "customer";
            main.SelectRole(role);

            // act
            main.ItemCost(filling);

            // assert
            Assert.AreEqual(main.Products[rInt].Price, main.cost);
        }
    }
}
