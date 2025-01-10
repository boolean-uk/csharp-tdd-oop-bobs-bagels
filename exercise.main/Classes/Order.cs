using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Order
    {
        private Guid _id;
        private List<OrderLine> _lines;
        public Order() 
        {
            _id = Guid.NewGuid();
        }

        public void AddLine(OrderLine line) { }

    }
}
