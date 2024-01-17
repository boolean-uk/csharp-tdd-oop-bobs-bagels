using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Store
    {
        public int Capacity { get; set; } = 16;
        public List<Basket> Baskets { get; set; } = new();
        public Stock Stock { get; } = new();

        public Store() 
        { 
            

        }

        public string Price(Name name)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Stock.Items.Where(n => n.name == name))
            {
                sb.Append($"{item.SKU} {item.variant} {item.price}\n");
            }
            return sb.ToString();
        }

        public void SetCapacity(int capacity) 
        {
            Capacity = capacity;
            foreach (Basket basket in Baskets)
            {
                basket.Capacity = capacity;
            }
        }

        public void AddItem(Basket basket, string sku)
        {
            Basket? currentbasket = Baskets.Find(b => b == basket);
            if (currentbasket != null)
            {
                Item? item = Stock.GetInfoFromSKU(sku);
                if (item != null)
                {
                    currentbasket.Add(item);
                }
            }
        }
    }
}
