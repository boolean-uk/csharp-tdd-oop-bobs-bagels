using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd.oop.bobs.bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class BobsBagelsTests
    {
        [Test]
        public void Add()
        {
            //arrange
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);


            //act
            Item item = inventory.Items.Where(i => i.SKU == "BGLO").First();
            basket.AddItem(item);


            //assert
            Assert.IsTrue(basket.items.Count == 1);
            
        }

        [Test]
        public void Remove()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);

            Item item = inventory.Items.Where(i => i.SKU == "BGLO").First();
            Item item2 = inventory.Items.Where(i => i.SKU == "COFB").First();
            basket.AddItem(item);
            basket.AddItem(item2);
            

            basket.RemoveItem(item);
            basket.RemoveItem(item2);

            Assert.IsTrue(basket.items.Count == 0);
        }

        [Test]
        public void MaxCapacity()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);

            Item item = inventory.Items.Where(i => i.SKU == "BGLO").First();
            Item item2 = inventory.Items.Where(i => i.SKU == "COFB").First();
            Item item3 = inventory.Items.Where(i => i.SKU == "FILH").First();
            Item item4 = inventory.Items.Where(i => i.SKU == "FILS").First();

            basket.AddItem(item);
            basket.AddItem(item2);
            basket.AddItem(item3);
            basket.AddItem(item4);

            

            Assert.IsTrue(basket.items.Count == 3);


        }

        [Test]
        public void ImpossibleRemove()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);
            Item item = inventory.Items.Where(i => i.SKU == "BGLO").First();
            Item item2 = inventory.Items.Where(i => i.SKU == "COFB").First();
            Item item3 = inventory.Items.Where(i => i.SKU == "FILB").First();

            basket.AddItem(item);
            basket.AddItem(item2);


            string result = basket.RemoveBagelMessage(item3);

            Assert.IsTrue(result == "The item you want to remove is not in your basket");
        }

        [Test]
        public void Total()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);

            Item item = inventory.Items.Where(i => i.SKU == "BGLO").First(); //0.49
            Item item2 = inventory.Items.Where(i => i.SKU == "COFB").First(); //0.99

            basket.AddItem(item);
            basket.AddItem(item2);

            decimal total = basket.TotalPrice();

            Assert.IsTrue(total == 1.48m);
        }

        //weergeven van de prijs van een bepaald item en die dan toevoegen?
        [Test]
        public void Beforeyoubuy()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);

            Item item = inventory.Items.FirstOrDefault(i => i.SKU == "BGLO");

            decimal result = basket.BeforeIbuy(item);

            Assert.IsTrue(result == 0.49m);

        }

        [Test]
        public void chooseFilling()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);
            Item item = inventory.Items.Where(i => i.SKU == "FILB").First();
            Item item2 = inventory.Items.FirstOrDefault(i => i.SKU == "BGLO");

            basket.AddItem(item);
            basket.AddItem(item2);

            Assert.IsTrue(basket.items.Contains(item));
           //some method that takes a SKU as argument and uses the associated filling to the bagel?


        }

        [Test]
        public void beforeIbuyFilling()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);
            Item item = inventory.Items.Where(i => i.SKU == "FILB").First();

            decimal price = basket.BeforeIbuy(item);

            Assert.IsTrue(price == 0.12m);
        }
        [Test]
        public void OnlyOrderFromInventory()
        {
            Inventory inventory = new Inventory();
            Basket basket = new Basket(3);

            Item item = inventory.Items.Where(i => i.SKU == "FILB").First();
            Item item2 = inventory.Items.Where(i => i.SKU == "ARKH").FirstOrDefault(); 

            basket.AddItem(item);
            basket.AddItem(item2);

            Assert.IsTrue(basket.items.Count == 1);
        }
    }
}
