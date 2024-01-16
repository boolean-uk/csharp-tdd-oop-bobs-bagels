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
        private int _limit = 3;
        [SetUp]
        public void SetUp()
        {
            _basket = new Basket(_limit);
        }

        [Test]
        public void TestAdd()
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
        }
        [Test]
        public void TestRemove()
        {
            _basket.Add("BGLO");
            bool resultTrue = _basket.Remove("BGLO");
            bool resultFalse = _basket.Remove("wrong");

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }
    }
}
