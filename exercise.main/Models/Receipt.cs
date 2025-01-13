using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public List<SpecialOffer> SpecialOffers { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public DateTime Date { get; set; }

        public Receipt(Basket basket)
        {
            Products = basket.Products;
            Total = basket.GetPriceWithDiscounts();
            SpecialOffers = basket.SpecialOffers;
            Discount = basket.GetTotalDiscount();
            Date = DateTime.Now;
        }
        public string FullReceipt()
        {
            return $"~~~ Bob's Bagels ~~~ \n" +
                $"Date: {Date} \n" +
                $"----------------------------\r\n" +
                $"Products: \n" +
                $"{string.Join("\n", Products.Select(p => p.ToString()))} \n" +
                $"Special Offers: \n" +
                $"{string.Join("\n", SpecialOffers.Select(p => p.ToString()))} \n" +
                $"----------------------------\r\n" +
                $"Total discount: -$" + Discount.ToString() + "\n" +
                $"Total: {Total} \n";
        }
    }
}
