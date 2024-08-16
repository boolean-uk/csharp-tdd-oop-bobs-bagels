
namespace BobsBagels.main
{
    public class User
    {
        private string _role;
        private Basket _basket = new();

        public bool ChangeCapacity(int capacity) { throw new NotImplementedException();}
        public float Total() { throw new NotImplementedException(); }
        public float GetItemPrice(Item item) { throw new NotImplementedException(); }
        public float GetFillingPrice(Item item) { throw new NotImplementedException(); }

        public Basket Basket { get { return _basket; } }
    }
}
