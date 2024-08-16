namespace BobsBagels.main
{
    public class Basket
    {
        private Dictionary<Item, float> _items { get;} = new();
        private int _capacity { get; set; } = 4;

        public bool Add(Item item) { throw new NotImplementedException(); }
        public bool Remove(Item item) { throw new NotImplementedException (); }
        public bool ChangeCapacity(string userRole, int capacity) { throw new NotImplementedException (); }
        public float Total() { throw new NotImplementedException (); }
    }
}
