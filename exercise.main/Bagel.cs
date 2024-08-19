namespace BobsBagels.main
{
    public class Bagel(string sku, float price, string name, string variant) : Item(sku, price, name, variant)
    {
        private List<Filling> _fillings = [];
        private float _price { get { return CalculatePrice(); } }
        private static float CalculatePrice() { throw new NotImplementedException();}

        public bool AddFilling(Filling filling) 
        {
            if (_fillings.Contains(filling)) return false;
            _fillings.Add(filling);
            return true;
        }

        public bool RemoveFilling(Filling filling) { throw new NotImplementedException(); }

        public List<Filling> Fillings { get { return _fillings; } }
    }
}
