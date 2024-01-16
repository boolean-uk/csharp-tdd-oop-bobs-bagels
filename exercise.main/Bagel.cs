namespace exercise.main
{
    public enum BagelType
    {
        Onion,
        Plain,
        Everything,
        Sesame
    }
    public class Bagel : Item
    {
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Sku { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Bagel(BagelType type)
        {

        }
    }
}
