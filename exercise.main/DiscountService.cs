using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Models;

namespace exercise.main
{
    public class DiscountService
    {
        public List<SpecialOffer> checkForDiscounts(List<Product> products, out List<Product> restProducts) 
        {
            restProducts = new List<Product>();
            List<SpecialOffer> specialOffers = new List<SpecialOffer>();
            List<SpecialOffer> newOffers = new List<SpecialOffer>();

            //These should return several discounts for each search
            hasDiscount12(products, 12, out restProducts, out newOffers);
            specialOffers.AddRange(newOffers);
            hasDiscount6(restProducts, 6, out restProducts, out newOffers);
            specialOffers.AddRange(newOffers);

            //A lazier way to check for multiple discounts
            bool coffeeOffer = true;
            while (coffeeOffer)
            {
                coffeeOffer = hasDiscountCoffeeBagel(restProducts, restProducts, out newOffers);
                specialOffers.AddRange(newOffers);
            }
            return specialOffers;
        }
        private bool hasDiscount6(List<Product> products, int quantity, out List<Product> restProducts, out List<SpecialOffer> discounts)
        {
            return hasDiscountGeneric(products, 6, out restProducts, out discounts);
        }

        private bool hasDiscount12(List<Product> products, int quantity, out List<Product> restProducts, out List<SpecialOffer> discounts)
        {
            return hasDiscountGeneric(products, 12, out restProducts, out discounts);
        }

        //Uh oh, its getting messy
        private bool hasDiscountGeneric(List<Product> products, int quantity, out List<Product> restProducts, out List<SpecialOffer> discounts)
        {
            bool hasDiscount = products.Where(p => p.SKU.StartsWith("BGL")).Count() >= quantity;
            discounts = new List<SpecialOffer>();

            if (!hasDiscount)
            {
                restProducts = products;
                return false;
            }
            //List of products that are not included in the discount
            restProducts = new List<Product>();
            restProducts.AddRange(products);
            while (hasDiscount)
            {
                int count = 0;
                foreach (Product product in products)
                {
                    if (product.SKU.StartsWith("BGL"))
                    {
                        count++;
                        Bagel thisProduct = (Bagel)product;
                        if (count % quantity == 0 && count != 0)
                        {
                            if (quantity == 6)
                            {
                                SpecialOffer specialOffer = new SpecialOffer(SpecialOfferType.sixBagelsDeal);
                                specialOffer.Discount = CalculateDiscountForSingleOffer(products, specialOffer);
                                discounts.Add(specialOffer);
                                restProducts.Remove(product);
                                if(thisProduct.Fillings.Count > 0)
                                {
                                    restProducts.AddRange(thisProduct.Fillings);
                                }
                            }
                            else
                            {
                                SpecialOffer specialOffer = new SpecialOffer(SpecialOfferType.twelveBagelsDeal);
                                specialOffer.Discount = CalculateDiscountForSingleOffer(products, specialOffer);
                                discounts.Add(specialOffer);
                                restProducts.Remove(product);
                                if (thisProduct.Fillings.Count > 0)
                                {
                                    restProducts.AddRange(thisProduct.Fillings);
                                }
                            }
                        }
                        else
                        {
                            if(!(count >= quantity))
                            {
                                restProducts.Remove(product);
                                if (thisProduct.Fillings.Count > 0)
                                {
                                    restProducts.AddRange(thisProduct.Fillings);
                                }
                            }

                        }
                    }

                }
                hasDiscount = restProducts.Where(p => p.SKU.StartsWith("BGL")).Count() >= quantity;
            }
            
                return true;
        }
        

        private bool hasDiscountCoffeeBagel(List<Product> products, List<Product> restProducts, out List<SpecialOffer> discounts) 
        {
            bool hasDiscount = products.Where(p => p.SKU == "COFB").Count() > 0 && products.Where(p => p.SKU == "BGLO" || p.SKU == "BGLP" || p.SKU == "BGLE").Count() > 0;
            if (!hasDiscount)
            {
                restProducts = products;
                discounts = new List<SpecialOffer>();
                return false;
            }
            
            Bagel bagelToRemove = (Bagel)products.Where(p => p.SKU == "BGLP" || p.SKU == "BGLO" || p.SKU == "BGLE").First();
            List<Product> productsInDeal = new List<Product>();
            productsInDeal.Add(bagelToRemove);

            restProducts.Remove(bagelToRemove);
            Coffee coffeeToRemove = (Coffee)products.Where(p => p.SKU == "COFB").First();
            productsInDeal.Add(coffeeToRemove);
            restProducts.Remove(coffeeToRemove);
            restProducts = products;
            if (bagelToRemove.Fillings.Count > 0)
            {
                restProducts.AddRange(bagelToRemove.Fillings);
            }
            discounts = new List<SpecialOffer>();
            SpecialOffer specialOffer = new SpecialOffer(SpecialOfferType.coffeeBagelDeal);
            specialOffer.Discount = CalculateDiscountForSingleOffer(productsInDeal, specialOffer);
            discounts.Add(specialOffer);
            return true;
        }

        private decimal CalculateDiscountForSingleOffer(List<Product> products, SpecialOffer specialOffer)
        {
            return products.Sum(p => p.Price) - specialOffer.Price;
        }

        public decimal GetTotalDiscount(List<SpecialOffer> products)
        {
            return products.Sum(o =>  o.Discount);
        }
    }
}
