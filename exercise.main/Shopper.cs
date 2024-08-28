namespace BobsBagels.main
{
    public class Shopper : User
    {
        private Basket _basket = new();
        private Receipt _receipt = new();

        public float Total() => _basket.Total();
        public float GetItemPrice(Item item) { throw new NotImplementedException(); }
        public float GetFillingPrice(Item item) { throw new NotImplementedException(); }
        public void PrintReceipt() 
        {
            var print = _receipt.BuildReceipt(_basket);
            Console.WriteLine(print);
        }
        public Basket Basket { get { return _basket; } }

    }
}