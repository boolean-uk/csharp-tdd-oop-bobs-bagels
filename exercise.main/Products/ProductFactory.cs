using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class ProductFactory
    {
        public Product GenerateProduct(string SKU) 
        {
            ValidateProductSKU(SKU);
            throw new NotImplementedException();
        }

        public bool ValidateProductSKU(string SKU) 
        {
            throw new NotImplementedException();
        }
    }
}
