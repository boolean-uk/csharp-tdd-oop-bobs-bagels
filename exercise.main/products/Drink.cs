using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.products
{

    public class Drink : Product
    {
        private float cost;
        private string name;
        private productType type;
        public Drink(productType dt)
        {

            if (dt == productType.COFB)
            {
                cost = 0.99f;
                name = "Black Coffe";
                type = productType.COFB;
            }
            else if (dt == productType.COFW)
            {
                cost = 1.19f;
                name = "White Coffe";
                type = productType.COFW;
            }
            else if (dt == productType.COFC)
            {
                cost = 1.29f;
                name = "Capuccino";
                type = productType.COFC;
            }
            else if (dt == productType.COFL)
            {
                cost = 1.29f;
                name = "Latte";
                type = productType.COFL;
            }
            else
            {
                throw new NotSupportedException("Incorrect input");
            }
        }
        public override productType Type { get { return type; } }

        public override string Name { get { return name; } }
        public override float Cost { get { return cost; } }

    }

}
