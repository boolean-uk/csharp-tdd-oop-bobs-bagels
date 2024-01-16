using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class ProductFactory
    {
        public Product GenerateProduct(string[] SKU) 
        {
            ValidateProductSKU(SKU[0]);
            throw new NotImplementedException();
        }

        private bool ValidateProductSKU(string SKU) 
        {
            throw new NotImplementedException();
        }
    }
}
