using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;
using tdd_oop_bobs_bagels.CSharp.Main.Products;
using Users;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class Bagel_Test
    {

        private Bagel_shop shop;
        private List<Userr> users;
        public List<Userr> Users { get { return users; } set { users = value; } }

        public Bagel_Test()
        {
            shop = new Bagel_shop();
            users = new List<Userr>();
            Users.Add(new Member("Iasonas"));
            Users.Add(new Member("Thanasis"));
            Users.Add(new Member("Stavros"));
            Users.Add(new Member("Max"));
            Users.Add(new Member("Joeri"));
            Users.Add(new Customer("Nikita"));
            Users.Add(new Customer("Valentina"));
            Users.Add(new Manager("Nigel"));
        }

        [Test]
        public void CheckIfAdded()
        {
            Items itemtoAdd = new Bagel("BGLO", 0.49f, "Onion");
            shop.addItems(users[0], itemtoAdd);
            Assert.AreEqual(users[0].items.Count, 1);
        }

        [Test]
        public void CheckIfRemoved()
        {
            Items itemtoRemove = new Bagel("BGLO", 0.49f, "Onion");
            shop.addItems(users[1], new Bagel("BGLO", 0.49f, "Onion"));
            shop.addItems(users[1], new Bagel("BGLP", 0.39f, "Plain"));
            shop.addItems(users[1], new Bagel("BGLE", 0.49f, "Everything"));
            shop.addItems(users[1], new Bagel("BGLS", 0.49f, "Sesame"));
            shop.removeItems(users[1], itemtoRemove);
            Assert.AreEqual(users[1].items.Count, 3);
        }

        [Test]
        public void checkCapacity()
        {
            shop.changeCapacity(users[7], 8);
            Assert.AreEqual(shop.Capacity, 8);
        }

        [Test]
        public void totalCostTest()
        {
            users[6].items.Add(new Bagel("BGLO", 0.49f, "Onion")); ;
            users[6].items.Add(new Bagel("BGLP", 0.39f, "Plain"));
            users[6].items.Add(new Bagel("BGLE", 0.49f, "Everything"));
            users[6].items.Add(new Bagel("BGLS", 0.49f, "Sesame"));
            Assert.AreEqual(shop.totalCost(users[6]), 0.49f + 0.39f + 0.49f + 0.49f);
        }

        [Test]
        public void itemCostTest()
        {
            Assert.AreEqual(shop.itemCost(users[5], "BGLO"), 0.49f);
        }

        [Test]
        public void AddFillingTest()
        {
            users[5].items.Add(new Bagel("BGLO", 0.49f,"Onion"));
            users[5].items.Add(new Bagel("BGLP", 0.39f, "Plain"));
            users[5].items.Add(new Bagel("BGLE", 0.49f, "Everything"));
            users[5].items.Add(new Bagel("BGLS", 0.49f, "Sesame"));
            shop.addFilling(users[5], "BGLO", "Bacon");
            Assert.AreEqual(shop.totalCost(users[5]), 0.49f + 0.39f + 0.49f + 0.49f + 0.12f);
        }


    }
}
