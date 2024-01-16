using tdd_bobs_bagels.CSharp.Main;

namespace exercise.tests
{
    public class BobsBagelsTest
    {
        private Basket _basket;
        private Inventory _inventory;
        private Item _item;


        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();   
            _inventory = new Inventory();   
            _item = new Item();
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLS");
            _basket.AddItem("FILC");
        }

        [Test]
        public void AddItem()
        {
            Assert.That(_basket.AddItem("BGLP"), Is.True);
        }

        [Test]
        public void RemoveItem()
        {
            
            Assert.That(_basket.RemoveItem("BGLP"), Is.True);
        }

        [Test]
        public void CalculateTotalCost()
        {
            _basket.AddItem("BGLP");
            _basket.AddItem("BGLS");
            _basket.AddItem("FILC");
            Assert.That(_basket.CalculateTotalCost(), Is.EqualTo(2.60f));
        }

        [Test]
        public void SetCapacity()
        {
            Assert.That(_basket.SetCapacity(10), Is.True);
        }

        [Test]
        public void Bagels()
        {
            Assert.That(_inventory.Bagels, Is.EqualTo(_inventory.Bagels));
        }

    }
}
