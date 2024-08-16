using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Item
    {
        
        string Sku { get; set; }
        double Price { get; set; }
        string Name { get; set; }
        string Variant { get; set; }

        int CheckItemCost();

    }
}
