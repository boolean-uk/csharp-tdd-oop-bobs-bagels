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
    public class BobsBagelsTests
    {
        [Test]
        public void Create_Inventory() //Create Inventory
        {
            //arrange
            Inventory BobsInventory = new Inventory();

            //act
            BobsInventory.SetInventory();
            var stock = BobsInventory.Stock;

            //assert
            Assert.That(stock, Is.Not.Null);
        }

        [Test]
        public void Basket_Add() //Add a bagel to the basket
        {
            //arrange
            Basket basket = new Basket();

            //act
            basket.AddItem("B1");

            //assert
            Assert.That(basket.orderBasket.Count > 0);
        }

        [Test]
        public void Basket_Remove() 
        {
            //arrange
            Basket basket = new Basket();

            //act
            basket.AddItem("B2");
            basket.RemoveItem("B2R");

            //assert
            Assert.That(basket.orderBasket.Count == 0);
        }

        [Test]
        public void View_Basket()
        {
            //arrange
            Basket basket = new Basket();

            //act
            basket.AddItem("B2");
            basket.AddItem("C2");

            //assert
            string basketContents = basket.ViewBasket();
            Assert.That(basketContents.Contains("B2"));
        }

        [Test]
        public void Basket_Full() // currently takes 7 items
        {
            //arrange
            Basket basket = new Basket();

            //act
            for (int i = 1; i <= 7; i++)
            { basket.AddItem("B2"); }
            
            //assert
            basket.AddItem("C2"); // try to add item nr 8
            Assert.IsTrue(basket.orderBasket.Count < 8);
        }

        [Test]
        public void Basket_Max() //Manager changes max capacity
        {
            //arrange
            Basket basket = new Basket();
      
            //act
            basket.EditMaximum("007", 20); //change capacity to 20
            int result = basket.MaxCapacity;

            //assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Get_Receipt()
        {
            //arrange
            Basket basket = new Basket();

            //act
            basket.AddItem("B2");
            basket.AddItem("C3");
            basket.AddItem("C3");
            basket.AddItem("F5");
            string receipt = basket.GetReceipt();

            //assert
            Assert.That(receipt, Is.Not.Null);
        }
    }


   
    }



