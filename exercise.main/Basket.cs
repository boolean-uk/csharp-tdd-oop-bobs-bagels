using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _products = [];
        private int _basketSize;
        private Inventory _inventory = new Inventory();
        private decimal _total;

        public Basket(int basketSize)
        {
            _basketSize = basketSize;
        }

        public void AddToBasket(Product product)
        {
            if(!Inventory.FindItemWithSKU(product.SKU))
            {
                throw new ArgumentException("Product does not exist in inventory");
            }

            if (BasketSize == 0)
            {
                throw new ArgumentException("No more room in basket");
            }
            Products.Add(product);
            BasketSize -= 1;
            Total += product.Price;
            
            
        }

        public void RemoveFromBasket(Product product)
        {
            if (!Products.Exists(p => p.Equals(product)))
            {
                throw new ArgumentException("No bagel here matches that request");
            }
            Products.Remove(product);
            BasketSize += 1;
            Total -= product.Price;
        }

        public void ExpandBasket(int expansion)
        {
            BasketSize += expansion;
        }
        

        public void CalculateTotal()
        {
            var bagels = Products.FindAll(p => p.SKU.StartsWith("BGL"));
            var blackCoffees = Products.FindAll(p => p.SKU == "COFB");

            if (bagels.Count > 0 && bagels.Count >= 12)
            {
                for(int i = 0; i < 11; i++)
                {
                    Total = Total - bagels[i].Price;
                }
                Total += 3.99m;
            }
            if (bagels.Count > 0 && bagels.Count >= 6)
            {
                for(int i = 0; i < 6; i++)
                {
                    Total = Total - bagels[i].Price;
                }
                Total += 2.49m;
            }
            if (blackCoffees.Count > 0)
            {
                
                if(bagels.Count < 6)
                {
                    Total = Total - bagels[0].Price;
                    Total = Total - 0.99m;
                    Total += 1.25m;

                }

            }

        }

        public void AddFilling(Bagel bagel, Filling filling)
        {
            if (Products.Contains(bagel))
            {
                bagel.AddFilling(filling);
                Products.Add(filling);
                Total += filling.Price;
            }
        }


        public List<Product> Products { get { return _products; } set { _products = value; } }
        public int BasketSize { get { return _basketSize; } set { _basketSize = value; } }


        public Inventory Inventory { get { return _inventory; } }

        public decimal Total { get { return _total; } set { _total = value; } }
    }
}
