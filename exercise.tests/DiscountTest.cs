using exercise.main;

namespace exercise.tests
{
    [TestFixture]
    public class DiscountTest
    {
        [Test]
        public void TestGetValidDiscounts()
        {
            //setup
            Discount discount = new Discount();

            //execute
            discount.GetValidDiscounts();

            //verify
            Assert.True(true);
        }

        [Test]
        public void TestReturnsCorrectDiscountAmount()
        {
            //setup
            Discount discount = new();
            Bagel bagel = new(BagelType.Sesame);
            Bagel bagel2 = new(BagelType.Plain);
            Bagel bagel3 = new(BagelType.Onion);
            Bagel bagel4 = new(BagelType.Everything);
            Bagel bagel5 = new(BagelType.Sesame);
            Bagel bagel6 = new(BagelType.Plain);
            Bagel bagelWithFilling = new(BagelType.Plain);
            List<Item> items = [bagel, bagel2, bagel3, bagel4, bagel5, bagel6];
            double shouldBePrice = 2.49;
            double priceOfAll = items.Sum(x => x.GetPrice());

            //execute
            discount.CalculateDiscounts(items);
            double totalPrice = discount.GetTotalPrice();
            double discountAmount = discount.GetDiscountAmount();

            //verify
            Assert.That(totalPrice, Is.EqualTo(shouldBePrice));
            Assert.That(discountAmount, Is.EqualTo(priceOfAll - shouldBePrice));
        }

    }
}
