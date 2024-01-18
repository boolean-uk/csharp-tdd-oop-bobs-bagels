using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class BagelOffer
    {
        public int Quantity { get; }
        public double OfferPrice { get; }

        public BagelOffer(int quantity, double offerPrice)
        {
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
        public double CalculateDiscount(int quantity)
        {
            int numberOfDiscounts = quantity / Quantity;
            int remainingItems = quantity % Quantity;
            return numberOfDiscounts * OfferPrice + remainingItems * (OfferPrice / Quantity);
        }

    }
}

