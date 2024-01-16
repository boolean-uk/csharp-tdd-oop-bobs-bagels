using exercise.main.Variants;

namespace exercise.main.Foods
{
    public class Filling(FillingVariant variant) : Food<FillingVariant>(variant)
    {
        public override string Name => "Filling";
        public override string Sku
        {
            get
            {
                if(Variant.Equals(FillingVariant.Cream_Cheese))
                {
                    return "FILX";
                }
                return "FIL" + Variant.ToString().ToUpper()[..1];
            }
        }
    }
}