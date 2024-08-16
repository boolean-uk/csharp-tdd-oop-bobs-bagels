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
            basket.Product.Add(product1); 

            int prodCount = basket.Product.Count;

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
            basket.Product.Add(product1);
            basket.Product.Add(product1);

            int expected = 1;

            //act
            basket.Product.Remove(product1);

            int result = basket.Product.Count;


            //assert
            Assert.That(expected == result);
        }


        //SKIP FOR NOW ASK FOR HELP LATER 
            //Possible to add condition to property instead of method?
        [Test]
        public void Test()
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
            basket.Product.Add(product1);
            basket.Product.Add(product2);
            basket.Product.Add(product3);
            basket.Product.Add(product4);
            basket.Product.Add(product5);

            //add over capacity
            basket.Product.Add(product6);

            

            //act
            
            //assert
            //Assert.That(expected == result);
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

            basket.Product.Add(product1);

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
            Product product3 = inventory.Products[1];

            basket.Product.Add(product1);
            basket.Product.Add(product2);
            basket.Product.Add(product3);

            decimal expected = 0.49M + 0.49M + 0.39M;

            //act
            //Remove item 2 which has not been added to basket
            decimal result = basket.GetTotalCost();
            

            //assert
            Assert.That(expected == result);
        }

    }
}

