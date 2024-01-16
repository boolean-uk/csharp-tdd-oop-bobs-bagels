namespace exercise.main;

public class Product : IProduct
{
    private int _id;
    private string _sku;

    public Product(int id, string sku)
    {
        _id = id;
        _sku = sku.Trim();
    }

    public int Id() { return _id; }
    public string Sku() { return _sku; }
}
