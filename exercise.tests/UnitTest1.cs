using exercise.main;

namespace exercise.tests
{
    public class BasketTests
    {
        /*
        [SetUp]
        public void Setup()
        {
        }
        */

        [TestCase(1, true)]
        [TestCase(3, false)]
        [TestCase(10, false)]
        public void AddTest(int ex, bool res)
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];

            int expected = ex;

            //act
            basket.ProductList.Add(product1); 

            int prodCount = basket.ProductList.Count;

            bool result = expected == prodCount;

            //assert
            Assert.That(res == result);
        }


        [Test]
        public void RemoveTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];
            Product product2 = inventory.Products[1];
            basket.ProductList.Add(product1);
            basket.ProductList.Add(product1);

            int expected = 1;

            //act
            basket.ProductList.Remove(product1);

            int result = basket.ProductList.Count;


            //assert
            Assert.That(expected == result);
        }


        //SKIP FOR NOW ASK FOR HELP LATER 
            //Possible to add condition to property instead of method?
        [Test]
        public void BasketIsFullTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];
            Product product2 = inventory.Products[1];
            Product product3 = inventory.Products[2];
            Product product4 = inventory.Products[3];
            Product product5 = inventory.Products[4];
            Product product6 = inventory.Products[5];
            basket.Add(product2);
            basket.Add(product3);
            basket.Add(product4);
            basket.Add(product5);
            basket.Add(product1);

            bool expected = false;
            bool expected2 = true;

            //add over capacity
            bool result = basket.Add(product6);

            basket.Remove(product5);

            bool result2 = basket.Add(product5);

            //act
            
            //assert
            Assert.That(expected == result);
            Assert.That(expected2 == result2);
        }
        
        [Test]
        public void ChangeCapacityTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];

            int expected = 10;

            //Act
            basket.MaxCapacity = 10;

            int result = basket.MaxCapacity;

            //assert
            Assert.That(expected == result);
        }

        [Test]
        public void RemoveNonExistentTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];
            Product product2 = inventory.Products[1];

            basket.ProductList.Add(product1);

            bool expected = false;

            //act
            //Remove item 2 which has not been added to basket
            bool removed = basket.Remove(product2);

            bool result = removed;


            //assert
            Assert.That(expected == result);
        }

        [Test]
        public void TotalCostTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            Product product1 = inventory.Products[0];
            Product product2 = inventory.Products[1];
            Product product3 = inventory.Products[2];

            basket.ProductList.Add(product1);
            basket.ProductList.Add(product2);
            basket.ProductList.Add(product3);

            decimal expected = 0.49M + 0.49M + 0.39M;

            //act
            decimal result = basket.GetTotalCost();
            

            //assert
            Assert.That(expected == result);
        }

        [Test]
        public void GetBagelPriceTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            
            decimal expected = 0.39M;

            string variant = "Plain";
            //act
            //Maybe get price directly from inventory?
            //decimal result = basket.GetBagelPrice(variant);
            //decimal result = inventory.Products.Find(x => x.Variant == product1.Variant);

            var result = inventory.Products.Where(x => x.Variant == variant).First().Price;
            

            //assert
            Assert.That(expected == result);
        }

        [Test]
        //Same as the regular product add. Create a smart solution for this later
        public void AddFillingTest()
        {
            //arrange

            Inventory inventory = new Inventory();
            Basket basket = new Basket();

            //add a filling to the basket
            Product product1 = inventory.Products.Where(x => x.Name == "Filling").First();

            int expected = 1;
            
            //act
            basket.ProductList.Add(product1);

            int result = basket.ProductList.Count;


            //assert
            Assert.That(expected == result);
        }





    }
}

