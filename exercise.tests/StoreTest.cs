using exercise.main;

namespace exercise.tests
{
    [TestFixture]
    public class StoreTest
    {

        [Test]
        public void TestGetItemsInInventory()
        {
            //setup
            Store store = new();
            Bagel bagel = new(BagelType.Everything);
            store.AddItemToInventory(bagel);

            //execute
            List<Item> items = store.GetItemsInInventory();

            //verify
            Assert.That(items, Is.Not.Null);
            Assert.That(items, Has.Count.EqualTo(1));

        }
    }
}
