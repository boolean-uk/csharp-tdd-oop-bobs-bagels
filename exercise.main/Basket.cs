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

        public bool AddBagel(string sku)
        {
            if (_inventory.GetItem(sku).GetType() != typeof(Filling) && _basketList.Count < _maxCapacity)
            {
                _basketList.Add((Item)_inventory.GetItem(sku));
                return true;
            }
            else return false;
        }

        public bool AddFilling(int index, string fillingSku)
        {
            if (index >= 0 && index < _basketList.Count && (Bagel)_basketList[index] != null)
            {
                if (_inventory.GetItem(fillingSku).GetType() == typeof(Filling))
                {
                    _basketList[index] = ((Bagel)_basketList[index]).AddFilling((Filling)_inventory.GetItem(fillingSku));
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

        public float TotalCost()
        {
            float totalCost = 0;
            foreach (var item in _basketList)
            {
                totalCost += item.GetPrice();
            }
            totalCost -= _inventory.RemoveDiscount(_basketList);
            return totalCost;
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
    }
}