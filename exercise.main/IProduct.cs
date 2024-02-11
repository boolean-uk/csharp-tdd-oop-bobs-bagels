using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IProduct
    {
        string SKU { get; }
        double Price { get; }
        string Variant { get; }
    }
}
