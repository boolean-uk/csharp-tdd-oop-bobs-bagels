
namespace exercise.main
{
    public enum BagelType
    {
        Onion,
        Plain,
        Everything,
        Sesame
    }

    public class Bagel(BagelType type) : Item
    {
        public static readonly Dictionary<BagelType, double> BagelPrice = new()
        {
            {BagelType.Onion, 0.49},
            {BagelType.Plain, 0.39},
            {BagelType.Everything, 0.49},
            {BagelType.Sesame, 0.49}
        };

        public static readonly Dictionary<BagelType, string> BagelSku = new()
        {
            {BagelType.Onion, "BGLO"},
            {BagelType.Plain, "BGLP"},
            {BagelType.Everything, "BGLE"},
            {BagelType.Sesame, "BGLS"}
        };

        private string _name = type.ToString();
        private double _price = BagelPrice[type];
        private string _sku = BagelSku[type];
        private List<Filling> _fillings = [];

        public override string Name { get { return _name; } set { _name = value; } }
        public override double Price { get { return _price; } set { _price = value; } }
        public override string Sku { get { return _sku; } set { _sku = value; } }

        public void AddFilling(Filling filling)
        {
            _fillings.Add(filling);
        }

        public List<Filling> GetFillings()
        {
            return _fillings;
        }

    }
}
