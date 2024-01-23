using exercise.main.Discounts;
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
        List<IProduct> _basket = new List<IProduct>();
        int _maxBasketSize = 13;
        Person _user;

        public Basket(Person user)
        {
            _user = user;
        }

        public bool AddItemToBasket(IProduct item)
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
            IProduct prod = ProductFactory.GenerateProduct(SKUs);
            return AddItemToBasket(prod);
        }

        private bool IsValid(IProduct item) 
        {
            if (!ProductFactory.ValidateProductSKU(item.GetSKUName()))
            {
                return false;
            }
            return (item.GetPrice() > 0f);
        }

        public int SetBasketSize(int newSize) 
        {
            if (_user.IsAdmin())
            {
                _maxBasketSize = newSize;
                return _maxBasketSize;
            }
            else 
            {
                return 0;
            }

        }

        public float GetBasketPrice() 
        {
            return _basket.Sum(prod => prod.GetPrice());
        }

        public float GetBasketPriceAfterDiscount() 
        {
            List<Discount> discountList = new List<Discount>();
            return DiscountManager.ApplyDiscounts(this, out discountList);
        }

        public float GetBasketPriceAfterDiscount(out List<Discount> discountList)
        {
            return DiscountManager.ApplyDiscounts(this, out discountList);
        }

        public bool RemoveProductFromBasket(IProduct item) 
        {
            List<IProduct> tempList = new List<IProduct>(_basket);
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
            IEnumerable<IProduct> toRemove = _basket.Where(p => p.GetSKUName() == SKUs[0]);
            // More complex if Bagel due to sub-objects...
            foreach (IProduct item in toRemove)
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
        /// Returns a NEW (shallow copy) list of items in the basket.
        /// </summary>
        /// <returns></returns>
        public List<IProduct> GetProducts() 
        {
            return new List<IProduct>( _basket );
        }

        public bool IsFull() 
        {
            return _maxBasketSize <= _basket.Count;
        }

        public void PrintReceipt() 
        {
            ReceiptManager printer = new ReceiptManager();
            printer.PrintReceipt(this, _user);
        }
    }
}
