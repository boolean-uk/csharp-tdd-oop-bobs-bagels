using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        public string SKU {  get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
    }
}
