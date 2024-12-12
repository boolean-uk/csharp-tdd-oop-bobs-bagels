using tdd_bobs_bagels.CSharp.Main;

namespace exercise.tests
{
    public class BobsBagelsTest
    {
        private Inventory inventory;
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            basket = new Basket(inventory);
        }
        

        [Test]
        public void RemoveItem_InvalidSku()
        {
            bool result = basket.RemoveItem("INVALID");
            Assert.IsFalse(result);
        }


        [Test]
        public void SetCapacity()
        {
            bool result = basket.SetCapacity(0);
            Assert.IsFalse(result);
        }

        [Test]
        public void GetItemsByCategory()
        {
            IEnumerable<Item> items = inventory.GetItemsByCategory("Bagel");
            Assert.AreEqual(3, items.Count());
        }

        [Test]
        public void GetItemsByCategory_InvalidCategory()
        {
            IEnumerable<Item> items = inventory.GetItemsByCategory("INVALID");
            Assert.AreEqual(0, items.Count());
        }

        [Test]
        public void GetPrice()
        {
            float price = basket.GetPrice("BGLP");
            Assert.AreEqual(1.00f, price);
        }

    }
}
