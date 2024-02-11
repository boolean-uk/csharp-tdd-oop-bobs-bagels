using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_tdd_bobs_bagels.tests;
using exercise.main;
using tdd_bobs_bagels.Main;


namespace csharp_tdd_bobs_bagels.tests
{
    [TestFixture]
    public class BasketTest
    {
        [Test]
        public void TestAddBagelToBasket()
        {
            Basket basket = new Basket();
            Product bagel = new Bagel("BGLO");

            basket.Add(bagel);

            Assert.That(basket.Items.Count, Is.EqualTo(1));
            Assert.That(basket.GetTotal(), Is.EqualTo(0.49));
            Assert.That(basket.Items[0], Is.EqualTo(bagel));

            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);
            basket.Add(bagel);

            Assert.Throws<Exception>(() => basket.Add(bagel));
        }

        [Test]
        public void TestRemoveBagelFromBasket()
        {
            Basket basket = new Basket();
            Product bagel = new Bagel("BGLO");

            basket.Add(bagel);
            basket.Remove(bagel);

            Assert.That(basket.Items.Count, Is.EqualTo(0));

            Assert.Throws<Exception>(() => basket.Remove(bagel));
        }

    

    }
}
