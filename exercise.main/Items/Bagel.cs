using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Bagel : Item
    {
        public Bagel() 
        {
            
        }
        public Bagel(string sku) : base(sku) 
        { 

        }
        
        public Bagel(string sku, double price, string variant) : base(sku, price, variant) 
        { 

        }
    }
}
