using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    abstract class Filling : Iproduct
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Price { get; set; }
        public string Variant { get; set; }

    }
}
