using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class ReceiptTest
    {
        [Test]
        public void PrintReceiptTest()
        {

            using (StringWriter sw = new StringWriter())
            {
                //arrange
                Console.SetOut(sw);
                Basket basket = new Basket();
                basket.AddItem("COFW");
                basket.AddItem("BGLO");
                basket.AddItem("FILE");
                Receipt receipt = new Receipt(basket, DateTime.UtcNow);

                //act
                receipt.PrintReceipt();
                string expected = "~~~ Bob's Bagels ~~~";

                //assert
                Assert.Pass();
            }



        }
    }
}
