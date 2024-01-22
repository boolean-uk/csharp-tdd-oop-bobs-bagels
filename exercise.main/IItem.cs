using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    interface IItem
    {
        public abstract string ID { get; }
        public abstract string SKU { get; }
        public abstract string Name { get; }
        public abstract string Variant { get; }
        public abstract float Price { get; }

    }
}
