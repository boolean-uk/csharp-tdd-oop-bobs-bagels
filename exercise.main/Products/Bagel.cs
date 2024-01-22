using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main.Products
{
    public class Bagel : Product, InventoryProduct
    {
        public List<Filling> Fillings = new List<Filling>();

        public Bagel(string sku, string variant, double price)
        {
            Name = "Bagel";
            Sku = sku;
            Variant = variant;
            Price = price;

        }
        public Bagel(string sku)
        {
            Sku = sku;
          getItemMembers(sku);
        }

        public bool AddFilling(Filling filling)
        {
            Fillings.Add(filling);
            return true;
        }
        public List<Filling> ListOfFillings { get => Fillings; set => Fillings = value; }
        
    }
}