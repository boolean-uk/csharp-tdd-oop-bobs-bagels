using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
{
    public List<string> Items { get; set; } = new List<string>();
        //public Dictionary<string, bool> Items { get; set; } = new Dictionary<string, bool>();

        private Invertory inventory;
        private List<string> basketItems = new List<string>();
      /*  public Basket(Invertory inventory)
        {
            
        }*/
        public Basket(int capacity)
        {
            Capacity = capacity;
            Items = new List<string>();
            this.inventory = new Invertory();
        }
        public void AddToBasket(string sku)
        {
            if (inventory.SKUList.ContainsKey(sku))
            {
                Items.Add(sku);
            }
           
        }
        public decimal CalculateTotalCost()
        {
            decimal totalCost = Items.Sum(Items => inventory.SKUList.GetValueOrDefault(Items, 0m));
            return totalCost;
        }
    public int Capacity { get; set; }
       

      

    public bool AddAnotherBagel(string bagel)
    {
        if (Items.Count + 1 <= Capacity)
        {
            Items.Add(bagel);
            return true;
        }
        return false;
    }


    public bool AddBagel(string bagel)
    {
        Items.Add(bagel);
        return true;
        //foreach (var item in Items )
        //{
        //    if (item == basket)
        //    {
        //        Items[basket] = true;
        //        return true;
        //    }
        //}
        //return false;
    }

    public string RemoveBagel(string remove)
    {
       if (Items.Any(x => x == remove))
            {
                Items.Remove(remove);
                return "Item removed";
            }
            return "Not found";
            //foreach (var bagel in Items)
            //{
            //    if (bagel == remove)
            //        Items.Remove(bagel);
            //    return "Item removed";
            //}
            //return "Are you insane?!";
        }

    public string SearchBagelByName(string search)
    {
        if (Items.Any(x => x == search))
        {
            Items.Remove(search);
            return "Item removed";
        }
        return "Are you insane?!";



        //foreach (var bagel in Items)
        //{
        //    if (bagel == search)
        //    Items.Remove(bagel);
        //    return "Item removed";
        //}
    }

}
}
