using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    /*public Dictionary<string ,Iproduct> bagels =
        { "Onion_bagel" , new  } 
    public Dictionary<string, Iproduct> fillings = { }
    public Dictionary<string , Iproduct> coffees = { } */

    public class Shop 
    {
        public List<Iproduct> inventory { get; set; }
        public List<>
        public Iperson manager { get; set; }
        public Shop()
        {
            inventory = new List<Iproduct>();
            manager = new Manager();
        }
        public void AddToInventory(Iproduct item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                inventory.Add(item);
            }
        }
        public List<Iproduct> AvaiableItems()
        {
            return inventory;
        }
    }
}
