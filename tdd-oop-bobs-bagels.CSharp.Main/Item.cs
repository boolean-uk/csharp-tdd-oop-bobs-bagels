using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Item
    {

        public string ID;
        public string SKU;
        public float Price;
        public string Name;
        public string Variant;
        public int Quantity;


        public Item(string id, string sku, float price, string name, string variant )
        {
            ID = id;
            SKU = sku;
            Price = price;
            Name = name; 
            Variant = variant;
            Quantity = 0;
        }

        
    }
}
