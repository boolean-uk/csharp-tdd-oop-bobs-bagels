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
            this.ShoppingBasket.Add(new ShopItem() { Name = "Onion"});
            this.ShoppingBasket.Add(new ShopItem() { Name = "Plain" });
            this.ShoppingBasket.Add(new ShopItem() { Name = "Everything" });
            this.ShoppingBasket.Add(new ShopItem() { Name = "Sesame" });           
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

        public bool RemoveItemFromBasket(string name)
        {
            var itemToRemove = this.ShoppingBasket.FirstOrDefault(x => x.Name == name);
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

        public List<ShopItem> InventoryList { get; set; } = new List<ShopItem>();
        public List<ShopItem> ShoppingBasket { get; set; } = new List<ShopItem>();
        public int ShoppingBasketMax { get; set; } = 5;

    }

    
}
