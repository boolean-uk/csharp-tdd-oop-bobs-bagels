using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Test
{
    public class CoreTests
    {
        private Core _core;

        [SetUp]
        public void Setup()
        {
            _core = new Core();
        }

        [Test]
        public void CanAddBagel()
        {
            bool success = _core.AddBagel("AvadakedavrO");
            Assert.IsTrue(success);
        }

        [Test]
        public void CanRemoveBagel()
        {
            _core.AddBagel("AvadakedavrO");
            bool removed = _core.RemoveBagel("AvadakedavrO");
            Assert.IsTrue(removed);
        }

        [Test]
        public void BasketIsFull()
        {
            _core.SetCapacity(5);
            _core.AddBagel("Harry");
            _core.AddBagel("potter");
            _core.AddBagel("Lord");
            _core.AddBagel("Voldemort");
            _core.AddBagel("Dementor");
            bool isFull = _core.IsFull();
            Assert.IsTrue(isFull);
        }
        [Test]
        public void CantAddWhenBasketIsFull()
        {
            _core.SetCapacity(2);
            _core.AddBagel("AvadakedavrO");
            _core.AddBagel("Bellatric Lestrange");
            bool success = _core.AddBagel("dumbledore");
            Assert.IsFalse(success);
        }

        [Test]
        public void CannotRemoveABagelThatDoesntExist()
        {
            bool removed = _core.RemoveBagel("Cloak of invisibility");
            Assert.IsFalse(removed);
        }

        [Test]
        public void CannotUpdateAboveCapacity()
        {
            _core.SetCapacity(4);
            _core.AddBagel("Ron Weasley");
            _core.AddBagel("Luna Lovegood");
            _core.AddBagel("Neville Longbottom");
            _core.AddBagel("Hedwig");
            bool added = _core.AddBagel("professor Severus Snape");
            Assert.IsFalse(added);
        }

        [Test]
        public void DefaultCapacityFivecheck()
        {
            for (int i = 0; i < 5; i++)
            {
                _core.AddBagel("Dobby" + i);
            }
            bool isFull = _core.IsFull();
            Assert.IsTrue(isFull);
        }

        [Test]
        public void RemovingBagelFromEmptyBasketShouldReturnFalse()
        {
            bool removed = _core.RemoveBagel("Lilly Potter");
            Assert.IsFalse(removed);
        }

        [Test]
        public void CantAddNullorEmptyStringBagel()
        {
            bool succesNull = _core.AddBagel(null!);
            bool succesEmpty = _core.AddBagel(string.Empty);
            Assert.IsFalse(succesNull);
            Assert.IsFalse(succesEmpty);
        }

        [Test]
        public void NotPossibleToSetNegativeCapacity()
        {
            _core.SetCapacity(-5);
            bool canIAdd = _core.AddBagel("Vernon Dursley");
            Assert.IsFalse(canIAdd);
        }

        [Test]
        public void CannotAddDuplicatesBagel()
        {
            _core.AddBagel("Argus Filch");
            bool succes = _core.AddBagel("Argus Filch");
            Assert.IsFalse(succes);
        }

        [Test]
        public void IsBasketAllreadyFullBefore()
        {
            Assert.IsFalse(_core.IsFull());
        }

        [Test]
        public void CheckIfBasketIsNotFullAfterYouRemovebagel()
        {
            _core.SetCapacity(1);
            _core.AddBagel("");
            _core.RemoveBagel("");
            Assert.IsFalse(_core.IsFull());
        }

        [Test]
        public void CanWeAddMoreAfterIncreasingCapacity()
        {
            _core.SetCapacity(3);
            _core.AddBagel("The first");
            _core.AddBagel("The second");
            _core.AddBagel("The third");
            _core.SetCapacity(4);
            bool success = _core.AddBagel("The fourth");
            Assert.IsTrue(success);
        }
    }
}