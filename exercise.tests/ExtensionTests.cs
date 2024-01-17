﻿using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class Extension
    {
        [Test, Order(1)]
        public void Test_01_Discount_6_Onion()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLO");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 2.49d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test, Order(2)]
        public void Test_02_Discount_6_Mix()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLE");
            Bagel bagel3 = new Bagel("BGLS");
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLE");
            Bagel bagel6 = new Bagel("BGLS");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 2.49d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 6x plain bagels = 2.34 = CHEAPER THAN THE DISCOUNT!
        /// </summary>
        /// 
        [Test, Order(3)]
        public void Test_03_Discount_6_6Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLP");
            Bagel bagel4 = new Bagel("BGLP");
            Bagel bagel5 = new Bagel("BGLP");
            Bagel bagel6 = new Bagel("BGLP");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 2.34d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 5x plain bagels+1 regular = 2.44 = CHEAPER THAN THE DISCOUNT!
        /// </summary>
        [Test, Order(3)]
        public void Test_03_Discount_6_5Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLP");
            Bagel bagel4 = new Bagel("BGLP");
            Bagel bagel5 = new Bagel("BGLP");
            Bagel bagel6 = new Bagel("BGLO");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 2.44d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 4x plain bagels+2 regular = 2.54 = More expensive than discount = discount should work.
        /// </summary>
        [Test, Order(3)]
        public void Test_03_Discount_6_4Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLP");
            Bagel bagel4 = new Bagel("BGLP");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 2.49d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 2.49 + 0.49
        /// </summary>
        [Test, Order(4)]
        public void Test_04_Discount_6_7ordered()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLO");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Bagel bagel7 = new Bagel("BGLO");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(bagel7);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 2.98d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }


        /// <summary>
        /// 12x plain bagels gives discount
        /// </summary>
        [Test, Order(5)]
        public void Test_05_Discount_12_Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1  = new Bagel("BGLP");
            Bagel bagel2  = new Bagel("BGLP");
            Bagel bagel3  = new Bagel("BGLP");
            Bagel bagel4  = new Bagel("BGLP");
            Bagel bagel5  = new Bagel("BGLP");
            Bagel bagel6  = new Bagel("BGLP");
            Bagel bagel7  = new Bagel("BGLP");
            Bagel bagel8  = new Bagel("BGLP");
            Bagel bagel9  = new Bagel("BGLP");
            Bagel bagel10 = new Bagel("BGLP");
            Bagel bagel11 = new Bagel("BGLP");
            Bagel bagel12 = new Bagel("BGLP");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(bagel7);
            basket.AddProduct(bagel8);
            basket.AddProduct(bagel9);
            basket.AddProduct(bagel10);
            basket.AddProduct(bagel11);
            basket.AddProduct(bagel12);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 3.99d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// Mix of 12 means 2 x 6 discount in my eyes or this discount would be too OP.
        /// </summary>
        [Test, Order(6)]
        public void Test_06_Discount_12_Mix()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLE");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLP");
            Bagel bagel7 = new Bagel("BGLO");
            Bagel bagel8 = new Bagel("BGLO");
            Bagel bagel9 = new Bagel("BGLS");
            Bagel bagel10 = new Bagel("BGLP");
            Bagel bagel11 = new Bagel("BGLP");
            Bagel bagel12 = new Bagel("BGLP");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(bagel7);
            basket.AddProduct(bagel8);
            basket.AddProduct(bagel9);
            basket.AddProduct(bagel10);
            basket.AddProduct(bagel11);
            basket.AddProduct(bagel12);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 4.98d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 24x plain bagels gives 2x12 discount
        /// </summary>
        [Test, Order(7)]
        public void Test_07_Discount_24_Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLP");
            Bagel bagel4 = new Bagel("BGLP");
            Bagel bagel5 = new Bagel("BGLP");
            Bagel bagel6 = new Bagel("BGLP");
            Bagel bagel7 = new Bagel("BGLP");
            Bagel bagel8 = new Bagel("BGLP");
            Bagel bagel9 = new Bagel("BGLP");
            Bagel bagel10 = new Bagel("BGLP");
            Bagel bagel11 = new Bagel("BGLP");
            Bagel bagel12 = new Bagel("BGLP");
            Bagel bagel13 = new Bagel("BGLP");
            Bagel bagel14 = new Bagel("BGLP");
            Bagel bagel15 = new Bagel("BGLP");
            Bagel bagel16 = new Bagel("BGLP");
            Bagel bagel17 = new Bagel("BGLP");
            Bagel bagel18 = new Bagel("BGLP");
            Bagel bagel19 = new Bagel("BGLP");
            Bagel bagel20 = new Bagel("BGLP");
            Bagel bagel21 = new Bagel("BGLP");
            Bagel bagel22 = new Bagel("BGLP");
            Bagel bagel23 = new Bagel("BGLP");
            Bagel bagel24 = new Bagel("BGLP");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(bagel7);
            basket.AddProduct(bagel8);
            basket.AddProduct(bagel9);
            basket.AddProduct(bagel10);
            basket.AddProduct(bagel11);
            basket.AddProduct(bagel12);
            basket.AddProduct(bagel13);
            basket.AddProduct(bagel14);
            basket.AddProduct(bagel15);
            basket.AddProduct(bagel16);
            basket.AddProduct(bagel17);
            basket.AddProduct(bagel18);
            basket.AddProduct(bagel19);
            basket.AddProduct(bagel20);
            basket.AddProduct(bagel21);
            basket.AddProduct(bagel22);
            basket.AddProduct(bagel23);
            basket.AddProduct(bagel24);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 7.98d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 24x mixed bagels gives 4x6 discount
        /// </summary>
        [Test, Order(8)]
        public void Test_08_Discount_24_mixed()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Bagel bagel2 = new Bagel("BGLP");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLE");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLP");
            Bagel bagel7 = new Bagel("BGLO");
            Bagel bagel8 = new Bagel("BGLO");
            Bagel bagel9 = new Bagel("BGLS");
            Bagel bagel10 = new Bagel("BGLP");
            Bagel bagel11 = new Bagel("BGLP");
            Bagel bagel12 = new Bagel("BGLP");
            Bagel bagel13 = new Bagel("BGLO");
            Bagel bagel14 = new Bagel("BGLE");
            Bagel bagel15 = new Bagel("BGLO");
            Bagel bagel16 = new Bagel("BGLP");
            Bagel bagel17 = new Bagel("BGLO");
            Bagel bagel18 = new Bagel("BGLO");
            Bagel bagel19 = new Bagel("BGLS");
            Bagel bagel20 = new Bagel("BGLP");
            Bagel bagel21 = new Bagel("BGLP");
            Bagel bagel22 = new Bagel("BGLP");
            Bagel bagel23 = new Bagel("BGLO");
            Bagel bagel24 = new Bagel("BGLO");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(bagel7);
            basket.AddProduct(bagel8);
            basket.AddProduct(bagel9);
            basket.AddProduct(bagel10);
            basket.AddProduct(bagel11);
            basket.AddProduct(bagel12);
            basket.AddProduct(bagel13);
            basket.AddProduct(bagel14);
            basket.AddProduct(bagel15);
            basket.AddProduct(bagel16);
            basket.AddProduct(bagel17);
            basket.AddProduct(bagel18);
            basket.AddProduct(bagel19);
            basket.AddProduct(bagel20);
            basket.AddProduct(bagel21);
            basket.AddProduct(bagel22);
            basket.AddProduct(bagel23);
            basket.AddProduct(bagel24);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost(), 3);
            double actualResult = 9.96d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 1x coffee deal
        /// </summary>
        [Test, Order(9)]
        public void Test_09_Discount_CoffeeDeal_Regular()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Coffee coffee1 = new Coffee("COFB");
            basket.AddProduct(bagel1);
            basket.AddProduct(coffee1);


            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 1.25d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// 1x coffee deal with Plain
        /// </summary>
        [Test, Order(9)]
        public void Test_09_Discount_CoffeeDeal_Plain()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLP");
            Coffee coffee1 = new Coffee("COFB");
            basket.AddProduct(bagel1);
            basket.AddProduct(coffee1);


            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 1.25d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }


        /// <summary>
        /// 2x coffee deal
        /// </summary>
        [Test, Order(10)]
        public void Test_10_Discount_CoffeeDealx2()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLO");
            Coffee coffee1 = new Coffee("COFB");
            Coffee coffee2 = new Coffee("COFB");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(coffee1);
            basket.AddProduct(coffee2);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 2.5d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        /// <summary>
        /// Based on the example order, one cannot combine any discounts with a coffee deal (thank god)
        /// </summary>
        [Test, Order(11)]
        public void Test_11_Discount_CoffeeDeal_And_6x()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLO");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Coffee coffee1 = new Coffee("COFB");
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);
            basket.AddProduct(coffee1);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 3.48d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        //Fillings ;_;

        [Test, Order(12)]
        public void Test_12_Discount_6_Discount_Fillings()
        {
            //Arrange
            Basket basket = new Basket();
            Bagel bagel1 = new Bagel("BGLO");
            Bagel bagel2 = new Bagel("BGLO");
            Bagel bagel3 = new Bagel("BGLO");
            Bagel bagel4 = new Bagel("BGLO");
            Bagel bagel5 = new Bagel("BGLO");
            Bagel bagel6 = new Bagel("BGLO");
            Filling filling1 = new Filling("FILB");
            Filling filling2 = new Filling("FILE");
            bagel1.ChooseFilling(filling1);
            bagel2.ChooseFilling(filling2);
            basket.AddProduct(bagel1);
            basket.AddProduct(bagel2);
            basket.AddProduct(bagel3);
            basket.AddProduct(bagel4);
            basket.AddProduct(bagel5);
            basket.AddProduct(bagel6);

            //Act
            double expectedResult = Math.Round(basket.CheckTotalCost());
            double actualResult = 2.73d;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
