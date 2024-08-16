using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main;

namespace exercise.tests
{
    public class BasketTest
    {
        [Test]
        public void TestAddingBagel()
        {
            Basket basket = new Basket();

            Item item1 = new Item("bfu", 0.49, "ali", "coffee");

            basket.addItem(item1);

            //assert
            Assert.IsTrue(basket.Item.Contains(item1));
        }
    

    }
}
