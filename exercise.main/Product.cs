namespace exercise.main
{
    public interface Product
    {
        string SKU { get; }
        double Price { get; }
        string Variant {  get; } 
        Filling Filling { get; }
    }
}