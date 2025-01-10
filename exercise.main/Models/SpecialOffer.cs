using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class SpecialOffer : Product
    {
        public SpecialOffer(SpecialOfferType offerType)
        {
            SKU = "SPECIALOFFER";
            Price = price(offerType);
            Variant = offerType.ToString();
        }


        public decimal price(SpecialOfferType offerType)
        {
            if (offerType == SpecialOfferType.sixBagelsDeal)
            {
                return 2.49M;
            }
            else if (offerType == SpecialOfferType.twelveBagelsDeal)
            {
                return 3.99M;
            }
            else if (offerType == SpecialOfferType.coffeeBagelDeal)
            {
                return 1.25M;
            }
            else
            {
                return 0;
            }
        }
    }

    public enum SpecialOfferType
    {
        sixBagelsDeal,
        twelveBagelsDeal,
        coffeeBagelDeal
    }
}
