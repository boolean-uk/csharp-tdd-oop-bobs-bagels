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
            bool resultOverLimit = _basket.Add("BGLO");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(resultOverLimit);
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
        public void Calculate() { }
    }
}
