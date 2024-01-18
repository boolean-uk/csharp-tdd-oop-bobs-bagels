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
            Basket basket = new Basket(60);
            _customer = new(basket);
        }

        [Test]
        public void CustomerCanOrderFoodTest()
        {
            Filling filling = new(FillingVariant.Cream_Cheese);
            Bagel bagel = new(BagelVariant.Sesame, filling);
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
            Filling filling = new(FillingVariant.Ham);
            Bagel bagel = new(BagelVariant.Onion, filling);
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

        [Test]
        public void CanAddMultipleFoodsAtOnce()
        {
            _customer.Order(new Bagel(BagelVariant.Sesame), 14);
            Assert.That(_customer.Basket.Count, Is.EqualTo(14));
        }
    }
}
