using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using tdd_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Item
    {
        public string Name, SKU, Variant;
        public float Price;

        public Item(string sku, string name, string variant, float price)
        {
            this.SKU = sku;
            this.Name = name;
            this.Variant = variant;
            this.Price = price;
        }
    }
    public class Inventory
    {
        private Dictionary<string, Item> bageles = new Dictionary<string, Item>{
            {"1", new Item("BGLP", "Bagel", "plain", 1.00f)},
            {"2", new Item("BGLS", "Bagel", "Sesame", 1.10f)},
            {"3", new Item("BGLC", "Bagel", "Cinnamon", 1.20f)}
        };
        private Dictionary<string, Item> fillings = new Dictionary<string, Item>{
            {"1", new Item("FILC", "Filling", "Cheese", 0.50f)},
            {"2", new Item("FILJ", "Filling", "Jam", 0.50f)},
            {"3", new Item("FILS", "Filling", "Salmon", 1.00f)}
        };
        private Dictionary<string, Item> coffees = new Dictionary<string, Item>{
            {"1", new Item("COFB", "Coffee", "Black", 1.00f)},
            {"2", new Item("COFW", "Coffee", "White", 2.00f)},
            {"3", new Item("COFL", "Coffee", "Latte", 3.00f)}
        };

        public List<Item> ListBagels()
        {
            return bageles.Values.ToList();
        }
        public List<Item> ListFillings(){
            return fillings.Values.ToList();
        }
        public List<Item> ListCoffees(){
            return coffees.Values.ToList();
        }

        public Item ItemDetails(string sku){
            if(bageles.ContainsKey(sku)){
                return bageles[sku];
            }
            if(fillings.ContainsKey(sku)){
                return fillings[sku];
            }
            if(coffees.ContainsKey(sku)){
                return coffees[sku];
            }
            return null;
        }
        }

    public class Basket
    {
        private Inventory inventory = new Inventory();
        private List<Item> _basket = new List<Item>();
        private Item item;
        private float totalCost;
        private int capacity = 5;

        public bool AddItem(string sku)
        {
            if(_basket.Count < capacity)
            {
                if(inventory.ItemDetails(sku) == null)
                {
                    return false;
                }
                item = inventory.ItemDetails(sku);
                _basket.Add(item);
                return true;
            }
            return false;
        }
        public bool RemoveItem(string sku)
        {
            if(_basket.Count > 0)
            {
                if(inventory.ItemDetails(sku) == null)
                {
                    return false;
                }
                item = inventory.ItemDetails(sku);
                _basket.Remove(item);
                return true;
            }
            return false;
        }
        public float CalculateTotalCost()
        {
            totalCost = 0;
            foreach(Item item in _basket)
            {
                totalCost += item.Price;
            }
            return totalCost;
        }
        public bool SetCapacity(int capacity)
        {
            if(capacity > 0)
            {
                this.capacity = capacity;
                return true;
            }
            return false;
        }
        public float GetPrice(string sku)
        {
            if(inventory.ItemDetails(sku) == null)
            {
                return 0;
            }
            item = inventory.ItemDetails(sku);
            return item.Price;
        }
       /*
        public string GetVariantList(string variant)
        {
            if(inventory.ItemDetails(variant) == null)
            {
                return null;
            }
            item = inventory.ItemDetails(variant);
            return item.Variant;
        }
        */
    }
}


