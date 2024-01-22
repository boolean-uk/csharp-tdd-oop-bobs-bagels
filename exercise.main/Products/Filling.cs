using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{

    public class Filling : Product,InventoryProduct
        {
       
        public Filling(string sku, string variant, double price)
        {
            Name = "Filling";
            Sku = sku;
            Variant = variant;
            Price = price;

        }
        public Filling(string sku)
        {
            Name = "Filling";
            getItemMembers(sku);
        }
        public Filling()
        {
            Name = "Filling";
            getItemMembers("FILB");
        }



    }
    }



