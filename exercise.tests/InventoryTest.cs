﻿using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory _inventory;

        public InventoryTest()
        {
            _inventory = new Inventory();
        }
        [Test]
        public void CostOfBagelTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                //arrange
                Console.SetOut(sw);
                string expected =
                    "Price of all Bagels\r\n" +
                    "Variant: Onion, Price: 0,49\r\n" +
                    "Variant: Plain, Price: 0,39\r\n" +
                    "Variant: Everything, Price: 0,49\r\n" +
                    "Variant: Sesame, Price: 0,49\r\n";

                //act
                _inventory.CostOfBagel();

                //assert
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void CostOfFillingTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                //arrange
                Console.SetOut(sw);
                string expected =
                    "Price of all Fillings\r\n" +
                    "Variant: Bacon, Price: 0,12\r\n" +
                    "Variant: Egg, Price: 0,12\r\n" +
                    "Variant: Cheese, Price: 0,12\r\n" +
                    "Variant: Cream Cheese, Price: 0,12\r\n" +
                    "Variant: Smoked Salmon, Price: 0,12\r\n" +
                    "Variant: Ham, Price: 0,12\r\n";

                //act
                _inventory.CostOfFilling();

                //assert
                Assert.AreEqual(expected, sw.ToString());

            }
        }
    }
}
