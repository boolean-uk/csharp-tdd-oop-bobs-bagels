using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private Filling _filling;
        public Filling Filling { get { return _filling; } set { _filling = value; } }

        public Bagel(string sKU) : base(sKU)
        {
            Tuple<string, double, string, string> skuInfo = Store.getSkuInfo(sKU);
        }

        public bool ChooseFilling(Filling filling)
        {
            // If customer chose a filling, but changes their mind and wants another. Totally redundant perhaps.
            if (filling != null)
            {
                // If customer chose a filling, but changes their mind and wants another. Totally redundant perhaps.
                if (_filling != null)
                {
                    Price -= Filling.Price;
                }

                Filling = filling;
                Price += Filling.Price;

                return true;
            }

            return false;
        }
    }

    public class Coffee : Product
    {
        public Coffee(string sKU) : base(sKU)
        {

        }
    }

    public class Filling : Product
    {
        public Filling(string sKU) : base(sKU)
        {

        }
    }
}
