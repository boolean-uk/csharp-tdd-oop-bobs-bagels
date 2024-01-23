using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        private Inventory inventory = new Inventory();
        public string Variant { get; private set; }
        public float Price { get; private set; }
        public string SKU { get; private set; }
        public string Name { get; private set; }


        public Bagel(string SKU) : base(0, "", "", "")
        {
            Item bagelprod = inventory.GetProduct(SKU);
            this.Price = bagelprod.Price;
            this.Variant = bagelprod.Variant;
            this.SKU = SKU;
            this.Name = bagelprod.Name;
        }

        public bool AddFillingToBagel(string productSKU, Item filling, out string errorMessage)
        {
            Item product = inventory.GetProduct(productSKU);

            // Check if bagel is in the basket
            if (product.SKU[3] == this.Variant[0])
            {
                // Check if filling starts with 'F'
                if (filling.Name.StartsWith("F"))
                {
                    product.AddSubItems(filling);
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    errorMessage = "Invalid filling type";
                    return false;
                }
            }
            else
            {
                errorMessage = "Bagel not in basket";
                return false;
            }
        }

        public float CalculateTotalCost()
        {
            float totalCost = this.Price; // Start with the bagel's own price

            // Add the cost of each filling
            foreach (Item subItem in GetSubItems())
            {
                totalCost += subItem.Price;
            }

            return totalCost;
        }




    }

}