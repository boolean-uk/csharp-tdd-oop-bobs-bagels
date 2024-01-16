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
    }
}