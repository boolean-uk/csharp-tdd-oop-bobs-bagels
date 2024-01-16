namespace exercise.main;

public class Basket
{
    private List<IProduct> _products;
    private int _capacity;
    private Menu _menu;

    public Basket()
    {
        _products = new List<IProduct>();
        _capacity = 3;
        _menu = new Menu();
    }

    public int Capacity { get { return _capacity; } set { _capacity = value; } }

    public bool add(string sku)
    {
        var productTuple = _menu.getItem(sku);
        if (productTuple != null)
        {

        }
        return true;
    }
}
