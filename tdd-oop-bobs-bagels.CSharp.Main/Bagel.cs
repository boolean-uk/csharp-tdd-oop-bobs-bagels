using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{   
  public class Bagel
  {
    public string SKU { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public Bagel(string sku, string name, double price)
    {
        SKU = sku;
        Name = name;
        Price = price;
    } 
  }
}
