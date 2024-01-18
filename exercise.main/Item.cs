using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{
   public class Item
{
    public string Name { get; set;}
    public string SKU { get; set; }
    public string Variant { get; set; }
    public float Price { get; set; }

    public Item(string sku, string name, string variant, float price)
    {
        SKU = sku;
        Name = name;
        Variant = variant;
        Price = price;
    }
}

}


