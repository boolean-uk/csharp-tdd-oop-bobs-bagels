using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IProduct
    {
        string Sku { get; }
        decimal Price { get; }
    }
}