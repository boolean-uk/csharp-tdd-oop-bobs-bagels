using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        public float Price { get; private set; }
        public string Name { get; private set; }
        public string Variant { get; private set; }
        public string SKU { get; private set; }
        private List<Item> subItems;
        

        public Item(float price, string name, string variant, string SKU)
        {
            this.Price = price;
            this.Name = name;
            this.Variant = variant;
            this.SKU = SKU;

            subItems = new List<Item>();
        }


        public void AddSubItems(Item subItem)
        {
            subItems.Add(subItem);        
        }


        public List<Item> GetSubItems()
        {
            return subItems;
        }


    }

    
}
