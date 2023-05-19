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
        Inventory inventory = new Inventory();
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

        public void AddItemToBasket(ShopItem item, int amount)
        {
            foreach(ShopItem i in inventory.InventoryList)
            {
                if (i.Variant == item.Variant) 
                {
                    if (this.ShoppingBasket.Count < this.ShoppingBasketMax)
                    {
                        this.ShoppingBasket.Add(item);
                        this.ShoppingBasket.LastOrDefault(i => i.Variant == item.Variant).Amount = amount;
                    }
                    else if (this.ShoppingBasket.Count >= this.ShoppingBasketMax)
                    {
                        Console.WriteLine("Basket is full!");
                    }
                }
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
            
            decimal test = 0;
            foreach (var item in this.ShoppingBasket)
            {
                if (item.SKU == "BGLO" && item.Amount >= 6 || item.SKU == "BGLE" && item.Amount >= 6)
                {
                    int modulo = item.Amount % 6;
                    int amountOfDiscounts = (item.Amount - modulo) / 6;
                    decimal PriceNormal = modulo * item.Price;
                    decimal PriceDiscount = amountOfDiscounts * 2.49m;
                    test += PriceDiscount + PriceNormal;
                    
                } else if (item.SKU == "BGLP" && item.Amount >= 12)
                {
                    int modulo = item.Amount % 12;
                    int amountOfDiscounts = (item.Amount - modulo) / 12;
                    decimal PriceNormal = modulo * item.Price;
                    decimal PriceDiscount = amountOfDiscounts * 3.99m;
                    test += PriceDiscount + PriceNormal;
                } else
                
                {
                    test += item.Amount * item.Price;
                }

                

            }
            return test;

/*
            decimal total = 0;
            foreach (var item in this.ShoppingBasket)
            {
                total += item.Price * item.Amount;
            }
            return total;*/

        }

        public void AddFilling(ShopItem Bagel, ShopItem Filling)
        {
            if (Bagel.Name == "Bagel")
            {
                ShoppingBasket.FirstOrDefault(i => i.SKU == Bagel.SKU).Extras.Add(Filling);
            }
        }

        
        public List<ShopItem> ShoppingBasket { get; set; } = new List<ShopItem>();
        public int ShoppingBasketMax { get; set; } = 4;

    }

    
}
