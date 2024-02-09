namespace exercise.main
{
    public class Basket
    {
        private int _maxCapacity = 4;
        public readonly List<Item> _basketList = new List<Item>();
        private Inventory _inventory;

        public Basket(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool AddProduct(string sku)
        {
            var item = _inventory.GetItem(sku);

            if (item == null) { return false; }

            if (item.GetType() != typeof(Filling) && _basketList.Count < _maxCapacity)
            {
                _basketList.Add(item);
                return true;
            }

            return false;
        }

        public bool AddFilling(int index, string fillingSku)
        {

            if (index >= 0 && index < _basketList.Count && _basketList[index].GetType() == typeof(Bagel))
            {
                var item = _inventory.GetItem(fillingSku);
                if (item == null) { return false; }

                if (item.GetType() == typeof(Filling))
                {
                    _basketList[index] = ((Bagel)_basketList[index]).AddFilling((Filling)item);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveBagel(int index)
        {
            if (_basketList.Count > index && index >= 0)
            {
                _basketList.RemoveAt(index);
                return true;
            }
            else return false;
        }
        public bool ChangeCapacity(int newCapacity)
        {
            if (newCapacity < 1 || newCapacity < _basketList.Count - 1)
            {
                return false;
            }
            else
            {
                _maxCapacity = newCapacity;
                return true;
            }
        }

        public Dictionary<string, BasketItem> GetDiscountedBasket()
        {
            var discountedBasket = _inventory.GetDiscountedBasket(GetBasket());

            return discountedBasket;
        }

        public Dictionary<string, BasketItem> GetBasket()
        {
            var basketDict = new Dictionary<string, BasketItem>();
            foreach (Item item in _basketList)
            {
                if (!basketDict.ContainsKey(item.Sku))
                {
                    basketDict.Add(item.Sku, new BasketItem(item));

                    if (item is Bagel)
                    {
                        Bagel itemBagel = (Bagel)item;
                        if (itemBagel.Fillings.Count > 0)
                        {
                            basketDict[item.Sku].Fillings.AddRange(itemBagel.Fillings);
                        }
                    }
                }
                else
                {
                    var basketItem = basketDict[item.Sku];
                    basketItem.IncrementQuantity();
                    basketItem.TotalCost += item.GetPrice();
                    if (item is Bagel)
                    {
                        Bagel itemBagel = (Bagel)item;
                        if (itemBagel.Fillings.Count > 0)
                        {
                            basketDict[item.Sku].Fillings.AddRange(itemBagel.Fillings);
                        }
                    }

                    basketDict[item.Sku] = basketItem;

                }
            }
            return basketDict;
        }
    }

    public struct BasketItem
    {
        public Item Item { get; set; }
        public List<Filling> Fillings { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public BasketItem(Item item)
        {
            Item = item;
            TotalCost = item.GetPrice();
            Quantity = 1;
            Fillings = new List<Filling>();
        }

        public void IncrementQuantity()
        {
            this.Quantity += 1;
        }
    }
}