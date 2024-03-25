using item.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bagel.main
{
    public class Bagel(string sku, double price, string variant) : Item(sku, price, "Bagel", variant) 
    {
        //Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        
    }
}
