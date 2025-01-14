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

            
            Assert.IsTrue(result, "Items should be added successfully to the basket.");
            Assert.AreEqual(2, basket.ShowBasket().Split(',').Length, "Basket should contain 2 items.");
        }

        [Test]
        public void TestAddItemsExceedingCapacity()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(2);

            
            bool result = basket.AddItems(inventory, "BGLO", 3);

            
            Assert.IsFalse(result, "Items exceeding basket capacity should not be added.");
        }

        [Test]
        public void TestRemoveItemsFromBasket()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(5);
            basket.AddItems(inventory, "BGLO", 2);

            
            bool result = basket.RemoveItems(inventory, "BGLO", 1);

            
            Assert.IsTrue(result, "Item should be removed successfully from the basket.");
            Assert.AreEqual(1, basket.ShowBasket().Split(',').Length, "Basket should contain 1 item after removal.");
        }

        [Test]
        public void TestRemoveItemsNotInBasket()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(5);

            
            bool result = basket.RemoveItems(inventory, "BGLO", 1);

            
            Assert.IsFalse(result, "Removing items not in the basket should return false.");
        }

        [Test]
        public void TestChangeCapacity()
        {
            
            var basket = new Basket(2);
            basket.AddItems(new Inventory(), "BGLO", 2);

            
            bool result = basket.ChangeCapacity(3);

            
            Assert.IsTrue(result, "Changing capacity should succeed when new capacity is sufficient.");
        }

        [Test]
        public void TestChangeCapacityToLowerThanCurrentItems()
        {
            
            var basket = new Basket(3);
            basket.AddItems(new Inventory(), "BGLO", 3);

            
            bool result = basket.ChangeCapacity(2);

            
            Assert.IsFalse(result, "Changing capacity should fail when new capacity is less than current item count.");
        }

        [Test]
        public void TestGetTotalCost()
        {
            
            var inventory = new Inventory();
            var basket = new Basket(5);
            basket.AddItems(inventory, "BGLO", 2);
            basket.AddItems(inventory, "COFB", 1); 

            
            double totalCost = basket.GetTotalCost();

            
            Assert.AreEqual(1.97, totalCost, 0.01, "Total cost should match the sum of item prices.");
        }
    }
}
