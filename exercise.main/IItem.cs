using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IItem
    {

        string sku { get; }
        double price { get;  }
        string name { get; }
        string variant { get; }
        
    }
}
