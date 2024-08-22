using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.products
{
    public class Bagle : Product
    {
        private float cost;
        private string name;
        private productType type;

        public Bagle(productType bt)
        {

            if (bt == productType.BGLO)
            {
                cost = 0.49f;
                name = "Onion Bagle";
                type = productType.BGLO;
            }
            else if (bt == productType.BGLP)
            {
                cost = 0.39f;
                name = "Plain Bagle";
                type = productType.BGLP;
            }
            else if (bt == productType.BGLE)
            {
                cost = 0.49f;
                name = "Everything Bagle";
                type = productType.BGLE;
            }
            else if (bt == productType.BGLS)
            {
                cost = 0.49f;
                name = "Sesame Bagle";
                type = productType.BGLS;
            }
            else
            {
                throw new NotSupportedException("Incorrect input");
            }

        }

        public override string Name { get { return name; } }
        public override productType Type { get { return type; } }
        public override float Cost { get { return cost; } }

    }
}


