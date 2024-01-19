using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IInventory
    {
        bool IsItemInStock(string sku);
        decimal GetProductPrice(string sku); // 7. As a customer, So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
        Product GetFilling(string sku);
        Product GetProduct(string sku);
       
    }
}