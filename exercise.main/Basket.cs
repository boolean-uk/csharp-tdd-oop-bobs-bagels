namespace BobsBagels.main
{
    public class Basket
    {
        private Dictionary<Item, int> _items { get; } = new();
        private int _capacity { get; set; } = 4;
        private int _count { get; set; } = 0;

        public bool Add(Item item)
        {
            if (_count == _capacity) return false;
            if (_items.TryGetValue(item, out var value))
            {
                _count += 1;
                _items[item] = value + 1;
                return true;
            }
            _items[item] = 1;
            _count += 1;
            return true;
        }
        public bool Remove(Item item)
        {
            return _items.Remove(item);
        }
        public bool ChangeCapacity(User user, int capacity) { throw new NotImplementedException(); }
        public float Total() { throw new NotImplementedException(); }

        public Dictionary<Item, int> Items { get { return _items; } }
        public int Count {get { return _count; } }

        
    }
}
