using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        // Does the basket need to contain the actual objects, or will "printouts" suffice?
        //public List<ChosenItem> items;
        private double _total;
        private bool _isAdmin;
        private int _basketItemCount;
        private int _cap;
        private string? _capnotice;
        private string? _notfoundnotice;
        private string? _outofstocknotice;

        public List<Bagel> discountables = new List<Bagel>();
        public List<Filling> fillings = new List<Filling>();

        public Dictionary<int, List<Item>> BasketItems = new();

        public Item [] sixDiscount = new Item [6];
        public Item [] twelveDiscount = new Item [12];

        //public List<Item> Selections = new List<Item>();

        public List<Item> MakeNew()
        {
            return new List<Item>();
        }

        public void TrackDiscount ()
        {
            foreach (KeyValuePair<int, List<Item>> item in BasketItems)
            {
                int key = item.Key;
                List<Item> list = item.Value;
                foreach (Item thing in list) 
                {
                    if (thing is Bagel)
                    {
                        for (int i = 0; i < sixDiscount.Length; i++)
                        {
                            if (sixDiscount[i] == null)
                            {
                                sixDiscount[i] = thing;
                            }
                        }
                    }
                }
                
            }
            if (sixDiscount.Length == 6)
            {

            }
        }

        public void AddToSelection(List<Item> list, Item item)
        {
            if (item is Bagel)
            {
                if (Inventory.BagelStock > 0)
                {
                    list.Add(item);
                }
                else 
                {
                    OutOfStockNotice = "Sorry, out of stock";
                }
            }
            if (item is Filling)
            {
                if (Inventory.FillingStock > 0)
                {
                    list.Add(item);
                }
                else
                {
                    OutOfStockNotice = "Sorry, out of stock";
                }
            }
            if (item is Coffee)
            {
                if (Inventory.CoffeeStock > 0)
                {
                    list.Add(item);
                }
                else
                {
                    OutOfStockNotice = "Sorry, out of stock";
                }
            }
        }

        public void AddToBasket(int id, List<Item> item) 
        {
            UpdateCount(BasketItems);
            if (BasketItemCount < Cap)
            {
                BasketItems.Add(id, item);
                BasketItemCount++;
            }
            else 
            {
                CapNotice = "Your basket is full";
            }
            TrackDiscount();
        }

        public void UpdateCount(Dictionary<int, List<Item>> BasketItems)
        {
            int Counter = 0;
            foreach (KeyValuePair <int, List<Item>> item in BasketItems)
            {
                int key = item.Key;
                List<Item> items = item.Value;
                foreach (Item thing in items)
                {
                    if (thing is Bagel || thing is Coffee)
                    {
                        Counter++;
                    }
                    if (thing is Bagel)
                    {
                        discountables.Add((Bagel)thing);
                    }
                }
            }
            BasketItemCount = Counter;
        }

        public void RemoveFromBasket(int id)
        {
            if (BasketItems.ContainsKey(id)) {
                BasketItems.Remove(id);
            }
            else {
                NotFoundNotice = "Item does not exist";
            }
            //BasketItems.Remove(item);
        }

        public string PrintBasket()
        {
            string printout = "";
            if (BasketItems.Count > 0)
            {
                foreach (KeyValuePair<int, List<Item>> item in BasketItems)
                {
                    int key = item.Key;
                    List<Item> items = item.Value;
                    foreach (Item thing in items)
                    if (thing is Bagel bagel)
                    {
                            if (bagel.Filling != "")
                            {
                                printout += thing.PrintItem();
                                printout += $"\nWith: {bagel.Filling}\n\n";
                            }
                            else
                            {
                                printout += thing.PrintItem();
                                printout += "\nNo Fillings\n";
                            }
                    }
                    else
                    {
                        printout += thing.PrintItem();
                        printout += "\n\n";
                        }
                }
                printout += "\nSubtotal: "+BasketTotal().ToString()+" quid\n";
                printout += "Thanks for shopping at Bob's Bagels! ^_^";
                return printout;
            }
            else
            {
                return "Basket is empty";
            }
        }

        public double BasketTotal()
        {
            foreach (KeyValuePair<int, List<Item>> item in BasketItems)
            {
                int key = item.Key;
                List<Item> items = item.Value;
                foreach (Item thing in items) 
                {
                    Total += thing.Price;
                }
            }
            return Math.Round(Total, 2);
        }

        public void ChangeCap(int newcap)
        {
            if (IsAdmin == true) 
            {
                Cap = newcap;
            }
        }

        public double Total { get => _total; set => _total = value; }

        public int Cap { get => _cap; set => _cap = value;}

        public string CapNotice { get => _capnotice; set => _capnotice = value; }

        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }

        public string NotFoundNotice { get => _notfoundnotice; set => _notfoundnotice = value; }

        public string OutOfStockNotice { get => _outofstocknotice; set => _outofstocknotice = value; }

        public int BasketItemCount { get => _basketItemCount; set => _basketItemCount = value; }
    
    }
}
