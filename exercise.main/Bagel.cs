using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Bagel : Item
    {
        public BagelOffer Offer { get; }
        public List<double> Savings { get; } = new List<double> { 0 };

        public Bagel(string sku, double price, string variant, BagelOffer offer)
            : base(sku, "Bagel", variant, price)
        {
            Offer = offer;
        }


        public override double CalculateCost(int quantity)
        {
            if (Offer != null && quantity >= Offer.Quantity)
            {
                int numberOfDiscounts = quantity / Offer.Quantity;
                int remainingItems = quantity % Offer.Quantity;

                double discountedCost = numberOfDiscounts * Offer.OfferPrice + remainingItems * Price;
                double noDiscountedCost = quantity * Price;
                Savings.Add(noDiscountedCost);
                return discountedCost;
            }

            return Price * quantity;
        }

    }
}
