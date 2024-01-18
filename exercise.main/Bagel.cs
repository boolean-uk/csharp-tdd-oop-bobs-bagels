using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        Dictionary<float, string> fillingPrices = new Dictionary<float, string>();
        List<Filling> bagelFilling;
        public Bagel(string SKU, float price, string type, string variant) : base(SKU, price, type, variant)
        {

        }
        public void showFillingPrices()
        {
            
        }
    }
}
