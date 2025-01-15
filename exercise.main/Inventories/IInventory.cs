using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Inventories
{
    internal interface IInventory
    {
        bool IsInStock(Product p);
        double GetPrice(Product p);
    }
}
