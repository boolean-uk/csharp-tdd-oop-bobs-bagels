using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity = 10;
        public HashSet<Coupon> coupons { get; set; } = new HashSet<Coupon>();
        public List<Coupon> usedCoupons { get; set; } = new List<Coupon>(); //for storing used coupons
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        private List<Iproduct> _items = new List<Iproduct>();
       
        public List<Iproduct> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public HashSet<Coupon> GetCoupons()
        {
            return coupons;
        }

        public void AddCoupon(Coupon coupon)
        {
            coupons.Add(coupon);
        }
        public void AddBagel(Iproduct item)
        { 
            if(!this.IsFull())
            {
                Items.Add(item);
            }
        }
        public void RemoveBagel(Iproduct item)
        {
            if (this.ItemNotPresent(item))
            {
                throw new ArgumentException("Parameter cannot be null", nameof(item)); //throws exception so the user can know item is not present
            }
            Items.Remove(item);
        }
        public bool IsFull() 
        {
            return Items.Count >= Capacity;
        }
        public bool ItemNotPresent(Iproduct item)
        {
            return !Items.Any(x => x == item);
        }
        public float GetTotalCost()
        { 
            float totalCost = 0F;
            Items.ForEach(x => totalCost += x.GetPrice());
            return totalCost;
        }

        //this function returns total cost of items in basket including discounts
        public float Discount()
        {
            float total = 0;
          
            List<Coupon> CouponList = coupons.ToList(); //list of all coupoons  added to basket
            List<Iproduct> itemCopy = new List<Iproduct>(Items); // Create a copy of the Items list, removes all discounted items and calculates normal cost pluss discount
            List<string> BasketSKUs = new List<string>();
            List<string> CouponSKUs = new List<string>();
            bool allItemsPresent = true;
            //adding all sku to coupon and basket lists
            Items.ForEach(x => BasketSKUs.Add(x.GetSKU()));
            CouponList.ForEach(item => item.items.ForEach(x => CouponSKUs.Add(x.GetSKU())));//im sorry about this

            //loop through all coupons and if all items in coupon is present in basket, remove them and from basket item copy and add discounts
            foreach (Coupon c in CouponList.ToList())
            {
                //Console.WriteLine("dsfdfdsUHFUISFDUFSGDJIFSDGFGSDOIJFGDSJIOFGDIOSJFIOGSIJFDSGIJFSDG");
                foreach (Iproduct item in c.items)
                { 
                    if(BasketSKUs.Contains(item.GetSKU()))
                        {
                        BasketSKUs.Remove(item.GetSKU());
                        
                    }
                    else
                    {
                        
                        allItemsPresent = false;
                        break;
                    }
                }
                if (allItemsPresent)
                {
                    foreach (Iproduct i in c.items)
                    {
                        for (int j = 0; j < itemCopy.Count; j++)
                        {
                            if (itemCopy[j].GetSKU() == i.GetSKU()) 
                            { 
                                itemCopy.RemoveAt(j);
                                break;
                            }
                        }
                        }
                    total += c.discount;
                    usedCoupons.Add(c);//adding to used copons so we can see it in the receipt later
                    CouponList.Remove(c); // Removing from the copy of the coupons list
                    
                }
            }
            //adding on the rest of the non discount cost
            itemCopy.ForEach(x => total += x.GetPrice());
            return total;
        }
        public List<Coupon> GetAppliedDiscounts()
        {
            return usedCoupons;
        }
        //extesnion 1 is a brute force receipt without discounts, as far as i understood
        public void PrintReceipt()
        {
            //first count items of same type in basket
            Dictionary<string, int> dict = new Dictionary<string, int>();//SKU is key and int is amount of the item in the basket
            HashSet<String> printed = new HashSet<String>(); //keeping track of whiich items are printed
            Items.ForEach(x =>
            {
                if (!dict.ContainsKey(x.GetSKU()))
                {
                    dict.Add(x.GetSKU(), 1);
                }
                else
                {
                    dict[x.GetSKU()] ++;
                }
            });

            Console.WriteLine("    ~~~Bob's Bagels ~~~    ");
            Console.WriteLine($"    {DateTime.Now.ToString()}    ");
            Console.WriteLine("---------------------------");
            foreach(Iproduct x in  Items)
            {
                if(!printed.Contains(x.GetSKU()))
                {
                    Console.WriteLine($"{x.GetVariant()}{x.GetName()} {dict[x.GetSKU()]} ${x.GetPrice()}");
                    printed.Add(x.GetSKU());
                }
           
            }    
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Total ${GetTotalCost()}");
            Console.WriteLine("Thank you for your order!");
        }
        public void PrintReceiptWithDiscounts()
        {
            //first count items of same type in basket
            Dictionary<string, int> dict = new Dictionary<string, int>();//SKU is key and int is amount of the item in the basket
            HashSet<String> printed = new HashSet<String>(); //keeping track of whiich items are printed
            Items.ForEach(x =>
            {
                if (!dict.ContainsKey(x.GetSKU()))
                {
                    dict.Add(x.GetSKU(), 1);
                }
                else
                {
                    dict[x.GetSKU()]++;
                }
            });
            List<float> discounts = new List<float>();
            this.GetAppliedDiscounts().ForEach(x => discounts.Add(x.discount));

            Console.WriteLine("    ~~~Bob's Bagels ~~~    ");
            Console.WriteLine($"    {DateTime.Now.ToString()}    ");
            Console.WriteLine("---------------------------");
            foreach (Iproduct x in Items)
            {
                if (!printed.Contains(x.GetSKU()))
                {
                    Console.WriteLine($"{x.GetVariant()}{x.GetName()} {dict[x.GetSKU()]} ${x.GetPrice()* dict[x.GetSKU()]}");
                    Console.WriteLine($"Discounts: {Discount()}");
                    printed.Add(x.GetSKU());
                }

            }
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Total ${Discount()}");
            Console.WriteLine("Thank you for your order!");
        }
    }
}
