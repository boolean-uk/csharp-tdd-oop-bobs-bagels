using exercise.main.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    public class BasketTest
    {
    
        private Basket _basket;
        [SetUp]
        public void SetUp()
        {
            _basket = new Basket();
        }

        [Test]
        public void Add()
        {
            
            bool resultTrue = _basket.Add("BGLO");
            bool resultFalse = _basket.Add("wrong");
            _basket.Add("BGLP");
            _basket.Add("BGLP");
            _basket.Add("BGLP");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsTrue(_basket.basket.Any(item => item.SKU == "BGLO"));
        }
        [Test]
        public void Remove()
        {
            _basket.Add("BGLO");
            bool resultTrue = _basket.Remove("BGLO");
            bool resultFalse = _basket.Remove("wrong");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(_basket.basket.Any(item => item.SKU == "BGLO"));
        }
        [Test]
        public void EditSize()
        {
            
            Manager manager = new Manager();
            Assert.IsTrue(manager.AlterSize(_basket,4));
            
            
        }
        [Test]
        public void Calculate()
        {
            _basket.Add("BGLO");
            _basket.Add("COFB");

            Assert.AreEqual(_basket.Sum(), 1.25d);
        }

        [Test]
        public void Discount1()
        {
            _basket.Add("BGLO");
            _basket.Add("BGLO");
            _basket.Add("BGLO");
            _basket.Add("BGLO");
            _basket.Add("BGLO");
            _basket.Add("BGLO");

            Assert.AreEqual(Math.Round(2.49d,2),_basket.Sum());
        }
        [Test]
        public void Discount2() {

            for (int i = 0; i < 16; i++)
            {
                _basket.Add("BGLP");
            }

            Assert.AreEqual(Math.Round(5.55d,2),_basket.Sum());
        }
        [Test]
        public void Discount3()
        {
            _basket.Add("BGLO");
            _basket.Add("COFB");

            Assert.AreEqual(Math.Round(1.25d,2),_basket.Sum());
        }
        [Test] public void CheckBagelDiscount()
        {
            for (int i = 0; i < 8; i++)
            {
                _basket.Add("BGLO");
                _basket.basket[i].AddFilling(new Product("FILB",0.12d,Product.pType.Filling,"Bacon"));
            }
            var result = _basket.checkDiscountsBagels();
            Assert.IsTrue(result.Item1.Any(t => t.SKU == "FILB"));
            Assert.IsTrue(result.Item2.Any(s => s.amountRequired == 6));

        }

        [Test]
        public void Move()
        {
            _basket.Add("BGLO");

            _basket.MoveProduct("BGLO", 1);
            Assert.IsTrue(_basket.discountBasket.Count > 0);
            Assert.IsTrue(_basket.discountBasket.Any(t => t.SKU == "BGLO"));
        }

    }
}
