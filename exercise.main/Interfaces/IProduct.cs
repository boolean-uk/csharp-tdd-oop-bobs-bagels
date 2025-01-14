using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    using System;
    using exercise.main.Enums;

    public interface IProduct
    {
        double Price { get; set; }
        string SKU { get; set; }
        string Variant { get; set; }
        ProductType Type { get; set; }
    }
}
