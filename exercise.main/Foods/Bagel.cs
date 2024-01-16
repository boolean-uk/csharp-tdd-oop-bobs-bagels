using exercise.main.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public class Bagel: Food<BagelVariant>
    {
        public override string Name => "Bagel";
        public override string Sku
        {
            get
            {
                return "BGL" + Variant.ToString().ToUpper()[..1];
            }
        }
        public Filling Filling { get; set; }

        public Bagel(BagelVariant variant) : base(variant) { }

        public Bagel(BagelVariant variant, Filling filling) : base(variant) 
        {
            Filling = filling;
        }

    }
}
