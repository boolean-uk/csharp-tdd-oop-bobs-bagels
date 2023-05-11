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

        public void InventoryListData()
        {
            this.InventoryList.Add(new ShopItems() { Name = "Onion"});
            this.InventoryList.Add(new ShopItems() { Name = "Plain" });
            this.InventoryList.Add(new ShopItems() { Name = "Everything" });
            this.InventoryList.Add(new ShopItems() { Name = "Sesame" });           
        }

        public void AddItemToBasket(ShopItems item)
        {
            this.ShoppingBasket.Add(item);
        }

        public List<ShopItems> InventoryList { get; set; } = new List<ShopItems>();
        public List<ShopItems> ShoppingBasket { get; set; } = new List<ShopItems>();

    }

    
}
