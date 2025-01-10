using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket 
    {
        private List<Product> basketList = new List<Product>();
        private int maxProducts = 5;
        public Basket() 
        {
        }

        public void AddProduct(string sku)
        {   
            if (basketList.Count >= maxProducts)
            {
                Console.WriteLine("Your basket is full!");
                return;
            }
            Product item;
            switch (sku)
            {
                case "BGLO":
                    item = new Bagel(0.49, "Onion");
                    basketList.Add(item);
                    break;

                case "BGLP":
                    item = new Bagel(0.39, "Plain");
                    basketList.Add(item);
                    break;

                case "BGLE":
                    item = new Bagel(0.49, "Everything");
                    basketList.Add(item);
                    break;

                case "BGLS":
                    item = new Bagel(0.49, "Sesame");
                    basketList.Add(item);
                    break;

                case "COFB":
                    item = new Coffe(0.99, "Black");
                    basketList.Add(item);
                    break;

                case "COFW":
                    item = new Coffe(1.19, "White");
                    basketList.Add(item);
                    break;

                case "COFC":
                    item = new Coffe(1.29, "Capuccino");
                    basketList.Add(item);
                    break;

                case "COFL":
                    item = new Coffe(1.29, "Latte");
                    basketList.Add(item);
                    break;

                case "FILB":
                    item = new Filling(0.12, "Bacon");
                    basketList.Add(item);
                    break;

                case "FILE":
                    item = new Filling(0.12, "Egg");
                    basketList.Add(item);
                    break;

                case "FILC":
                    item = new Filling(0.12, "Cheese");
                    basketList.Add(item);
                    break;

                case "FILX":
                    item = new Filling(0.12, "Cream Cheese");
                    basketList.Add(item);
                    break;

                case "FILS":
                    item = new Filling(0.12, "Smoked Salmon");
                    basketList.Add(item);
                    break;

                case "FILH":
                    item = new Filling(0.12, "Ham");
                    basketList.Add(item);
                    break;

                default:
                    Console.WriteLine(sku + " does not exist in our invetory.");
                    break;
            }
        }

        public bool RemoveProduct(string variant)
        {
            for (int i = 0; i < basketList.Count; i++)
            {
                if (basketList[i]._variant == variant)
                {
                    Console.WriteLine($"Removed one {variant} {basketList[i]._name}");
                    basketList.RemoveAt(i);
                    return true;
                }
            }
            Console.WriteLine("Product was not in your basket");
            return false;
        }

        public double TotalPrice()
        {
            double price = 0;
            foreach (Product product in basketList)
            {
                price += product.GetPrice();
            }

            return price;
        }

        public int MaxProducts 
        { 
            set 
            { 
                this.maxProducts = value;
            }  
        }

        public List<Product> BasketList { get { return basketList; } }
    }
}
