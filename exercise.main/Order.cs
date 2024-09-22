using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Order
    {
        private DateTime _orderDate;
        private DateTime _deliveryDate;
        private int _deliveryTime;
        private Receipt _belongingReceipt;

        public Order(Receipt receipt)
        {
            _orderDate = DateTime.Now;
            _deliveryTime = new Random().Next(10, 30);
            _deliveryDate = _orderDate.AddMinutes(_deliveryTime);
            _belongingReceipt = receipt;
        }        

        public DateTime OrderDate { get { return _orderDate; } }
        public DateTime DeliveryDate { get { return _deliveryDate; } }
        public int DeliveryTime { get { return _deliveryTime; } }
        public Receipt BelongingReceipt { get { return _belongingReceipt; } }
    }
}
