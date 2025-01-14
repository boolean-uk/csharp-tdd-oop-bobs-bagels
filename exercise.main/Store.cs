using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Store
    {
        public List<Iitems> inventory = new List<Iitems> 
        {
            new Bagel("BGLO", 0.49m, "Bagel", "Onion"),
            new Bagel("BGLP", 0.39m, "Bagel", "Plain"),
            new Bagel("BGLE", 0.49m, "Bagel", "Everything"),
            new Bagel("BGLS", 0.49m, "Bagel", "Sesame"),
            new Coffee("COFB", 0.99m, "Coffee", "Black"),
            new Coffee("COFW", 1.19m, "Coffee", "White"),
            new Coffee("COFC", 1.29m, "Coffee", "Capuccino"),
            new Coffee("COFL", 1.29m, "Coffee", "Latte"),
            new Filling("FILB", 0.12m, "Filling", "Bacon"),
            new Filling("FILE", 0.12m, "Filling", "Egg"),
            new Filling("FILC", 0.12m, "Filling", "Cheese"),
            new Filling("FILX", 0.12m, "Filling", "Cream Cheese"),
            new Filling("FILS", 0.12m, "Filling", "Smoked Salmon"),
            new Filling("FILH", 0.12m, "Filling", "Ham"),
        };  

        //The order of the discounts in the list is the priority of the discounts. An item can only have 1 discount.
        public List<IDiscounts> discounts = new List<IDiscounts>
        {
            new RegularDiscount("Bagel", 12, 3.99m),
            new RegularDiscount("Bagel", 6, 2.49m),
            new DoubleDiscount("Bagel", "Coffee", 1, 1.25m)
        };

        public List<decimal> discounted = new List<decimal>();

        public Dictionary<string, string> Fills = new Dictionary<string, string>();

        public List<Iitems> Basket;

        public List<Iitems>? CopiedBasket;
        public int capacity { set; get; } = 10;

        public Store()
        {
            Basket = new List<Iitems>();
        }
        
        public bool AddItem(string item)
        {
            if (Basket.Count < capacity)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].Sku == item && item.StartsWith("B"))
                    {
                        Iitems added = new Bagel(inventory[i].Sku, inventory[i].Price, inventory[i].Name, inventory[i].Variant);
                        Basket.Add(added);
                        return true;
                    }
                    if (inventory[i].Sku == item && item.StartsWith("C"))
                    {
                        Iitems added = new Coffee(inventory[i].Sku, inventory[i].Price, inventory[i].Name, inventory[i].Variant);
                        Basket.Add(added);
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public bool AddFilling(string item, string bagel)
        {
            if (inventory.Any(n => n.Sku == item) && Basket.Count < capacity)
            {
                Filling? full = (Filling?)inventory.Find(n => n.Sku == item);

                if (inventory.Any(n => n.Sku == bagel)) {
                    Bagel? b = (Bagel?)Basket.Find(n => n.Sku == item);
                    Fills[bagel] = item;
                }
                Basket.Add(full);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItem(string item)
        {
            if (Basket.Any(n => n.Sku == item))
            {
                Iitems? full = Basket.Find(n => n.Sku == item);
                Basket.Remove(full);
                return true;
            }
            else if (Basket.Any(n => n.Name == item)) {
                Iitems? full = Basket.Find(n => n.Name == item);
                Basket.Remove(full);
                return true;
            }
            return false;
        }

        public decimal CheckTotal()
        {
            CopiedBasket = new List<Iitems>(Basket);
            Discount();
            decimal total = Basket.Sum(x => x.Price) + discounted.Sum();
            return total;
        }

        public decimal CheckItemCost(string item)
        {
            Iitems? cost = inventory.Find(n => n.Sku == item);
            if (cost == null)
            {
                return 0;
            }
            return cost.Price;
        }

        public void ChangeCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public string PrintReceipt() 
        {
            var b = new System.Text.StringBuilder();
            b.AppendLine("    ~~~ Bob's Bagels ~~~");
            b.AppendLine();
            b.AppendLine(DateTime.Now.ToString());
            b.AppendLine();
            b.AppendLine("----------------------------");
            b.AppendLine();

            CopiedBasket.ForEach(item => b.AppendLine(item.Name + " " + item.Variant));
            b.AppendLine();
            b.AppendLine("----------------------------");
            b.AppendLine(
                $"      Total cost is £{CheckTotal()}"
            );
            b.AppendLine();
            b.AppendLine($" Total discount is £{CheckTotal() - CopiedBasket.Sum(x => x.Price)}");
            b.AppendLine();
            b.AppendLine("Thank you for your order!");
            return b.ToString();

        }

        public void Discount()
        {

            for (int i = 0; i < discounts.Count; i++)
            {
                if (discounts[i] is RegularDiscount) { 
                    foreach (Iitems ware in inventory)
                    {
                        if (Basket.Where(item => item.Sku == ware.Sku).ToList().Count >= discounts[i].Amount)
                        {
                            discounted.Add(discounts[i].Price);
                            for (int j = 0; j < discounts[i].Amount; j++)
                            {
                                RemoveItem(ware.Sku);
                            }
                        }
                    }
                }

                if (discounts[i] is DoubleDiscount)
                {
                    int counter = 0;
                    int counter2 = 0;
                    foreach (var ware in Basket)
                    {
                        if (ware.Name == discounts[i].Item)
                        {
                            counter++;
                        }
                        if (ware.Name == discounts[i].Item2)
                        {
                            counter2++;
                        }                       
                    }
                    while (counter > 0 && counter2 > 0)
                    {
                        discounted.Add(discounts[i].Price);
                        counter -= 1;
                        counter2 -= 1;
                        for (int j = 0; j < discounts[i].Amount; j++)
                        {
                            RemoveItem(discounts[i].Item);
                            RemoveItem(discounts[i].Item2);
                        }
                    }
                }

            }    
            
        }
    }
}
