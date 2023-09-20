namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public interface IProduct
    {
        string SKU { get; }
        string Name { get; }
        decimal Price { get; }
    }
}