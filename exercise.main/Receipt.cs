using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        DateTime _time;
        Basket _basket;
        double _total;
        public Receipt(Basket basket) 
        { 
            _time = DateTime.Now;
            _basket = basket;
            _total = _basket.GetTotal();
        }

        public DateTime Time { get => _time; }
        public List<Product> Items { get => _basket.Items; }
        public double Total { get => _total; }
    }
}
