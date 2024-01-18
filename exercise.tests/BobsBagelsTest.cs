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

        private Receipt _receipt;

        Item bagel1 = new Item(0.49f, "Bagel", "Onion", "BGLO");
        Item bagelPlain = new Item(0.39f, "Bagel", "Plain", "BGLP");
        Item bagel2 = new Item(0.49f, "Bagel", "Sesame", "BGLS");


        [SetUp]
        public void SetUp()
        {
            Inventory inventory = new Inventory();
            _basket = new Basket(inventory);

            _receipt = new Receipt(_basket);

        }





        [Test]
        public void addBageltest()
        {
            //testing if the bagel is being addded
            string message1;
            
            bool result = _basket.AddProduct("BGLP", out message1);
            Assert.That(result, Is.EqualTo(true));

            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(1));
            IProduct addedProduct = _basket.GetBasketContent()[0];

            Assert.That(addedProduct.Price, Is.EqualTo(bagelPlain.Price).Within(0.001));
            Assert.That(addedProduct.Name, Is.EqualTo(bagelPlain.Name));
            Assert.That(addedProduct.Variant, Is.EqualTo(bagelPlain.Variant));
            Assert.That(addedProduct.SKU, Is.EqualTo(bagelPlain.SKU));
        }






        [Test]
        public void addBageltest2()
        {
            //testing if the basket is full
            string message2;
            _basket.AddProduct("BGLP", out message2);
            _basket.AddProduct("BGLO", out message2);
            _basket.AddProduct("BGLS", out message2);
            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(2));
            Assert.That(message2, Is.EqualTo("Basket is full"));

        }







        [Test]
        public void removeTest()
        {

            string message3;
            //testing if an item can be removed
            _basket.AddProduct("BGLP", out message3);
            _basket.AddProduct("BGLO", out message3);
            bool result1 = _basket.RemoveProduct("BGLP", out message3);
            Assert.That(result1, Is.EqualTo(true));


            //testing that the item is not in the list anymore
            List<string> expected1 = new List<string> { "Chilli" };

            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(1));
            //Assert.That(_basket.GetBasketContent()[0], Is.EqualTo(bagel1));
            IProduct addedProduct1 = _basket.GetBasketContent()[0];

            Assert.That(addedProduct1.Price, Is.EqualTo(bagel1.Price).Within(0.001));
            Assert.That(addedProduct1.Name, Is.EqualTo(bagel1.Name));
            Assert.That(addedProduct1.Variant, Is.EqualTo(bagel1.Variant));
            Assert.That(addedProduct1.SKU, Is.EqualTo(bagel1.SKU));
        }






        [Test]
        public void removeTest2()
        {
            string message2;
            //testing if the basket is full
            _basket.AddProduct("BGLP", out message2);
            bool message = _basket.RemoveProduct("BGLS", out message2);

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
        
            _basket.AddProduct("BGLO", out message);
            float resultTotal = _receipt.totalPrice();
            Assert.That(resultTotal, Is.EqualTo(0.49f).Within(0.001f));
           


            _basket.AddProduct("BGLS", out message);
            float result1 = _receipt.totalPrice();
            Assert.That(result1, Is.EqualTo(0.98f).Within(0.001f));
        }





        [Test]
        public void totalPriceEmptyTest() 
        { 
            string message2;
            float resultEmpty = _receipt.totalPrice();
            Assert.That(resultEmpty, Is.EqualTo(0f));

            
        }





        [Test]
        public void addFillingTestFail()
        {
            //testing for an item that is not a filling
            // Add bagel to the basket
            string message1;
            _basket.AddProduct("BGLO", out message1);

            // Add invalid filling to the bagel
            Item invalidFilling = new Item(0.49f, "Bagel", "Sesame", "BGLS");
            string message2;
            bool result = _basket.AddFillingToBagel("BGLO", invalidFilling, out message2);

            Assert.That(result, Is.EqualTo(false));
            //Assert.That(message2, Is.EqualTo("Invalid filling type"));

            // Check if the bagel does not contain the invalid filling
            Assert.That(bagel1.GetSubItems(), Does.Not.Contain(invalidFilling));
        }
  



        [Test]
        public void addFillingTest()
        {
            // Add bagel to the basket
            string message1;
            _basket.AddProduct("BGLS", out message1);

            Item _filling = new Item(0.12f, "Filling", "Bacon", "FILB");
            // Add filling to the bagel
            string message2;
            bool result = _basket.AddFillingToBagel("BGLS", _filling, out message2);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(message2, Is.EqualTo(string.Empty));

            // Get the bagels in the basket
            List<IProduct> bagelsInBasket = _basket.GetBasketContent();

            // Check the sub-items of the bagel in the basket
            List<IProduct> subItems = ((Item)bagelsInBasket[0]).GetSubItems();
            Assert.That(subItems.Count, Is.EqualTo(1));  
        }
       





        [Test]
        public void AddFillingTestFail2()
        {
            // Try to add filling to a bagel not in the basket
            Item _filling1 = new Item(0.12f, "Filling","Bacon", "FILB");
            string message;
            bool result = _basket.AddFillingToBagel("BGLS", _filling1, out message);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(message, Is.EqualTo("Bagel not in basket"));

            // Check if the bagel still does not contain the filling
            Assert.That(bagel1.GetSubItems(), Does.Not.Contain(_filling1));
        }


    }


   
}
