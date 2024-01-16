using exercise.main.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public class Bagel : Food<BagelVariant>
    {
        public Bagel()
        {
        }

        public Bagel(BagelVariant variant) : base(variant)
        {
        }

        public string Name => "Bagel";
    }
}
