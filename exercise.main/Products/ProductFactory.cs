using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public static class ProductFactory
    {
        public static Product GenerateProduct(string[] SKU) 
        {
            ValidateProductSKU(SKU[0]);
            float prod1 = Inventory.GetCoffePrice(SKU[0]);
            float prod2 = Inventory.GetBagelPrice(SKU[0]);

            if (prod1 > 0f)
            {
                return new Coffee(SKU[0], prod1);
            }
            else 
            {
                Bagel bagel = new Bagel(SKU[0], prod2);
                for (int i = 1; i < SKU.Length; i++) 
                {
                    Filling fill = new Filling(SKU[i]);
                    if (fill.IsValid(SKU[i])) 
                    {
                        bagel.AddFilling(fill);
                    }
                }
                return bagel;
            }
        }

        private static bool ValidateProductSKU(string SKU) 
        {
            float prod1 = Inventory.GetCoffePrice(SKU);
            float prod2 = Inventory.GetBagelPrice(SKU);
            if ((prod1 == 0f) && (prod2 == 0f))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}
