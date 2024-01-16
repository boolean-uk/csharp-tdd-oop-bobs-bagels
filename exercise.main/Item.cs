using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private float price;
        private string nameVariant;
        private string SKU;
        private List<Item> subItems;

        public Item(float price, string nameVariant, string SKU) {
            this.price = price;
            this.nameVariant = nameVariant;
            this.SKU = SKU;

            subItems = new List<Item>();
        }


        public void setSKU(string sku)
        { this.SKU = sku; }

        public string getSKU()
        {
            return SKU;
        }


        public void setNameVariant(string nameVariant)
        { this.nameVariant = nameVariant; }

        public string getNameVariant()
        {
            return nameVariant;
        }

        public void setPrice(float price)
        { this.price = price; }

        public float getPrice()
        {
            return price;
        }

        public void addSubItems(Item subItem)
        {
            subItems.Add(subItem);        
        }
        public List<Item> GetSubItems()
        {
            return subItems;
        }


    }
}
