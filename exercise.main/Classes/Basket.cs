using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Basket
    {
        private List<BasketItem> _items;
        private int _capacity;
        private Discount _discounts;
        public Basket(Discount discounts) 
        {
            _items = new List<BasketItem>();
            _capacity = 10;
            _discounts = discounts;
        }

        public bool Add(Product item, int amount) 
        {
            // Check if the capacity is full
            if (_items.Count >= _capacity) 
            {
                return false;
            }

            BasketItem alreadyExists = _items.Find(x => x.Product.Equals(item));

            // If the product already exists in the basket
            if (CheckIfProductExistsInBasket(item))
            {
                BasketItem foundItem = GetItemFromBasket(item);
                foundItem.Amount += amount;
            }
            else 
            {
                BasketItem newItem = new BasketItem(item, amount, item.Price);
                _items.Add(newItem);
            }

            // Sort the list by ProductType after adding or updating
            _items = _items.OrderBy(x => x.Product.Type).ToList();

            return true;

        }
        public void Remove(Product item) 
        {
            if (CheckIfProductExistsInBasket(item))
            {
                _items.Remove(GetItemFromBasket(item));
            }
            
        }

        public void Remove(string sku) 
        { 
            _items.Remove(GetItemBySKU(sku));
        }

        public int Capacity
        {
            get => _capacity;
            set { _capacity = value; }
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (var item in _items) 
            {
                total += item.Product.Price * item.Amount;
            }
            return total;
        }
         
        public List<BasketItem> GetItems()
        {
            return _items;
        }

        public Discount GetDiscounts()
        {
            return _discounts;
        }

        public double ApplyDiscounts()
        {
            double total = 0;
            total += _discounts.GetComboDiscount(_items);
            foreach (var item in _items)
            {
                if (_discounts.CalculateDiscount(item) > 0)
                {
                    item.Discount = _discounts.CalculateDiscount(item);

                }
            }
            return total;
        }

        public void SubmitOrder()
        {
            ApplyDiscounts();
            Console.WriteLine(Receipt());
        }

        public BasketItem GetItemBySKU(string sku)
        {
            return _items.Find(x => x.Product.SKU.Equals(sku));
        }

        public string Receipt()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    ~~~ Bob's Bagels ~~~");
            builder.AppendLine($"    {DateTime.Now}");
            builder.AppendLine();
            builder.AppendLine("----------------------------");

            double totalBeforeDiscounts = 0.0;
            double totalDiscounts = 0.0;

            foreach (var item in _items)
            {
                double itemTotal = item.Product.Price * item.Amount;
                totalBeforeDiscounts += itemTotal;

                double itemDiscount = item.Discount;
                totalDiscounts += itemDiscount;

                string productLine = $"{item.Product.Type} {item.Product.Variant}";
                builder.AppendLine($"{productLine,-20} {item.Amount,3}   {itemTotal - itemDiscount,10:C}");

                if (itemDiscount > 0)
                {
                    builder.AppendLine($"{"",-20} {"",-3}   (-{itemDiscount,9:C})");
                }
            }

            double comboDiscount = _discounts.GetComboDiscount(_items);
            totalDiscounts += comboDiscount;

            if (comboDiscount > 0)
            {
                builder.AppendLine($"{"Combo Discount",-20} {"",-3}   (-{comboDiscount,9:C})");
            }

            builder.AppendLine("----------------------------");

            double finalTotal = totalBeforeDiscounts - totalDiscounts;
            builder.AppendLine($"{"Total",-20} {"",-3}   {finalTotal,10:C}");
            builder.AppendLine();
            builder.AppendLine($" You saved a total of {totalDiscounts:C}");
            builder.AppendLine("       on this shop");
            builder.AppendLine();
            builder.AppendLine("        Thank you");
            builder.AppendLine("      for your order!");

            return builder.ToString();
        }

        public bool CheckIfProductExistsInBasket(Product item)
        {
            return GetItemFromBasket(item) == null ? false : true;

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var item in _items)
            {
                builder.AppendLine($"{item.Product.Variant} x {item.Amount} = {item.Product.Price * item.Amount:C}");
            }
            builder.AppendLine($"Total: {GetTotal():C}");
            return builder.ToString();
        }
      
        private BasketItem GetItemFromBasket(Product item)
        {
            return _items.Find(x => x.Product.SKU.Equals(item.SKU));
        }
    }
}
