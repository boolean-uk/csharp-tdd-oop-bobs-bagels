using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using static exercise.main.Products.Filling;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {
        private readonly List<Filling> _fillings = [];

        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public int BulkSize { get; set; }
        public decimal BulkDiscountPrice { get; set; }

        public Bagel(string sku,  decimal price, string name, string variant)
        {
            SKU = sku ;
            Price = price ;
            Name = name ;
            Variant = variant ;
            BulkSize = 0 ;
            BulkDiscountPrice = 0 ;
        }

        public Bagel(string sku, decimal price, string name, string variant, int bulkSize, decimal bulkDiscountPrice)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
            BulkSize = bulkSize;
            BulkDiscountPrice = bulkDiscountPrice;
        }

        public void AddFilling(Filling filling)
        {
            _fillings.Add(filling);
        }

        public List<Filling> Fillings
        {
            get { return _fillings; }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal total = Price;
                foreach (var filling in _fillings)
                {
                    total += filling.Price;
                }
                return total;
            }
        }

        
    }


}
