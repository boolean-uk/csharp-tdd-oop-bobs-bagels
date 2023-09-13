using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_bobs_bagels.CSharp.Main;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {

        bool bacon = false;
        /*bool egg = false;
        bool cheese = false;
        bool cream_cheese = false;
        bool smoked_salmon = false;
        bool ham = false;*/

        Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");


        [Test]
        public void AddBagel()
        {
            //arrange
            Core core = new Core();
            //act
            core.AddBagel(core.Basket, OnionBagel);
            core.AddBagel(core.Basket, PlainBagel);
            core.AddBagel(core.Basket, EverythingBagel);
            //assert
            Assert.IsTrue(core.Basket.Contains(OnionBagel));
        }
        [Test]
        public void RemoveBagel()
        {
            //arrange
            Core core = new Core();
            //act
            core.RemoveBagel(core.Basket, EverythingBagel);

            //assert
            Assert.IsFalse(core.Basket.Contains(EverythingBagel));
        }

        [Test]
        public void UpdateCap()
        {
            //arrange
            Core core = new Core();
            int newcap = 7;
            //act
            core.UpdateCapacity(core.Basket, newcap);

            //assert
            Assert.IsTrue(core.capacity == newcap);
        }

        [Test]
        public void SumOfBasket()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddBagel(core.Basket, OnionBagel);
            core.AddBagel(core.Basket, PlainBagel);
            core.Sum(core.Basket);

            //assert
            // this is manually set here.
            Assert.IsTrue(core.Sum(core.Basket)==(0.49f+0.39f));
        }

        [Test]
        public void AddFillingsTest()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddFillings(bacon);
            core.AddBagel(core.Basket, OnionBagel);
            core.AddBagel(core.Basket, PlainBagel);

            //assert
            Assert.IsTrue(core.Fillings.Contains(bacon));
        }

        /* public void UpdateCap()
         {
             //arrange
             Core core = new Core();

             //act
             core.UpdateCapacity(core.Basket, newcap);

             //assert
             Assert.IsTrue(core.Basket.Contains(bagel1));
         }*/
    }
}
