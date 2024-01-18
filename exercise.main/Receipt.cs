using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private float _total;
        List<Item> order;
        public Receipt(float total)
        {
            _total = total;
            order = new List<Item>();
        }
        public string showTotal(float total)
        {
            return $"Your total comes to: {total}";
        }
    }
}
