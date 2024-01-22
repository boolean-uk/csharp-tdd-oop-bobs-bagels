using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using exercise.main.Products;

namespace exercise.main
{
    public interface InventoryProduct
    {
        public string Sku { get;  }
        public string Name { get; }
        public string Variant { get; }
        public double Price { get; }
        public int ID { get; set; }

    }
   
}
