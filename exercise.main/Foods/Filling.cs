using exercise.main.Variants;

namespace exercise.main.Foods
{
    public class Filling : Food<FillingVariant>
    {
        public string Name => "Filling";

        public Filling()
        {
            
        }

        public Filling(FillingVariant variant) : base(variant)
        {
            
        }
    }
}