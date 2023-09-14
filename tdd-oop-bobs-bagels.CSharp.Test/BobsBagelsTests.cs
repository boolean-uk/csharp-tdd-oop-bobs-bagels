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

        [Test]
        public void AddBagel()
        {
            //arrange
            Core core = new Core();
            //act
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddBagel(core.Basket, core.PlainBagel);
            core.AddBagel(core.Basket, core.EverythingBagel);
            //assert
            Assert.IsTrue(core.Basket.Contains(core.OnionBagel));
        }
        [Test]
        public void RemoveBagel()
        {
            //arrange
            Core core = new Core();
            //act
            core.RemoveBagel(core.Basket, core.EverythingBagel);

            //assert
            Assert.IsFalse(core.Basket.Contains(core.EverythingBagel));
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
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddBagel(core.Basket, core.PlainBagel);
            core.Sum(core.Basket);

            //assert
            Assert.IsTrue(core.Sum(core.Basket)==(0.49f+0.39f));
        }

        [Test]
        public void AddFillingsTest()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddFillings("bacon");
            core.AddFillings("ham");
            core.AddFillings("bacon");
            // core.AddFillings(core.bacon); you can do this too
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddBagel(core.Basket, core.PlainBagel);

            //assert
            // Assert.IsTrue(core.Fillings.Contains(core.bacon));
            Assert.IsTrue(core.fillingscounter == 3);
            Assert.IsTrue(core.hasbacon == false);
        }

        [Test]
        public void SumWithFeellings() // </3 :')
        {
            //arrange
            Core core = new Core();

            //act
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddBagel(core.Basket, core.PlainBagel);
            core.AddFillings("bacon");
            core.AddFillings("ham");
            core.Sum(core.Basket);
            
            //assert
            Assert.IsTrue(core.Sum(core.Basket) == (0.49f + 0.39f + 0.12f + 0.12f));
        }

        [Test]
        public void CustomerBudget() // </3 :')
        {
            //arrange
            Core core = new Core();

            //act
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddBagel(core.Basket, core.PlainBagel);
            core.AddFillings("bacon");
            core.AddFillings("ham");
            core.Sum(core.Basket);

            //assert
            // check if after adding items the budget changes
            Assert.IsTrue(core.customerbudget == 10 - (0.49f + 0.39f + 0.12f + 0.12f));
        }

    }
}
