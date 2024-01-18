using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public static class ProductFactory
    {
        /// <summary>
        /// Ensure that the provided SKU is valid then returns a new IProduct object that match the provided SKU
        /// </summary>
        /// <param name="SKU"> Inventory item identifier </param>
        /// <returns><IProduct>The generated IProduct object based on the provided SKU. If invalid SKU the object will be a </IProduct></returns>
        public static IProduct GenerateProduct(string[] SKU) 
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


        /// <summary>
        /// Validate if the provided SKU is a valid SKU in for any item in bobs inventory that implements IProduct
        /// </summary>
        /// <param name="SKU"> The SKU to check is valid or not</param>
        /// <returns><bool> True if the SKU is valid, false if invalid </bool></returns>
        public static bool ValidateProductSKU(string SKU) 
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
