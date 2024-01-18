using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IProduct
    {
        float Price { get; }
        string Name { get; }
        string Variant { get; }
        string SKU { get; }
    }
    public class Item : IProduct
    {
        public float Price { get; private set; }
        public string Name { get; private set; }
        public string Variant { get; private set; }
        public string SKU { get; private set; }
        private List<IProduct> subItems;

        public Item(float price, string name, string variant, string SKU)
        {
            this.Price = price;
            this.Name = name;
            this.Variant = variant;
            this.SKU = SKU;

            subItems = new List<IProduct>();
        }



        /*
        public string getSKU()
        {
            return SKU;
        }
        

        public string getNameVariant()
        {
            return nameVariant;
        }

 

        public float getPrice()
        {
            return price;
        }*/



        public void AddSubItems(IProduct subItem)
        {
            subItems.Add(subItem);        
        }


        public List<IProduct> GetSubItems()
        {
            return subItems;
        }


    }


}
