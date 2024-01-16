using exercise.main.Variants;

namespace exercise.main.Foods
{
    public class Coffee : Food<CoffeeVariant>
    {
        public string Name => "Coffee";

        public Coffee()
        {
            
        }

        public Coffee(CoffeeVariant variant) : base(variant)
        {
            
        }
    }
}