using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tdd_oop_bobs_bagels.CSharp.Source
{
    public class BobsBagelsApp
    {


        public BobsBagelsApp()
        {
            InventoryItem item1 = new InventoryItem() { SKU ="BGLO", Price = 0.49M, Name = "Bagel", Variant = "Onion"};
            InventoryItem item2 = new InventoryItem() { SKU ="BGLP", Price = 0.39M, Name = "Bagel", Variant = "Plain"};
            InventoryItem item3 = new InventoryItem() { SKU ="BGLE", Price = 0.49M, Name = "Bagel", Variant = "Everything"};
            InventoryItem item4 = new InventoryItem() { SKU ="BGLS", Price = 0.49M, Name = "Bagel", Variant = "Sesame"};
            InventoryItem item5 = new InventoryItem() { SKU ="COFB", Price = 0.99M, Name = "Coffee", Variant = "Black"};
            InventoryItem item6 = new InventoryItem() { SKU ="COFW", Price = 1.19M, Name = "Coffee", Variant = "White"};
            InventoryItem item7 = new InventoryItem() { SKU ="COFC", Price = 1.29M, Name = "Coffee", Variant = "Capuccino"};
            InventoryItem item8 = new InventoryItem() { SKU ="COFL", Price = 1.29M, Name = "Coffee", Variant = "Latte"};
            InventoryItem item9 = new InventoryItem() { SKU ="FILB", Price = 0.12M, Name = "Filling", Variant = "Bacon"};
            InventoryItem item10 = new InventoryItem() { SKU ="FILE", Price = 0.12M, Name = "Filling", Variant = "Egg"};
            InventoryItem item11 = new InventoryItem() { SKU ="FILC", Price = 0.12M, Name = "Filling", Variant = "Cheese"};
            InventoryItem item12 = new InventoryItem() { SKU ="FILX", Price = 0.12M, Name = "Filling", Variant = "Cream Cheese"};
            InventoryItem item13 = new InventoryItem() { SKU ="FILS", Price = 0.12M, Name = "Filling", Variant = "Smoked Salmon"};
            InventoryItem item14 = new InventoryItem() { SKU ="FILH", Price = 0.12M, Name = "Filling", Variant = "Ham"};
            
            this.stock.Add(item1);
            this.stock.Add(item2);
            this.stock.Add(item3);
            this.stock.Add(item4);
            this.stock.Add(item5);
            this.stock.Add(item6);
            this.stock.Add(item7);
            this.stock.Add(item8);
            this.stock.Add(item9);
            this.stock.Add(item10);
            this.stock.Add(item11);
            this.stock.Add(item12);
            this.stock.Add(item13);
            this.stock.Add(item14);
        }



        public List<string> basket = new List<string>();
        public int MaxCapacityBasket = 3;
        public void AddProduct(string item)
        {
            if (this.basket.Count < this.MaxCapacityBasket)
            {
                basket.Add(item);
            }
        }

        public string ChangeBasketCapacity(int count)
        {
            // if basket.count < count
            if (basket.Count < count)
            {
                MaxCapacityBasket = count;
                return $"The new basketsize is {count}";
            }
            else
            {
                return $"There are more items in the basket than {count}";
            }
            //else basket.count > count either remove items from existing basket or give back message
        }

        public string RemoveProduct(string item)
        {
            if (basket.Contains(item))
            {
                basket.Remove(item);
                return $"{item} removed";
            }
            else
            {
                return "Item not found";
            }
        }

        private List <InventoryItem> stock = new List<InventoryItem>();
    }
}
