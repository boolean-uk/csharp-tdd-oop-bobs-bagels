using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class Bagel_Test
    {

        private Bagel_shop shop;
        private List<User> users;
        public List<User> Users { get { return users; } set { users = value; } }

        public Bagel_Test()
        {
            shop = new Bagel_shop();
            users = new List<User>();
            Users.Add(new User("Iasonas", "Member of the public"));
            Users.Add(new User("Thanasis", "Member of the public"));
            Users.Add(new User("Stavros", "Member of the public"));
            Users.Add(new User("Max", "Member of the public"));
            Users.Add(new User("Joeri", "Member of the public"));
            Users.Add(new User("Nikita", "Customer"));
            Users.Add(new User("Valentina", "Customer"));
            Users.Add(new User("Nigel", "Manager"));
        }

        [Test]
        public void CheckIfAdded()
        {
            Item itemtoAdd = new Item("BGLO", 0.49f, "Bagel", "Onion");
            shop.addItems(users[0], itemtoAdd);
            Assert.AreEqual(users[0].Items.Count, 1);
        }

        [Test]
        public void CheckIfRemoved()
        {
            Item itemtoRemove = new Item("BGLO", 0.49f, "Bagel", "Onion");
            shop.addItems(users[1], new Item("BGLO", 0.49f, "Bagel", "Onion"));
            shop.addItems(users[1], new Item("BGLP", 0.39f, "Bagel", "Plain"));
            shop.addItems(users[1], new Item("BGLE", 0.49f, "Bagel", "Everything"));
            shop.addItems(users[1], new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            shop.removeItems(users[1], itemtoRemove);
            Assert.AreEqual(users[1].Items.Count, 3);
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
            users[6].Items.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            users[6].Items.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            users[6].Items.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            users[6].Items.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            Assert.AreEqual(shop.totalCost(users[6]),0.49f + 0.39f + 0.49f +0.49f);
        }

        [Test]
        public void itemCostTest()
        {
            Assert.AreEqual(shop.itemCost(users[5], "BGLO"), 0.49f);
        }

        [Test]
        public void AddFillingTest()
        {
            users[5].Items.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            users[5].Items.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            users[5].Items.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            users[5].Items.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            shop.addFilling(users[5], "BGLO", "Bacon");
            Assert.AreEqual(shop.totalCost(users[5]), 0.49f + 0.39f + 0.49f + 0.49f + 0.12f);
        }


    }
}
