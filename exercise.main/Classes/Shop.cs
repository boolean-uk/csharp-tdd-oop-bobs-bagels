using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Shop
    {
        Inventory inventory = new Inventory();
        public void AskPrice(string sku)
        {
            Console.WriteLine($"Price of {inventory.GetProductVariant(sku)} {inventory.GetProductName(sku)} is {inventory.GetProductPrice(sku)}!");
        }
    }
}
