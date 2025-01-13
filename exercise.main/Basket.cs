using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> _items { get; set; }
        public double _totalCost { get; set; }

        public Basket()
        {
            _items = new List<Item>();
            _totalCost = 0;
        }

        public double CalculateTotalCost()
        {
            double cost = 0;
            foreach(Item item in _items)
            {
                cost += item.cost;
            }
            _totalCost = cost;
            return _totalCost;
        }
        public void AddItem(Item newItem)
        {
            this._items.Add(newItem);
        }

        public bool DeleteItem(string sku)
        {
            Item? item = _items.Find((x) => (x.SKU == sku));
            if(item != null)
            {
                _items.Remove(item);
                return true;
            }
            return false;
        }

        public void applyDiscounts()
        {
            // Group item by name, sort by cost (high->low) and variant
            List<Item> disc = _items
                .OrderBy(item => item.name)
                .ThenByDescending(item => item.cost)
                .ThenBy(item => item.variant)
                .ToList();

            // Apply discount for 12 bagels
            // while 12 or more non-discounted bagels
            while (disc.Count(x => x.name.Equals("Bagel") && !x.isDiscounted) >= 12)
            {



                /**
                 *  13.01.25
                 *  ROUNDING ERROR BECAUSE OF FLOAT-POINT PRECISION  
                 */



                double discountedPricePerBagel = Math.Round(3.99 / 12, 2); // Rounding because of float precision

                int count = 0;
                foreach (Item item in disc)
                {
                    if (item.name.Equals("Bagel") && !item.isDiscounted)
                    {
                        item.cost = discountedPricePerBagel;
                        item.isDiscounted = true;
                        count++;

                        if (count == 12)
                        {
                            break;
                        }
                    }
                }
            }

            // Apply discount for 6 bagels
            // while 6 or more discounted bagels
            while (disc.Count(x => x.name.Equals("Bagel") && !x.isDiscounted) >= 6)
            {
                double discountedPricePerBagel = 2.49 / 6;

                int count = 0;
                foreach (Item item in disc)
                {
                    if (item.name.Equals("Bagel") && !item.isDiscounted)
                    {
                        item.cost = discountedPricePerBagel;
                        item.isDiscounted = true;
                        count++;

                        if (count == 6)
                        {
                            break;
                        }
                    }
                }
            }

            // Step 3: Apply Bagel + Coffee for 1.25 discount
            // Exits with break

            while (true)
            {
                Item bagel = null;
                Item coffee = null;

                // find non-discounted bagel
                foreach (var item in disc)
                {
                    if (item.name.Equals("Bagel") && !item.isDiscounted)
                    {
                        bagel = item;
                        break;
                    }
                }

                // find non-discounted bagel
                foreach (var item in disc)
                {
                    if (item.name.Equals("Coffee") && !item.isDiscounted)
                    {
                        coffee = item;
                        break;
                    }
                }

                // if missing bagel or coffee, exit while-loop
                if (bagel == null || coffee == null)
                {
                    break;
                }

                // Apply the discount
                bagel.cost = 0.35;
                bagel.isDiscounted = true;

                coffee.cost = 0.9;
                coffee.isDiscounted = true;
            }

            _items = disc;
        }

    }
}
