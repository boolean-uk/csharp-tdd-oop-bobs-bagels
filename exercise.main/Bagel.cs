using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum BagelType { Onion, Plain, Everything, Sesame };
    public class Bagel : Product
    {
        Dictionary<BagelType, (double price, string SKU)> bagelToInfo = new Dictionary<BagelType, (double price, string SKU)>() 
        {
            { BagelType.Onion, ( 0.49d, "BGLO") },
            { BagelType.Plain, ( 0.39d, "BGLP") },
            { BagelType.Everything, (0.49d, "BGLE") },
            { BagelType.Sesame, (0.49d, "BGLS") }
        };

        public List<Filling> filling { get;  } = new List<Filling>();
        BagelType _bagelType;

        public Bagel(BagelType bagel)
        {
            _bagelType = bagel;
            price = bagelToInfo[bagel].price;
            SKU = bagelToInfo[bagel].SKU;
        }

        public override double GetPrice()
        {
            return price + filling.Sum(x => x.price);
        }

        public void Add(Filling filling)
        {
            throw new NotImplementedException();
        }
    }
}