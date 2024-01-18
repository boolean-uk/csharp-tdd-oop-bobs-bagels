using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private Dictionary<string, List<Product>> items;
        private int capacity;

        public Basket()
        {
            items = new Dictionary<string, List<Product>>();
            capacity = 15;
        }
        public Dictionary<string, List<Product>> Items { get { return items; } }


        public void Add(Product product)
        {
            string sku = product.SKU;

            {
                if (!items.ContainsKey(sku))
                {
                    items.Add(sku, new List<Product>());
                }

                if (Items[sku].Count < capacity)
                {
                    Items[sku].Add(product);
                }
                else
                {
                    throw new Exception("Your basket is full");
                }
            }
        }
            public void Remove(string sku)
            {
            if (items.ContainsKey(sku))
            {
                items.Remove(sku);
            }
            else
            {
                throw new Exception("Product is not in basket");
            }
        }
            public void IncreaseCapacity()
            {
                capacity++;
            }
            public decimal GetTotalCost(Inventory inventory)
            {
                decimal totalCost = 0;
            
                foreach (var entry in items)
                {
                    string sku = entry.Key;
                    int quantity = entry.Value.Count;
                    decimal productPrice = inventory.Products.First(p => p.SKU == sku).Price;
                switch (sku)
                {
                    case "BGLO":
                    case "BGLE":
                        int TwelveBagelDiscount = quantity / 12;
                        int SixBagelDiscount = (quantity % 12) / 6;
                        int ExtraBagels = quantity % 6;
                        totalCost += TwelveBagelDiscount * 2.49m + SixBagelDiscount * 2.49m + ExtraBagels * productPrice;
                        break;

                    case "BGLP":
                        int TwelveBagelDiscountBGLP = quantity / 12;
                        int SixBagelDiscountBGLP = (quantity % 12) / 6;
                        int ExtraBagelsBGLP = quantity % 6;
                        totalCost += TwelveBagelDiscountBGLP * 3.99m + SixBagelDiscountBGLP * 2.49m + ExtraBagelsBGLP * productPrice;
                        break;

                    case "COFB":
                        if (items.Keys.Any(bagelSku => bagelSku.StartsWith("BGL")))
                        {
                            int discountedSetsCOFB = quantity / 1;
                            totalCost += discountedSetsCOFB * 1.25m;
                        }
                        else
                        {
                            totalCost += quantity * productPrice;
                        }
                        break;

                    default:
                        totalCost += quantity * productPrice;
                        break;
                }
            }

                return totalCost;
            }
        }

    
}  


