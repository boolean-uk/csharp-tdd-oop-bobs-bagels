using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_tdd_oop_bobs_bagels_Csharp_Classes;

namespace csharp_tdd_oop_bobs_bagels_Csharp_Classes
{
    public class Basket
    {
        public Basket() 
        {

        }

        public void TestData()
        {
            ShoppingBasket.Add( new ShopItem("BGLO", "Onion", 0.49m, "Bagel"));
            ShoppingBasket.Add( new ShopItem("BGLP", "Plain", 0.39m, "Bagel"));
            ShoppingBasket.Add( new ShopItem("BGLE", "Everything", 0.49m, "Bagel"));
            ShoppingBasket.Add(new ShopItem("BGLS", "Sesame", 0.49m, "Bagel"));
        }

        public void AddItemToBasket(ShopItem item)
        {
            if (this.ShoppingBasket.Count < this.ShoppingBasketMax) 
            {
                this.ShoppingBasket.Add(item);
            } else if (this.ShoppingBasket.Count >= this.ShoppingBasketMax)
            {
                Console.WriteLine("Basket is full!");
            }
            
        }

        public bool RemoveItemFromBasket(string SKU)
        {
            var itemToRemove = this.ShoppingBasket.FirstOrDefault(x => x.SKU == SKU);
            if (itemToRemove != null) 
            {
                return this.ShoppingBasket.Remove(itemToRemove) ? true : false;
            }
            return false;
        }

        public void SetBasketMax(int value)
        {
            // if role is manager
            if(this.ShoppingBasket.Count < value)
            {
                ShoppingBasketMax = value;
            } else
            {
                Console.WriteLine("Basket size cant be smaller than current items in Basket");
            }
            
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in this.ShoppingBasket)
            {
                total += item.Price;
            }
            return total;

        }

        public void AddFilling(string v, ShopItem item1)
        {
            throw new NotImplementedException();
        }

        public List<ShopItem> InventoryList { get; set; } = new List<ShopItem>();
        public List<ShopItem> ShoppingBasket { get; set; } = new List<ShopItem>();
        public int ShoppingBasketMax { get; set; } = 5;

    }

    
}
