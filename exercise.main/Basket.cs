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

    public int Capacity { get { return _capacity; } }
    public void setCapacity(int newCapacity)
    {
        if (newCapacity > 0 && newCapacity >= _products.Count)
        {
            _capacity = newCapacity;
            Console.WriteLine("New size set.");
        }
        else
        {
            Console.WriteLine("Failed to change basket size. The size must be 1 or higher and not lower than it's current contents.");
        }
    }

    public bool add(int id, string sku)
    {
        var productTuple = _menu.getItem(sku);
        var idExists = _products.FirstOrDefault(x => x.Id() == id);
        if (idExists == null && _products.Count < _capacity)
        {
            if (productTuple.Item2 == "Bagel")
            {
                _products.Add(new Bagel(id, sku));
                return true;
            }
            else if (productTuple.Item2 == "Coffee")
            {
                _products.Add(new Product(id, sku));
                return true;
            }
        }
        return false;
    }

    public bool addFilling(int id, string sku)
    {
        var productTuple = _menu.getItem(sku.Trim());
        Bagel? bagel = _products.OfType<Bagel>().FirstOrDefault(x => x.Id() == id);
        if (productTuple.Item2 == "Filling" && bagel != null)
        {
            bagel.Filling = new Product(id, sku);
            return true;
        }
        return false;
    }

    public bool remove(int id)
    {
        var toDelete = _products.FirstOrDefault(x => x.Id().Equals(id));
        if (toDelete != null)
            return _products.Remove(toDelete);
        return false;
    }

    public double getItemPrice(string sku)
    {
        return _menu.getItem(sku.Trim()).Item1;
    }

    public double getBasketPrice()
    {
        double price = 0.00;
        var bagels = _products.OfType<Bagel>().ToList();
        var coffees = _products.OfType<Product>().ToList();
        foreach (var item in coffees)
        {
            price += _menu.getItem(item.Sku()).Item1;
        }
        foreach (var item in bagels)
        {
            price += _menu.getItem(item.Sku()).Item1;
            if (item.Filling != null)
            {
                price += _menu.getItem(item.Filling.Sku()).Item1;
            }
        }
        return price;
    }

    public void printProducts()
    {
        Console.WriteLine($"Basket contents ({_products.Count}/{_capacity}):");
        Console.WriteLine("----------------------");
        if (_products.Count == 0)
        {
            Console.WriteLine("Empty");
        }
        else
        {
            var bagels = _products.OfType<Bagel>().ToList();
            var coffees = _products.OfType<Product>().ToList();
            foreach (var item in bagels)
            {
                var bagelData = _menu.getItem(item.Sku());
                if (item.Filling != null)
                {
                    var fillingData = _menu.getItem(item.Filling.Sku());
                    Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} Filling: {fillingData.Item3} price: {bagelData.Item1 + fillingData.Item1}");
                }
                else
                {
                    Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} price: {bagelData.Item1}");
                }
            }
            foreach(var item in coffees)
            {
                var coffeeData = _menu.getItem(item.Sku());
                Console.WriteLine($"Id: {item.Id()} Product: {coffeeData.Item2} {coffeeData.Item3} price: {coffeeData.Item1}");
            }
            Console.WriteLine($"Total price: {getBasketPrice()}");
        }
        Console.WriteLine("----------------------");
    }
}
