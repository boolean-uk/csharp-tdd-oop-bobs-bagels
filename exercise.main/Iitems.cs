using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Iitems
    {
        string Sku { set; get; }
        decimal Price { set; get; }
        string Name { set; get; }
        string Variant { set; get; }

    }
}
