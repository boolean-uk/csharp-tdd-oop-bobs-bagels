using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel
    {

        public int capacity { get; set; } 

        public List<Inventory> BasketList;

        List<Inventory> InventoryList;

        public Bagel()
        {
            this.BasketList = new List<Inventory>();
            this.InventoryList = new List<Inventory>();
            this.capacity = 30;
            InitializeInventory();
        }
         public void InitializeInventory()
        {
            this.InventoryList.Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            this.InventoryList.Add(new Inventory("BGLP", 0.39, "Bagel", "Plain"));
            this.InventoryList.Add(new Inventory("BGLE", 0.49, "Bagel", "Everything"));
            this.InventoryList.Add(new Inventory("BGLS", 0.49, "Bagel", "Sesame"));
            this.InventoryList.Add(new Inventory("COFB", 0.99, "Coffee", "Black"));
            this.InventoryList.Add(new Inventory("COFW", 1.19, "Coffee", "White"));
            this.InventoryList.Add(new Inventory("COFC", 1.29, "Coffee", "Capuccino"));
            this.InventoryList.Add(new Inventory("COFL", 1.29, "Coffee", "Latte"));
            this.InventoryList.Add(new Inventory("FILB", 0.12, "Filling", "Bacon"));
            this.InventoryList.Add(new Inventory("FILE", 0.12, "Filling", "Egg"));
            this.InventoryList.Add(new Inventory("FILC", 0.12, "Filling", "Cheese"));
            this.InventoryList.Add(new Inventory("FILX", 0.12, "Filling", "Cream Cheese"));
            this.InventoryList.Add(new Inventory("FILS", 0.12, "Filling", "Smoked Salmon"));
            this.InventoryList.Add(new Inventory("FILH", 0.12, "Filling", "Ham"));
        }

        public string AddBagel(string SKU)
        {
            Inventory? item = InventoryList.Find(x => x.SKU == SKU);
            if (item != null)
            {
                if (BasketList.Count < capacity)
                {
                    BasketList.Add(item);
                    return "Bagel added to basket";
                }
                else
                {
                    return "Basket is full";
                }
            }
            else
            {
                return "Bagel not found";
            }
        }

        public string RemoveBagel(string SKU)
        {
            Inventory? item = InventoryList.Find(x => x.SKU == SKU);
            if (item != null)
            {
                if (BasketList.Contains(item))
                {
                    BasketList.Remove(item);
                    return "Bagel removed from basket";
                }
                else
                {
                    return "Bagel not in basket";
                }
            }
            else
            {
                return "Bagel not found";
            }
        }
        
        public int ChangeCap(int cap)
        {
            this.capacity = cap;

            return cap;
        }
        public bool BasketFull()
        {
            if (BasketList.Count <= capacity)
            {
                Console.WriteLine("Basket is full");
                return true;
            }
            Console.WriteLine("Basket has space");
            return false;
        }



    }
}
