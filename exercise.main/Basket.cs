using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity = 10;
        public HashSet<Coupon> coupons { get; set; }
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
        public Basket()
        { 
            coupons = new HashSet<Coupon>();   
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
        public void AddCoupon(Coupon coupon)
        {
            coupons.Add(coupon);
        }
        public float Discount()
        {
            float total = 0;
            List<Coupon> CouponList = coupons.ToList();
            List<Iproduct> itemCopy = new List<Iproduct>(Items); // Create a copy of the Items list

            foreach (Coupon c in CouponList.ToList())
            {
                bool allItemsPresent = c.items.All(item => itemCopy.Contains(item));
                if (allItemsPresent)
                {
                    total += c.discount;
                    foreach (Iproduct i in c.items)
                    {
                        itemCopy.Remove(i);
                    }
                    CouponList.Remove(c); // Removing from the copy of the coupons list
                }
            }
            //adding on the rest of the non discount cost
            itemCopy.ForEach(x => total += x.GetPrice());
            return total;
        }

    }
}
