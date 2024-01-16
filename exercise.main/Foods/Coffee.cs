using exercise.main.Variants;

namespace exercise.main.Foods
{
    public class Coffee(CoffeeVariant variant) : Food<CoffeeVariant>(variant)
    {
        public override string Name => "Coffee";
        public override string Sku
        {
            get
            {
                return "COF" + Variant.ToString().ToUpper()[..1];
            }
        }

        public override float Price => _priceTable[Sku];

        private Dictionary<string, float> _priceTable = new()
        {
            {"COFB", 0.99f},
            {"COFW", 1.19f},
            {"COFC", 1.29f},
            {"COFL", 1.29f},
        };
    }
}