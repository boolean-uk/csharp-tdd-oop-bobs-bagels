using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Communication;
using exercise.main.Models;

namespace exercise.main
{
    public class OrderHandler
    {
        public void PlaceOrder(Basket basket, ICommunicator communicator)
        {
            communicator.Send(buildOrderMessage(basket));
        }

        private string buildOrderMessage(Basket basket)
        {
            return "Your order has been placed! \n" +
                "Estimated delivery time: " + DateTime.Now.AddMinutes(45) + "\n" +
                "Your receipt: \n" +
                new Receipt(basket).FullReceipt();
        }
    }
}
