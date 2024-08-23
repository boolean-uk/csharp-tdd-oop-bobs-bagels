using exercise.main.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace exercise.main
{
    public class Basket
    {
        #region Properties
        private List<Item> _itemsInBasket = new List<Item>();
        private int _capacity = 5;
        
        public List<Item> ItemsInBasket { get => _itemsInBasket; }
        public int Capacity { get => _capacity; set => _capacity = value;  }
        #endregion

        public bool Add(Item item)
        {
            if (_capacity <= 0)
            {
                return false;
            } else
            {
                foreach (var itemInBasket in _itemsInBasket)
                {
                    if (itemInBasket.Sku == item.Sku) 
                    {
                        _capacity--;
                        itemInBasket.Quantity++;
                        itemInBasket.Price = item.OriginalPrice * item.Quantity;
                        itemInBasket.CheckForDiscount();

                        return true;
                    } 
                }

                _itemsInBasket.Add(item);
                item.Quantity++;
                item.OriginalPrice = item.Price;
                _capacity--;

                return true;
            }
        }

        public bool Remove(Item item)
        {
            if (_itemsInBasket.Contains(item)) { 
                foreach (var itemInBasket in _itemsInBasket)
                {
                    if (itemInBasket.Sku == item.Sku)
                    {
                        _capacity++;
                        itemInBasket.Quantity--;

                        if (itemInBasket.Quantity == 0)
                        {
                            _itemsInBasket.Remove(item);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public bool AddFillingToBagel(Bagel bagel, Filling filling)
        {
            foreach (var item in _itemsInBasket)
            {
                if (item.Sku == bagel.Sku)
                {
                    if (bagel.Fillings.Contains(filling))
                    {
                        filling.Quantity++;
                        filling.Price = filling.OriginalPrice * filling.Quantity;
                        _capacity--;

                        return true;
                    } else
                    {
                        bagel.Fillings.Add(filling);
                        filling.Quantity++;
                        filling.OriginalPrice = filling.Price;
                        _capacity--;

                        return true;
                    }
                }
            }

            return false;
        }

        public double GetTotalSumOfBasket()
        {
            double total = 0;

            List<Bagel> bagelList = new List<Bagel>();
            List<Item> itemList = new List<Item>();

            foreach (var item in _itemsInBasket)
            {
                if (item.GetType() == typeof(Bagel))
                {
                    bagelList.Add((Bagel)item);
                }
                else
                {
                    itemList.Add(item);
                }
            }

            foreach (Bagel bagel in bagelList)
            {
                if (bagel.Fillings.Count > 0)
                {
                    total += bagel.Price;
                    total += bagel.Fillings.Sum(filling => filling.Price);
                }
                else
                {
                    total += bagel.Price;
                }
            }

            double itemListSum = itemList.Sum(item => item.Price);

            return Math.Round(total + itemListSum, 2);

            //return Math.Round(_itemsInBasket.Sum(x => x.Price), 2);
        }

        public Receipt Checkout(string shopName)
        {
            // CheckForCoffeeAndBagelSpecialOffer();
            Receipt receipt = new Receipt(_itemsInBasket, shopName, GetTotalSumOfBasket());

            return receipt;
        }

        //public void CheckForCoffeeAndBagelSpecialOffer()
        //{
        //    Bagel looseBagelType;
        //    int coffeeQuantity = 0;

        //    // Count amount of COFB, Black Coffee
        //    foreach (var item in _itemsInBasket)
        //    {
        //        if (item.GetType() == typeof(Coffee) & item.Sku == "COFB")
        //        {
        //            coffeeQuantity++;
        //        }
        //    }

        //    foreach (var item in _itemsInBasket)
        //    {
        //        if (item.GetType() == typeof(Bagel) & item.Quantity % 6 != 0 & (item.Sku == "BGLO" | item.Sku == "BGLE"))
        //        {
        //            looseBagelType = new Bagel(item.Sku, item.Price, item.Variant);
        //            looseBagelType.Quantity = item.Quantity % 6;
        //            item.Quantity -= item.Quantity % 6;

        //            foreach (var item2 in _itemsInBasket)
        //            {
        //                if (item2.GetType() == typeof(Coffee) & item2.Sku == "COFB" & looseBagelType.Quantity != 0)
        //                {
        //                    ((Coffee)item2).Bagel = looseBagelType;
        //                    looseBagelType.Price = 0;

        //                    for (int i = coffeeQuantity; i < looseBagelType.Quantity;)
        //                    {
        //                        item2.Price = 1.25;
        //                        item2.MoneySaved += 0.26;

        //                        looseBagelType.Quantity--;
        //                    }
        //                }
        //            }
        //        } else if (item.GetType() == typeof(Bagel) & item.Quantity % 12 != 0 & item.Sku == "BGLP")
        //        {
        //            looseBagelType = new Bagel(item.Sku, item.Price, item.Variant);
        //            looseBagelType.Quantity += item.Quantity % 12;
        //            item.Quantity -= item.Quantity % 12;
        //        }
        //    }
        //}
    }
}
