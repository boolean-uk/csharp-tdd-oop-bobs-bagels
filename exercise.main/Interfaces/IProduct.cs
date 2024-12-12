using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    public interface IProduct
    {
        int ID { get; set; }
        string SKU { get; set; }
        double Price { get; set; }

        string Name { get; set; }
        string Variant { get; set; }

        List<IAddition> Additions { get; set; }
    }
}
