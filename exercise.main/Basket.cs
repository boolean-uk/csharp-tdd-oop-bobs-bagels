using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        List<Product> _basket = new List<Product>();
        int _maxBasketSize = 13;

        public bool AddItemToBasket(Product item)
        {
            if (IsValid(item))
            {
                int res1 = _basket.Count;
                _basket.Add(item);
                int res2 = _basket.Count;
                return (res2 > res1);
            } else 
            {
                return false;
            }
        }

        public bool AddItemToBasket(string[] SKUs)
        {
            Product prod = ProductFactory.GenerateProduct(SKUs);
            return AddItemToBasket(prod);
        }

        private bool IsValid(Product item) 
        {
            if (!ProductFactory.ValidateProductSKU(item.GetSKUName()))
            {
                return false;
            }
            return (item.GetPrice() > 0f);
        }

        public int SetBasketSize(int newSize) 
        {
            _maxBasketSize = newSize;
            return _maxBasketSize;
        }

        public float GetBasketPrice() 
        {
            return _basket.Sum(prod => prod.GetPrice());
        }

        public bool RemoveProductFromBasket(Product item) 
        {
            List<Product> tempList = new List<Product>(_basket);
            int res1 = tempList.Count;
            tempList.Remove(item);
            int res2 = tempList.Count;

            if (res1 > res2)
            {
                _basket = tempList;
                return true;
            }
            else 
            {
                return false;
            }
        }


        public bool RemoveProductFromBasket(string[] SKUs)
        {
            // TODO: REFACTOR, this is hideous
            IEnumerable<Product> toRemove = _basket.Where(p => p.GetSKUName() == SKUs[0]);
            // More complex if Bagel due to sub-objects...
            foreach (Product item in toRemove)
            {
                Bagel bagel = (Bagel)item;
                for (int i = 1; i < SKUs.Length; i++) 
                {
                    if (bagel.GetFilling().Exists(fill => fill.SKUName == SKUs[i])) 
                    {
                        if (i == SKUs.Length-1) 
                        {
                            return RemoveProductFromBasket(item);
                        }
                    }
                }
            }
            return false;

        }

        /// <summary>
        /// Returns a NEW list of items in the basket
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts() 
        {
            return new List<Product>( _basket );
        }

        public bool IsFull() 
        {
            return _maxBasketSize <= _basket.Count;
        }
    }
}
