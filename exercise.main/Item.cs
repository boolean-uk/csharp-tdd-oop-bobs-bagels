using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Item
    {
        int Id { get; }
        string Sku { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Variant { get; set; }


        
    }
}
