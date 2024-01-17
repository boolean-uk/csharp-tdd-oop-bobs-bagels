using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class Tests
    {
        //Create Classes
        private Item myBagel1;
        private Item myBagel2;
        private Item myBagel3;
        private Item myBagel4;

        private Item myCoffee1;
        private Item myCoffee2;
        private Item myCoffee3;
        private Item myCoffee4;

        private Item myFilling1;
        private Item myFilling2;
        private Item myFilling3;
        private Item myFilling4;
        private Item myFilling5;
        private Item myFilling6;

        private Item extraItem;

        private Basket myBasket;

        private Inventory myInventory;

        //Setup
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test Started");

            //Create Items
            myBagel1 = new Item("Onion", "Bagel", "BGLO", 0.49f);
            myBagel2 = new Item("Plain", "Bagel", "BGLP", 0.39f);
            myBagel3 = new Item("Everything", "Bagel", "BGLE", 0.49f);
            myBagel4 = new Item("Sesame", "Bagel", "BGLS", 0.49f);

            myCoffee1 = new Item("Black", "Coffee", "COFB", 0.99f);
            myCoffee2 = new Item("White", "Coffee", "COFW", 1.19f);
            myCoffee3 = new Item("Capuccino", "Coffee", "COFC", 1.29f);
            myCoffee4 = new Item("Latte", "Coffee", "COFL", 1.29f);

            myFilling1 = new Item("Bacon", "Filling", "FILB", 0.12f);
            myFilling2 = new Item("Egg", "Filling", "FILE", 0.12f);
            myFilling3 = new Item("Cheese", "Filling", "FILC", 0.12f);
            myFilling4 = new Item("Cream Cheese", "Filling", "FILX", 0.12f);
            myFilling5 = new Item("Smoked Salmon", "Filling", "FILS", 0.12f);
            myFilling6 = new Item("Ham", "Filling", "FILH", 0.12f);

            //Item that is'nt in inventory
            extraItem = new Item("Onion", "Bagel", "BGLZ", 0.49f);

            //Add To Inventory
            myInventory = new Inventory();

            myInventory.addItemToInventory(myBagel1);
            myInventory.addItemToInventory(myBagel2);
            myInventory.addItemToInventory(myBagel3);
            myInventory.addItemToInventory(myBagel4);

            myInventory.addItemToInventory(myCoffee1);
            myInventory.addItemToInventory(myCoffee2);
            myInventory.addItemToInventory(myCoffee3);
            myInventory.addItemToInventory(myCoffee4);

            myInventory.addItemToInventory(myFilling1);
            myInventory.addItemToInventory(myFilling2);
            myInventory.addItemToInventory(myFilling3);
            myInventory.addItemToInventory(myFilling4);
            myInventory.addItemToInventory(myFilling5);
            myInventory.addItemToInventory(myFilling6);

            myBasket = new Basket();

            Console.WriteLine("Setup complete");

        }

        [Test]
        
        //Test if Item is succesfully added,
        //And if items won't add to basket if max capacity is reached or
        //Item is'nt in inenvory
        public void TestAddItem()
        {
            myBasket.addItemToBasket(myBagel1, myInventory);

            Item expectedItem = myBagel1;
            Item actualItem = myBasket.getItemsList()[0];

            Assert.AreEqual(expectedItem, actualItem);
            Assert.AreEqual(myBasket.getItemsList().Count, 1);

            myBasket.addItemToBasket(extraItem, myInventory);

            Assert.AreEqual(expectedItem, actualItem);
            Assert.AreEqual(myBasket.getItemsList().Count, 1);

            
            myBasket.addItemToBasket(myBagel2, myInventory);
            myBasket.addItemToBasket(myBagel3, myInventory);
            myBasket.addItemToBasket(myBagel4, myInventory);
            myBasket.addItemToBasket(myBagel1, myInventory);

            Assert.AreEqual(myBasket.getItemsList().Count, 5);

            myBasket.addItemToBasket(myBagel1, myInventory);
            Assert.AreEqual(myBasket.getItemsList().Count, 5);

        }

        [Test]
        //Test if a Item is succesfully removed
        //And also if the error message is returned 
        //while try to remove Item that is'nt in basket
        public void testRemoveItem() 
        {
            myBasket.addItemToBasket(myBagel1, myInventory);
            myBasket.addItemToBasket(myBagel2, myInventory);
            myBasket.addItemToBasket(myBagel3, myInventory);

            Assert.AreEqual(myBasket.getItemsList().Count(), 3);

            myBasket.removeItemFromBasket("BGLO");

            Assert.AreEqual(myBasket.getItemsList().Count(), 2);

            myBasket.removeItemFromBasket("BGLO");

            Assert.AreEqual(myBasket.getItemsList().Count(), 2);
        }

        [Test]
        //test if the maxcapacity is adjuste dcorrectly
        public void adjustBasketCapacityTest() 
        {
            Assert.IsTrue(myBasket.getMaxCapacity() == 5);

            myBasket.setMaxCapacity(10);

            Assert.IsTrue(myBasket.getMaxCapacity() == 10);

            myBasket.setMaxCapacity(13);

            Assert.IsTrue(myBasket.getMaxCapacity()==13);

        }
        [Test]
        //test if total price is returned
        public void getTotalPriceTest() 
        {
            myBasket.addItemToBasket(myBagel1, myInventory);
            myBasket.addItemToBasket(myFilling6, myInventory);

            Assert.IsTrue(myBasket.getTotalPrice() == 0.61f);
        }
        [Test]
        //test if the unit price is returned
        public void getPriceTest() 
        {
            Assert.IsTrue(myInventory.getItemPrice("BGLO") == 0.49f);
            Assert.IsTrue(myInventory.getItemPrice("COFB") == 0.99f);
        }
    }
}