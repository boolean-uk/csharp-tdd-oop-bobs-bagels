using exercise.main;

namespace exercise.tests
{
    [TestFixture]
    public class InventoryTest
    {

        [Test]
        public void TestGetItemsInInventory()
        {
            //setup
            Inventory inventory = new();
            Bagel bagel = new(BagelType.Everything);
            inventory.AddItemToInventory(bagel);

            //execute
            List<Item> items = inventory.GetItemsInInventory();

            //verify
            Assert.That(items, Is.Not.Null);
            Assert.That(items, Has.Count.EqualTo(1));

        }
    }
}
