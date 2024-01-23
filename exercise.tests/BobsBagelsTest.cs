using exercise.main;
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

            //testing that only 1 item is in the basket
            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(1));

            //testing if that item is the plain bagel
            Item addedProduct = _basket.GetBasketContent()[0];

            Assert.That(addedProduct.Price, Is.EqualTo(bagelPlain.Price).Within(0.001));
            Assert.That(addedProduct.Name, Is.EqualTo(bagelPlain.Name));
            Assert.That(addedProduct.Variant, Is.EqualTo(bagelPlain.Variant));
            Assert.That(addedProduct.SKU, Is.EqualTo(bagelPlain.SKU));
        }



        [Test]
        public void addBagelUntilCapacityIsFull()
        {
            //testing if the basket is full, if the last item will not be added 
            string message2;
            _basket.AddProduct("BGLP", out message2);
            _basket.AddProduct("BGLO", out message2);
            _basket.AddProduct("BGLS", out message2);

            //testing that, since capacity=2, onlt two items are in the basket
            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(2));
            //testing the output message
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
            

            Item addedProduct1 = _basket.GetBasketContent()[0];

            Assert.That(addedProduct1.Price, Is.EqualTo(bagel1.Price).Within(0.001));
            Assert.That(addedProduct1.Name, Is.EqualTo(bagel1.Name));
            Assert.That(addedProduct1.Variant, Is.EqualTo(bagel1.Variant));
            Assert.That(addedProduct1.SKU, Is.EqualTo(bagel1.SKU));
        }






        [Test]
        public void removeIfItemNotInBasket()
        {
            string message2;
            //Adding one bagel
            _basket.AddProduct("BGLP", out message2);

            //trying to remove a different bagel
            bool message = _basket.RemoveProduct("BGLS", out message2);

            Assert.That(message2, Is.EqualTo("Item not in basket"));

        }






        [Test]
        //testing if the capacity of the basket will be changed as expected
        public void changeCapacityTest()
        {
            int result = _basket.changeCapacity(3);

            Assert.That(result, Is.EqualTo(3));
    

            //testing if the basket is full, if the last item will not be added 
            string message2;
            _basket.AddProduct("BGLP", out message2);
            _basket.AddProduct("BGLO", out message2);
            _basket.AddProduct("BGLS", out message2);
            _basket.AddProduct("COFL", out message2);

            //testing that, since capacity is now 3, that 3 items are in the basket
            Assert.That(_basket.GetBasketContent().Count, Is.EqualTo(3));
            //testing the output message
            Assert.That(message2, Is.EqualTo("Basket is full"));

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
            Bagel BagelOnion = new Bagel("BGLO");
            //testing for an item that is not a filling
            // Add bagel to the basket
            string message1;
            _basket.AddProduct("BGLO", out message1);

            // Add invalid filling to the bagel
            Item invalidFilling = new Item(0.49f, "Bagel", "Sesame", "BGLS");
            string message2;
            bool result = BagelOnion.AddFillingToBagel("BGLO", invalidFilling, out message2);

            Assert.That(result, Is.EqualTo(false));
            //Assert.That(message2, Is.EqualTo("Invalid filling type"));

            // Check if the bagel does not contain the invalid filling
            Assert.That(bagel1.GetSubItems(), Does.Not.Contain(invalidFilling));
        }
  



        [Test]
        public void addFillingToBagelTest()
        {
            Bagel BagelSesame = new Bagel("BGLS");
             //Add bagel to the basket

            Item _filling = new Item(0.12f, "Filling", "Bacon", "FILB");
            // Add filling to the bagel
            string message2;
            bool result = BagelSesame.AddFillingToBagel("BGLS", _filling, out message2);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(message2, Is.EqualTo(string.Empty));

        }
       





        [Test]
        public void AddFillingTestFailBagelNotInBasket()
        {
            Bagel BagelOnion = new Bagel("BGLO");
            // Try to add filling to a bagel not in the basket
            Item _filling1 = new Item(0.12f, "Filling","Bacon", "FILB");
            string message;
            bool result = BagelOnion.AddFillingToBagel("BGLS", _filling1, out message);

            Assert.That(result, Is.EqualTo(false));
            

            // Check if the bagel still does not contain the filling
            Assert.That(bagel1.GetSubItems(), Does.Not.Contain(_filling1));
        }



        [Test]
        public void CalculateTotalCost_WithoutFilling_ShouldReturnBagelPrice()
        {
            // Arrange
            Bagel bagel5 = new Bagel("BGLS");

            // Act
            float totalCost = bagel5.CalculateTotalCost();

            // Assert
            Assert.AreEqual(0.49f, totalCost);
        }

        [Test]
        public void CalculateTotalCost_WithOneFilling_ShouldReturnBagelAndFillingPrice()
        {
            // Arrange
            Bagel bagel = new Bagel("BGLS");
        
            Item filling = new Item(0.12f, "Filling", "Bacon", "FILB");
            bagel.AddSubItems(filling);

            // Act
            float totalCost = bagel.CalculateTotalCost();

            // Assert
            Assert.AreEqual(0.49f + 0.12f, totalCost);
        }

    }



}
