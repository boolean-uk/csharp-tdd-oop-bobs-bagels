using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_bobs_bagels.Main;

namespace exercise.tests
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void AddItem_ItemAddedToInventory()
        {
            Basket basket = new Basket();
            Product coffee = new Coffee("COFB");

            basket.Add(coffee);

            Assert.That(basket.Items.Count, Is.EqualTo(1));

            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);
            basket.Add(coffee);

            Assert.Throws<Exception>(() => basket.Add(coffee));

        }

        
        [Test]
        public void RemoveItem_ItemRemovedFromInventory()
        {

            Basket basket = new Basket();
            Product coffee = new Coffee("COFB");

            basket.Add(coffee);
            basket.Remove(coffee);

            Assert.That(basket.Items.Count, Is.EqualTo(0));

            Assert.Throws<Exception>(() => basket.Remove(coffee));
        }
    }
}
