using exercise.main;
using exercise.main.Foods;
using exercise.main.Variants;

namespace exercise.tests
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new();
        }

        [Test]
        public void CustomerCanOrderFoodTest()
        {
            Bagel bagel = new(BagelVariant.Sesame);
            Filling filling = new(FillingVariant.Cream_Cheese);
            bagel.Filling = filling;
            _customer.Order(bagel);
            Assert.That(_customer.Basket.Count == 1, Is.True);
        }

        [Test]
        public void CanOnlyOrderItemsInInventory()
        {
            List<string> availableItemsSku =
            [
                "BGLO",
                "BGLP",
                "COFB",
                "FILE",
                "FILC",
                "FILX"
            ];
            Bagel bagel = new(BagelVariant.Onion);
            Filling filling = new(FillingVariant.Ham);
            bagel.Filling = filling;
            Assert.That(_customer.Order(bagel, availableItemsSku), Is.False);
            availableItemsSku.Add("FILH");
            Assert.That(_customer.Order(bagel, availableItemsSku), Is.True);
        }

        [Test]
        public void CanOnlyOrderItemsInInventoryNoFilling()
        {
            List<string> availableItemsSku =
            [
                "BGLO",
                "BGLP",
                "COFB",
                "FILE",
                "FILC",
                "FILX"
            ];
            Bagel bagel = new(BagelVariant.Onion);
            Assert.That(_customer.Order(bagel, availableItemsSku), Is.True);
        }
    }
}
