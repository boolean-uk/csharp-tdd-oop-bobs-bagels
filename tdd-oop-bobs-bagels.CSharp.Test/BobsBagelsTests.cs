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

        [Test]
        public void AddCoffee()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddCoffee(core.Basket, core.BlackCoffee);
            core.AddCoffee(core.Basket, core.WhiteCoffee);
            core.AddCoffee(core.Basket, core.Capuccino);

            //assert
            Assert.IsTrue(core.Basket.Contains(core.WhiteCoffee));
        }

        [Test]
        public void SumOfCoffee()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddCoffee(core.Basket, core.BlackCoffee);
            core.AddCoffee(core.Basket, core.WhiteCoffee);
            core.SumCoffee(core.Basket);

            //assert
            Assert.IsTrue(core.SumCoffee(core.Basket) == (0.99f + 1.19f));
        }

        [Test]
        public void Add_Coffee_and_Bagel()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddCoffee(core.Basket, core.BlackCoffee);
            core.AddCoffee(core.Basket, core.WhiteCoffee);

            //assert
            Assert.IsTrue(core.Basket.Contains(core.OnionBagel));
            Assert.IsTrue(core.Basket.Contains(core.WhiteCoffee));
        }



        // Below Here I get System.InvalidCastException:
        // Unable to cast object of
        // type 'tdd_oop_bobs_bagels.CSharp.Main.Coffee' to
        // type 'tdd_oop_bobs_bagels.CSharp.Main.Bagel'.
        // But Above I can add coffee and bagel at the same basket
        // so why cant I get the sumofall?

        [Test]
        public void SumOfAll()
        {
            //arrange
            Core core = new Core();

            //act
            core.AddBagel(core.Basket, core.OnionBagel);
            core.AddCoffee(core.Basket, core.BlackCoffee);
            core.AddCoffee(core.Basket, core.WhiteCoffee);
            core.SumAll(core.Basket);

            //assert
            Assert.IsTrue(core.SumAll(core.Basket) == (0.99f + 1.19f + 0.49f));
        }

    }
}
