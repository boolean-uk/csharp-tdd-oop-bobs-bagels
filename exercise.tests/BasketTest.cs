using exercise.main;

namespace exercise.tests
{
    [TestFixture]
    internal class BasketTest
    {
        [Test]
        public void TestAddItemsToBasket()
        {
            var inventory = new Inventory();
            var basket = new Basket(5);
            
            bool result = basket.AddItems(inventory, "BGLO", 2);
            Assert.IsTrue(result);

            Assert.IsTrue(basket.AddItems(inventory, "BGLE", 3));

            Assert.IsFalse(basket.AddItems(inventory, "BGLE", 3));
            
        }

        [Test]
        public void TestAddItemsExceedingCapacity()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(2);

            
            bool result = basket.AddItems(inventory, "BGLO", 3);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestRemoveItemsFromBasket()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(5);
            basket.AddItems(inventory, "BGLO", 2);

            
            bool result = basket.RemoveItems(inventory, "BGLO", 1);
            
            Assert.IsTrue(result);

            Assert.IsFalse(basket.RemoveItems(inventory, "BGLE", 1));
        }

        [Test]
        public void TestRemoveItemsNotInBasket()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(5);

            
            bool result = basket.RemoveItems(inventory, "BGLO", 1);

            
            Assert.IsFalse(result);
        }

        [Test]
        public void TestChangeCapacity()
        {
            
            var basket = new Basket(2);
            basket.AddItems(new Inventory(), "BGLO", 2);

            
            bool result = basket.ChangeCapacity(3);

            
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChangeCapacityToLowerThanCurrentItems()
        {
            
            var basket = new Basket(3);
            basket.AddItems(new Inventory(), "BGLO", 3);

            
            bool result = basket.ChangeCapacity(2);

            
            Assert.IsFalse(result);
        }
    }
}
