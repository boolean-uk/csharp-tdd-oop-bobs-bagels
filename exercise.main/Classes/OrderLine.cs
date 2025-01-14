using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class OrderLine
    {
        private BasketItem _item;
        private int _amount;
        private double _price;
        private double _discount;
        public OrderLine(BasketItem item) 
        {
            _item = item;
        }

    }
}
