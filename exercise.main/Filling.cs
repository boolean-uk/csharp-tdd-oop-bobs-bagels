namespace exercise.main
{
    public enum FillingType
    {
        Bacon,
        Egg,
        Cheese,
        CreamCheese,
        SmokedSalmon,
        Ham
    }
    public class Filling(FillingType type) : Item
    {
        public static readonly Dictionary<FillingType, string> FillingSku = new()
        {
            {FillingType.Bacon, "FILB"},
            {FillingType.Egg, "FILE"},
            {FillingType.Cheese, "FILC"},
            {FillingType.CreamCheese, "FILX"},
            {FillingType.SmokedSalmon, "FILS"},
            {FillingType.Ham, "FILH"}
        };

        private string _name = type.ToString();
        private double _price = 0.12;
        private string _sku = FillingSku[type];
        public override string Name { get { return _name; } set { _name = value; } }
        public override double Price { get { return _price; } set { _price = value; } }
        public override string Sku { get { return _sku; } set { _sku = value; } }
    }
}
