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


        public Bagel(string variant) : base(0, "", "", "")
        {
            this.Variant = variant;
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

    }

}