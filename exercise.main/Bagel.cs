namespace exercise.main;

public class Bagel : IProduct
{
    private int _id;
    private string _sku;
    private Product _filling;

    public Bagel(int id, string sku)
    {
        _id = id;
        _sku = sku.Trim();
    }

    public int Id() { return _id; }
    public string Sku() { return _sku; }
    public Product Filling { get { return _filling; } set { _filling = value; } }
}
