using System.Diagnostics;
using System.IO.Pipelines;
using System.Xml.Linq;

namespace exercise.main
{
    public class InventoryData
    {
        
        public string name = ""; 
        public string SKU = ""; 
        public float price = 0.0f; 
        public int stock = 0;

        public InventoryData(string name, string sKU, float price, int stock)
        {
            this.name = name;
            SKU = sKU;
            this.price = price;
            this.stock = stock;
        }
        public string stringify()
        {
            //return string.Format("{0,0:10}{1,0:10}{2,0:30}{3,0:40}", SKU, name, price, stock);
            return String.Format("{0,0}{1,10}{2,10}{3,10}", SKU, name, price, stock);
        }
    }
    

    public class Inventory
    {
        Dictionary<string, InventoryData> inventory = new Dictionary<string, InventoryData>();
        public Inventory()
        {
        }
        public string stringify()
        {
            
            //return "Inventory:\n"+ string.Join("\n", inventory.ToList().Select(x=>x.Value.toString()));
            string st = String.Format("{0,0}{1,10}{2,10}{3,10}\n", "SKU", "Product", "Price", "Stock"); ;
            foreach (var item in inventory.ToList())
            {
                st += item.Value.stringify() + "\n";
            }
            return st;
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