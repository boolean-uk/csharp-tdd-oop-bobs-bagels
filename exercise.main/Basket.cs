using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise
{
    public class Basket
    {
        private Inventory inventory = new Inventory();
        public List<Product> products { get; set; } = new List<Product>();

        public int MaxCapacity { get; set; } = 3;

        public bool AddProduct(string sku)
        {
            if (products.Count() == MaxCapacity)
            {
                return false; //Basket is full
            }
                
            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return false; //Product doesn't exist
            
            products.Add(item);
            return true;
        }

        public bool RemoveProduct(string sku)
        {
            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return false;

            if (!products.Contains(item))
            {
                Console.WriteLine($"Could not find {item.Variant} in your basket.");
                return false;
            }

            products.Remove(item);
            return true;
        }

        public decimal GetTotalCost()
        {
            decimal total = 0;
            products.ForEach(product => total += product.Price);

            return total;
        }

        public decimal GetPrice(string sku)
        {
            Product? item = inventory.Items.Find(item => item.SKU == sku);

            if (item == null)
                return 0;

            return item.Price;
        }

    }
}
