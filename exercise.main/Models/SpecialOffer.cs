using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class SpecialOffer : Product
    {
        public decimal Discount { get; set; }
        public SpecialOffer(SpecialOfferType offerType)
        {
            SKU = "SPECIALOFFER";
            Price = price(offerType);
            Variant = SpecialOfferTypeExtensions.ToFriendlyString(offerType);
            Discount = 0;
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

        public override string ToString()
        {
            return $"{Variant} - ${Price}\n" +
                $"\t\t(-${Discount})";
        }
    }

    public enum SpecialOfferType
    {
        sixBagelsDeal,
        twelveBagelsDeal,
        coffeeBagelDeal
    }
    public static class SpecialOfferTypeExtensions
    {
        public static string ToFriendlyString(this SpecialOfferType offerType)
        {
            switch (offerType)
            {
                case SpecialOfferType.sixBagelsDeal:
                    return "6 Bagels Deal";
                case SpecialOfferType.twelveBagelsDeal:
                    return "12 Bagels Deal";
                case SpecialOfferType.coffeeBagelDeal:
                    return "Coffee Bagel Deal";
                default:
                    return "Unknown";
            }
        }
    }
}
