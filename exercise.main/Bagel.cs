using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum BagelType { Plain = 0, Onion = 1, Everything = 2, Sesame = 3 };
    public class Bagel : Product
    {
        public Dictionary<BagelType, (double price, string SKU)> bagelToInfo { get; } = new Dictionary<BagelType, (double price, string SKU)>()
        {
            { BagelType.Onion, ( 0.49d, "BGLO") },
            { BagelType.Plain, ( 0.39d, "BGLP") },
            { BagelType.Everything, (0.49d, "BGLE") },
            { BagelType.Sesame, (0.49d, "BGLS") }
        };

        public List<Filling> _filling { get;  } = new List<Filling>();
        public BagelType bagelType { get; }

        public Bagel(BagelType bagel)
        {
            bagelType = bagel;
            price = bagelToInfo[bagel].price;
            SKU = bagelToInfo[bagel].SKU;
        }

        public override double GetPrice()
        {
            return price + _filling.Sum(x => x.price);
        }

        public void Add(Filling filling)
        {
            _filling.Add(filling);
        }

        public override int itemNr => (int) bagelType;
    }
}