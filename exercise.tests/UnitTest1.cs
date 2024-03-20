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
        //Bagels
        private Bagel myBagel1;
        private Bagel myBagel2;
        private Bagel myBagel3;
        private Bagel myBagel4;

        //Coffee
        private Coffee myCoffee1;
        private Coffee myCoffee2;
        private Coffee myCoffee3;
        private Coffee myCoffee4;

        //Filling
        private Filling myFilling1;
        private Filling myFilling2;
        private Filling myFilling3;
        private Filling myFilling4;
        private Filling myFilling5;
        private Filling myFilling6;

        //Bagel not in inbentory
        private Bagel extraItem;

        //Basket
        private Basket myBasket;

        //Inventory
        private Inventory myInventory;
        
        //Setup, create all objects
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test Started");

            //Create Items
            myBagel1 = new Bagel("Onion", "BGLO", 0.49f);
            myBagel2 = new Bagel("Plain", "BGLP", 0.39f);
            myBagel3 = new Bagel("Everything", "BGLE", 0.49f);
            myBagel4 = new Bagel("Sesame", "BGLS", 0.49f);

            myCoffee1 = new Coffee("Black", "COFB", 0.99f);
            myCoffee2 = new Coffee("White", "COFW", 1.19f);
            myCoffee3 = new Coffee("Capuccino", "COFC", 1.29f);
            myCoffee4 = new Coffee("Latte", "COFL", 1.29f);

            myFilling1 = new Filling("Bacon", "FILB", 0.12f);
            myFilling2 = new Filling("Egg", "FILE", 0.12f);
            myFilling3 = new Filling("Cheese", "FILC", 0.12f);
            myFilling4 = new Filling("Cream Cheese", "FILX", 0.12f);
            myFilling5 = new Filling("Smoked Salmon", "FILS", 0.12f);
            myFilling6 = new Filling("Ham", "FILH", 0.12f);

            //Item that is'nt in inventory
            extraItem = new Bagel("Onion", "BGLZ", 0.49f);

            //Add items To Inventory
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

            //New basket, and make inventory property of basket
            myBasket = new Basket();
            myBasket.inventory = myInventory;

            //Setup Complete
            Console.WriteLine("Setup complete");
        }


        //Test if Item is succesfully added,
        //And if items won't add to basket if max capacity is reached or
        //Item is'nt in inenvory
        [Test]
        public void TestAddItem()
        {
            //Add myBagel1 to basket
            myBasket.addItemToBasket(myBagel1);

            //create reference to items to compare
            Iitem expectedItem = myBagel1;
            Iitem actualItem = myBasket.getItemsList()[0];

            //Assert
            Assert.AreEqual(expectedItem, actualItem);
            Assert.AreEqual(myBasket.getItemsList().Count, 1);


            //Add Item that does'nt exist in inventory
            myBasket.addItemToBasket(extraItem);

            //Verify that item cannot be added
            Assert.AreEqual(expectedItem, actualItem);
            Assert.AreEqual(myBasket.getItemsList().Count, 1);

            //Add other 4 bagels
            myBasket.addItemToBasket(myBagel2);
            myBasket.addItemToBasket(myBagel3);
            myBasket.addItemToBasket(myBagel4);
            myBasket.addItemToBasket(myBagel1);

            //verify list have correct amount of items (max limit 5)
            Assert.AreEqual(myBasket.getItemsList().Count, 5);

            //verify that 6th item is not added
            myBasket.addItemToBasket(myBagel1);
            Assert.AreEqual(myBasket.getItemsList().Count, 5);
        }

        //Test if a Item is succesfully removed
        //And also if the error message is returned 
        //while try to remove Item that is'nt in basket
        [Test]
        
        public void testRemoveItem() 
        {
            //Add bagels to basket
            myBasket.addItemToBasket(myBagel1);
            myBasket.addItemToBasket(myBagel2);
            myBasket.addItemToBasket(myBagel3);

            //verify the amount of items in basket
            Assert.AreEqual(myBasket.getItemsList().Count(), 3);

            //Remove object in basket
            myBasket.removeItemFromBasket("BGLO");

            //verify remove was complete
            Assert.AreEqual(myBasket.getItemsList().Count(), 2);

            //try remove object that is'nt in basket
            myBasket.removeItemFromBasket("BGLO");

            //verify nothing was removed
            Assert.AreEqual(myBasket.getItemsList().Count(), 2);
        }

        //test if the maxcapacity is adjusted dcorrectly
        [Test]
        public void adjustBasketCapacityTest() 
        {
            Assert.IsTrue(myBasket.getMaxCapacity() == 5);

            myBasket.setMaxCapacity(10);

            Assert.IsTrue(myBasket.getMaxCapacity() == 10);

            myBasket.setMaxCapacity(13);

            Assert.IsTrue(myBasket.getMaxCapacity()==13);

        }

        //test if total price is returned
        [Test]
        public void getTotalPriceTest() 
        {
            myBasket.addItemToBasket(myBagel1);
            myBasket.addItemToBasket(myFilling6);

            Assert.IsTrue(myBasket.getTotalPrice() == 0.61f);
        }

        //test if the unit price is returned
        [Test]
        public void getPriceTest() 
        {
            Assert.IsTrue(myInventory.getItemPrice("BGLO") == 0.49f);
            Assert.IsTrue(myInventory.getItemPrice("COFB") == 0.99f);
        }
        
    }
}