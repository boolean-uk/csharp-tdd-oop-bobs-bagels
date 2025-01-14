using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public interface IProduct
    {
        string Sku {  get; set; }
        double Price { get; set; }
        string Type { get; set; }
        string Variant {  get; set; }

    }
}
