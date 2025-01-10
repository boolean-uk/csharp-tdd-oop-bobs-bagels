using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Basket
    {

        private readonly DiscountService _discountService = new DiscountService();

        public List<Product> Products { get; set; }
        public int Capacity { get; set; }
        public Basket(int capacity) {
            Capacity = capacity;
            Products = new List<Product>();
        }
        public bool Add(Product product)
        {
            if (Products.Count < Capacity)
            {
                Products.Add(product);
                return true;
            }
            return false;
        }

        public decimal GetTotalPrice()
        {
           return GetListPrice(Products);
        }

        private decimal GetListPrice(List<Product> products)
        {
            return products.Sum(p =>
            {
                decimal price = 0;
                if (p is Bagel bagel)
                {
                    return bagel.GetTotalPrice();
                }
                else
                {
                    return p.Price;
                }
            });
        }

        public decimal GetPriceWithDiscounts()
        {
            List<Product> restProducts;
            var specialOffers = _discountService.checkForDiscounts(Products, out restProducts);
            decimal restPrice = GetListPrice(restProducts);
            decimal specialOfferPrice = GetSpecialOfferPrice(specialOffers);
            return restPrice + specialOfferPrice;
        }
        private decimal GetSpecialOfferPrice(List<SpecialOffer> specialOffers)
        {
            return specialOffers.Sum(o => o.Price);
        }

        public bool Remove(Bagel bagel)
        {
           if(Products.Contains(bagel))
            {
                Products.Remove(bagel);
                return true;
            }
            return false;
        }

        public void UpdateCapacity(int capacity, Role role)
        {
            if(role == Role.Manager)
            {
                Capacity = capacity;
            }
            else
            {
                throw new Exception("You are not authorized to update the capacity");
            }
        }

        public void clear()
        {
            Products.Clear();
        }
    }
}
