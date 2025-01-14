using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IProduct
    {
        string SKU { get; set; }
        decimal Price { get; set; }
        string Name { get; set; }
        string Variant { get; set; }

        decimal TotalPrice 
        {  
            get => Price;
        }

    }
}
