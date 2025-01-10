using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Item
    {
        public Coffee(string SKU, string name, double cost, string variant) : base(SKU, name, cost, variant)
        {
            this.SKU = SKU;
            this.name = name;
            this.cost = cost;
            this.variant = variant;
        }
    }
}
