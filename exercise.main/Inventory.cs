using System.Diagnostics;
using System.IO.Pipelines;

namespace exercise.main
{
    public class InventoryData
    {
        
        public string name; 
        public string SKU; 
        public float price; 
        public int stock;

        public InventoryData(string name, string sKU, float price, int stock)
        {
            this.name = name;
            SKU = sKU;
            this.price = price;
            this.stock = stock;
        }
    }
    public class Inventory
    {
        Dictionary<string, InventoryData> inventory = new Dictionary<string, InventoryData>();
        public Inventory()
        {
        }
        public void Add(string SKU, string name, float price, int stock )
        {
            if (inventory.ContainsKey(SKU))
            {
                Console.WriteLine("SKU already added to Inventory... Edit");
                Debug.Assert(inventory.ContainsKey(SKU));
                return; 
            }

            inventory.Add(SKU,new InventoryData(name, SKU, price, stock));
        }
        public void Add(BaseProduct product, int stock)
        {
            if (inventory.ContainsKey(product.SKU))
            {
                Console.WriteLine("SKU already added to Inventory... Edit");
                Debug.Assert(inventory.ContainsKey(product.SKU));
                return; 
            }

            inventory.Add(product.SKU, new InventoryData(product.ProductName, product.SKU, product.ProductPrice, stock));
        }
        public void IncreaseStock(string SKU, int additionToStock )
        {
            if (inventory.ContainsKey(SKU))
            {
                inventory[SKU].stock += additionToStock;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, can't increase Stock");
                Debug.Assert(inventory.ContainsKey(SKU));
                return;
            }
        }
        public void decreaseStock(string SKU, int removeFromStock )
        {
            if (inventory.ContainsKey(SKU))
            {
                inventory[SKU].stock -= removeFromStock;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, can't decrease Stock");
                Debug.Assert(inventory.ContainsKey(SKU));
                return;
            }
        }
        public int getStock(string SKU)
        {
            if (inventory.ContainsKey(SKU))
            {
                return inventory[SKU].stock;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, no stock to return");
                return 0;
            }
        }
        public void EditPrice(string SKU, float newPrice)
        {
            if (inventory.ContainsKey(SKU))
            {
                inventory[SKU].price = newPrice;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, can't Edit Price");
                Debug.Assert(inventory.ContainsKey(SKU));
                return;
            }

        }
        public float getPrice(string SKU)
        {
            if (inventory.ContainsKey(SKU))
            {
                return inventory[SKU].price;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, no price to return");
                Debug.Assert(inventory.ContainsKey(SKU));
                return 0;
            }

        }
        public string getName(string SKU)
        {
            if (inventory.ContainsKey(SKU))
            {
                return inventory[SKU].name;
            }
            else
            {
                Console.WriteLine("SKU Doesnt exist, no name to return");
                Debug.Assert(inventory.ContainsKey(SKU));
                return "";
            }

        }
    }
}