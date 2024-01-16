using exercise.main.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public class Bagel(BagelVariant variant) : Food<BagelVariant>(variant)
    {
        public override string Name => "Bagel";
        public override string Sku
        {
            get
            {
                return "BGL" + Variant.ToString().ToUpper()[..1];
            }
        }
    }
}
