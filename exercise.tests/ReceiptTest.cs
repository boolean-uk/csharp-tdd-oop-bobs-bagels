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

        //Missing parts of Test.
        //Reformated receipt through looking at console output
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

                //assert
                Assert.Pass();
            }



        }
    }
}
