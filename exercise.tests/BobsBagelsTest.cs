using exercise.main;
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using NUnit.Framework;
using System.Reflection.Emit;

namespace exercise.tests
{
    public class BobsBagelsTest
    {
        private Basket _basket;
        private Inventory _inventory;
        private Receipt _receipt;

        Item bagel1 = new Item(0.49f, "BagelOnion", "BGLO");
        Item bagelPlain = new Item(0.39f, "BagelPlain", "BGLP");
        Item bagel2 = new Item(0.49f, "BagelSesame", "BGLS");


        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();   
            _inventory = new Inventory();   
            _receipt = new Receipt(_basket);

        }

        [Test]
        public void addBageltest()
        {
            //testing if the bagel is being addded
            string message1;
            
            bool result = _basket.addBagel(bagelPlain, out message1);
            Assert.That(result, Is.EqualTo(true));

            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(1));
            Assert.That(_basket.GetBasketContent()[0], Is.EqualTo(bagelPlain));
        }



        [Test]
        public void addBageltest2()
        {
            //testing if the basket is full
            string message1;
            _basket.addBagel(bagelPlain, out message1);
            _basket.addBagel(bagel1, out message1);
            _basket.addBagel(bagel2, out message1);
            Assert.That(message1, Is.EqualTo("Basket is full"));

        }



        [Test]
        public void removeTest()
        {

            string message3;
            //testing if an item can be removed
            _basket.addBagel(bagelPlain, out message3);
            _basket.addBagel(bagel1, out message3);
            bool result1 = _basket.removeBagel(bagelPlain, out message3);
            Assert.That(result1, Is.EqualTo(true));


            //testing that the item is not in the list anymore
            List<string> expected1 = new List<string> { "Chilli" };

            //Assert that list does not contain "Plain"
            //Assert.That(_basket.GetBasketContent(), Is.EqualTo(expected1));

        }

        [Test]
        public void removeTest2()
        {
            string message2;
            //testing if the basket is full
            _basket.addBagel(bagelPlain, out message2);
            bool message = _basket.removeBagel(bagel2, out message2);

            Assert.That(message2, Is.EqualTo("Item not in basket"));

        }



        [Test]
        //testing if the capacity of the basket will be changed as expected
        public void changeCapacityTest()
        {
            int result = _basket.changeCapacity(2);

            Assert.That(result, Is.EqualTo(2));
        }




        [Test]
        public void totalPriceTest()
        {
            string message;
        
            _basket.addBagel(bagel1, out message);
            float result = _receipt.totalPrice();
            Assert.That(result, Is.EqualTo(0.49f));

           
            _basket.addBagel(bagel2, out message);
            float result1 = _receipt.totalPrice();
            Assert.That(result1, Is.EqualTo(0.89f));
        }

        [Test]
        public void totalPriceEmptyTest() 
        { 
            string message2;
            float resultEmpty = _receipt.totalPrice();
            Assert.That(resultEmpty, Is.EqualTo(0f));
        }

        //added filling test 


    }




   
}
