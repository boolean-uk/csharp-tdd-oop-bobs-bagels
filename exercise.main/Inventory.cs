using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace exercise.main
{
    public class Inventory : Product
    {
        public string variant { get; set; }

        public Inventory(string SKU, double price, string name, string variant) : base(SKU, price, name)
        {
          this.variant = variant;
        }
    }
}
