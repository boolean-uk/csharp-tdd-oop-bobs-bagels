using exercise.main;
using System.Reflection.Emit;

namespace exercise.tests
{
    public class ExtensionTest
    {
        [Test]
        public void ShouldAddDiscountToCustomerWithOnionPlaneAndEverythingBagel()
        {
            var customer = new Customer { };
            Item onion = DefaultInventory.FindItemInInventoryBySKU("BGLO");
            Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
            Item everything = DefaultInventory.FindItemInInventoryBySKU("BGLE");
            for (int i = 0; i < 6; i++)
            {
                customer.basket.PutInBasket(onion);
                customer.basket.PutInBasket(everything);
            }
            for (int i = 0; i < 12; i++)
            {
                customer.basket.PutInBasket(plain);
            }
            customer.basket.AddDiscountIfThereIs();
            double sum = customer.basket.SumTotal();

            // 2.49 + 3.99 + 2.49
            Assert.That(8.97d, Is.EqualTo(Math.Round(sum, 2)));
        }
        [Test]
        public void ShouldAddDiscountToCustomerWithOnionAndPlaneBagelAndFilling()
        {
            var customer = new Customer { };
            Item onion = DefaultInventory.FindItemInInventoryBySKU("BGLO");
            Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
            Item filling = DefaultInventory.FindItemInInventoryBySKU("FILE");
            for (int i = 0; i < 6; i++)
            {
                customer.basket.PutInBasket(onion);
            }
            for (int i = 0; i < 12; i++)
            {
                customer.basket.PutInBasket(plain);
            }
            customer.basket.PutInBasket(filling);

            customer.basket.AddDiscountIfThereIs();
            double sum = customer.basket.SumTotal();

            // 2.49 + 3.99 + 0.12
            Assert.That(6.6d, Is.EqualTo(Math.Round(sum, 2)));
        }
        [Test]
        public void ShouldAddDiscountToCustomerWithOnionAndPlaneBagel()
        {
            var customer = new Customer { };
            Item onion = DefaultInventory.FindItemInInventoryBySKU("BGLO");
            Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
            Item filling = DefaultInventory.FindItemInInventoryBySKU("FILE");
            for (int i = 0; i < 6; i++)
            {
                customer.basket.PutInBasket(onion);
            }
            for (int i = 0; i < 6; i++)
            {
                customer.basket.PutInBasket(plain);
            }
            customer.basket.PutInBasket(filling);
            double sumBeforeDiscount = customer.basket.SumTotal();
            customer.basket.AddDiscountIfThereIs();
            double discount = customer.basket.SumTotal();

            // Not discount, plain each is: 0.39 total is 2.34
            // Filling is 0.12
            // 2.49 + 2.34 + 0.12
            Assert.That(0.39 * 6 + 0.49 * 6 + 0.12, Is.EqualTo(sumBeforeDiscount));
            Assert.That(4.95d, Is.EqualTo(Math.Round(discount, 2)));
        }
        [Test]
        public void ShouldAddDiscountIfCoffeAndBagelIsInBasket()
        {
            var customer = new Customer();
            Item sesame = DefaultInventory.FindItemInInventoryBySKU("BGLS");
            Item black = DefaultInventory.FindItemInInventoryBySKU("COFB");
            customer.basket.PutInBasket(sesame);
            customer.basket.PutInBasket(black);
            customer.basket.AddDiscountIfThereIs();
            customer.basket.printReciept();

            Assert.That(1, Is.EqualTo(customer.basket.items.Count()));
        }
        [Test]
        public void ShouldAddDiscountPlainBagel()
        {
            Customer c = new Customer();
            Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
            for (int i = 0;i < 13; i++) {
                c.basket.PutInBasket(plain);
            }
            c.basket.AddDiscountIfThereIs();
            c.basket.printReciept();

            Assert.That(2, Is.EqualTo(c.basket.items.Count()));
        }
        [Test]
        public void ShouldAddLoadsOfBagelsAndCombainDiscounts()
        {
            Customer c = new Customer();
            Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
            Item everything = DefaultInventory.FindItemInInventoryBySKU("BGLE");
            Item coffee = DefaultInventory.FindItemInInventoryBySKU("COFB");
            for (int i = 0; i < 26; i++)
            {
                c.basket.PutInBasket(plain);
            }
            c.basket.PutInBasket(coffee);
            c.basket.PutInBasket(everything);
            c.basket.AddDiscountIfThereIs();
            c.basket.printReciept();
            Assert.That(5, Is.EqualTo(c.basket.items.Count()));
        }
    }
}
