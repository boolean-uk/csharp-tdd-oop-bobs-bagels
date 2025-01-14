using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IItem
    {

        string Sku { get; }
        double Price { get;  }
        string Name { get; }
        string Variant { get; }
        
    }
}
