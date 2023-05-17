using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main.Products
{
    public interface Items
    {
        string sku { get; set; }
        float price { get; set; }
        string variant { get; set; }
    }
}
