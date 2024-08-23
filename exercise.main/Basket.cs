using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exercise.main

{
    public class Basket
    {
        private Inventory _inventory = new Inventory();

        private List<Item> _items = new List<Item> { };

        private int _maxcapasity;

        
        public string printreceipt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Bob's Bagels");
            sb.AppendLine();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine();
            sb.AppendLine("-------------------");

            double totalprice = 0;

            var groupedItem = _items.GroupBy(item => new { item.Variant, item.Name })
                .Select(group => new
                {
                    Name = group.Key.Name,
                    Variant = group.Key.Variant,
                    Quantity = group.Count(),
                    ItemPrice = group.First().Price,
                    TotalPrice = group.Sum(item => item.Price)
                });

            foreach (var group in groupedItem)
            {
                var itemname = $"{group.Name} {group.Variant}";
                var itemquantity = group.Quantity;
                var totalitemprice = group.ItemPrice;
                totalprice += totalitemprice;

                sb.AppendLine($"{itemname}\t {itemquantity,2}\t £{totalitemprice:F2}");
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("------------------");
            sb.AppendLine($"Total         £{totalprice:F2}");

            return sb.ToString();


        }

        public bool addItem(Item item)
        {
            if (item == null)
            {
                return false;
            } else if (Items.Count <= _maxcapasity)
            {
                Items.Add(item);
                return true;
            } else
            {
                return false;
            }


            //if (Item.Count() <= max_capasity)
            //{
            //    Item.Add(item);
            //    return true;
            //} else if (item == null)
            //{
            //    return false;
            //}
            //return false;

        }
        public bool removeItem(Item item)
        {
            if (Items.Count() > _maxcapasity)
            {
                Items.Remove(item);
                return true;
            }
            return false;

        }
        public bool isFull()
        {
            if (Items.Count() <= _maxcapasity)
            {
                return true;
            }
            return false;
        }

        public bool changecapacity(int newcapasity)
        {

            if (newcapasity > 0 && newcapasity != _maxcapasity)
            {
                _maxcapasity = newcapasity;
                return true;
            }
            return false;

        }
        public string removingNotExisting(Item item)
        {
            if (!Items.Contains(item))
            {
                return "Item does not exists";
            }
            return "Item exists";
        }

        public double getTotalCost()
        {
            return Items.Sum(item => item.Price);

        }

        public double getBagelPrice(string sku)
        {
            Inventory inventory = new Inventory();

            Item bagel = inventory.ShopInventory.Find(item => item.Sku == sku);

            if (inventory.ShopInventory.Contains(bagel))
            {
                return bagel.Price;
            }
            return 0;

        }

        public string getChosenFilling(string sku)
        {
            Inventory inventory = new Inventory();

            Item bagelwithfilling = inventory.ShopInventory.Find(item => item.Sku == sku);

            if (inventory.ShopInventory.Contains(bagelwithfilling))
            {
                return bagelwithfilling.Variant;
            }
            return "Not existing";
        }

        public double getFillingCost(string variant)
        {
            Inventory inventory = new Inventory();
            double fillingprice = 0;

            foreach (Item item in inventory.ShopInventory)
            {
                if (item.Variant == variant)
                {
                    fillingprice = item.Price;
                    return fillingprice;
                }
            }
            return 0.0d;

        }

        /* public bool checknonexistsing(string sku)
        {
            Inventory inventory = new Inventory();

            foreach (Item item in Inventory.ShopInventory)
            {
                if (item.Sku == sku)
                {
                    return true;

                }

            }
            return false;
        }
        */

        

        public Inventory Inventory { get { return _inventory; } }
        public List<Item> Items { get { return _items; } }

        public int Maxcapasity { get { return _maxcapasity; } set { _maxcapasity = value; } }

        
    }
}
