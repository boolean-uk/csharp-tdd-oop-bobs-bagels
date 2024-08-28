namespace BobsBagels.main
{
    public class Basket
    {
        private Dictionary<Item, int> _items { get; } = new();
        private int _capacity { get { return Manager.Capacity; } }
        private int _count { get; set; } = 0;

        public bool Add(Item item)
        {
            if (_count == _capacity) return false;

            if (item is Bagel bagel)
                {
                if (_count + 1 + bagel.Fillings.Count > _capacity) return false;
                _count += bagel.Fillings.Count;

            }
            if (_items.ContainsKey(item))
            {
                _count += 1;
                _items[item]++;
                return true;
            }

            _items[item] = 1;
            _count++;
            return true;
        }

        public bool Add(Item item, int quantity)
        {
            if (_count+quantity > _capacity) return false;
            int fillingCounter = 0;
            if (item is Bagel bagel)
            {
                if (fillingCounter + bagel.Fillings.Count + quantity > _capacity) return false;
                fillingCounter += bagel.Fillings.Count;

            }
            if (_items.ContainsKey(item))
            {
                _count += 1;
                _items[item] += quantity;
                return true;
            }

            _items[item] = quantity;
            _count += quantity + fillingCounter;
            return true;
        }
        public bool Remove(Item item)
        {
            if (item is Bagel bagel)
            {
                _count -= bagel.Fillings.Count;
            }
            _count--;
            return _items.Remove(item);
        }
        public float Total()
        {
            float total = 0;

            bool containsCoffee = _items.Any(item => item.Key is Coffee);
            bool containsBagel = _items.Any(item => item.Key is Bagel);
            bool appliedDiscount = false;
            bool skipBagel = false;

            foreach (var item in _items)
            {
                if (!appliedDiscount)
                {
                    if (item.Key is Bagel && item.Value >= 12)
                    {
                        int remainder = (item.Value % 12);
                        appliedDiscount = true;
                        total += remainder*item.Key.Price + 3.99f;
                        continue;
                    }
                    if (item.Key is Bagel && item.Value >= 6 && item.Value < 12) 
                    {
                        int remainder = (item.Value % 6);
                        appliedDiscount = true;
                        total += remainder * item.Key.Price + 2.49f;
                        continue;
                    }
                    if (item.Key is Coffee)
                    {
                        skipBagel = true;
                        appliedDiscount = true;
                        total += 1.25f;
                        continue;
                    }

                }
                if (item.Key is Bagel bagel)
                {
                    total += bagel.Price * item.Value;
                    if(skipBagel) total -= bagel.Price;
                }
                else
                {
                    total += item.Key.Price * item.Value;
                    if(skipBagel) total -= item.Key.Price;
                }
            }
            return (float) Math.Round(total, 3);
        }

        public Dictionary<Item, int> Items { get { return _items; } }
        public int Count {get { return _count; } }
        public int Capacity { get { return _capacity; } }



    }
}
