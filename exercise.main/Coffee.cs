namespace exercise.main
{
    public enum CoffeeType
    {
        Black,
        White,
        Capuccino,
        Latte
    }
    public class Coffee(CoffeeType type) : Item
    {
        public static readonly Dictionary<CoffeeType, string> CoffeeSku = new()
        {
            {CoffeeType.Black, "COFB"},
            {CoffeeType.White, "COFW"},
            {CoffeeType.Capuccino, "COFC"},
            {CoffeeType.Latte, "COFL"}
        };

        public static readonly Dictionary<CoffeeType, double> CoffeePrice = new()
        {
            {CoffeeType.Black, 0.99},
            {CoffeeType.White, 1.19},
            {CoffeeType.Capuccino, 1.29},
            {CoffeeType.Latte, 1.29}
        };

        private string _name = type.ToString();
        private double _price = CoffeePrice[type];
        private string _sku = CoffeeSku[type];
        public override string Name { get { return _name; } set { _name = value; } }
        public override double Price { get { return _price; } set { _price = value; } }
        public override string Sku { get { return _sku; } set { _sku = value; } }
    }
}
