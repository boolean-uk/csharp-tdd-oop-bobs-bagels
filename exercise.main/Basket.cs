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
        int packsOf12 = calculate12Packs(bagels.Count);
        bool packOf6 = calculate6Pack(bagels.Count);
        int numberOfFreeBagels = 12 * packsOf12;
        if (packOf6) numberOfFreeBagels += 6;
        int coffeeDeals = calculateCoffeDeals(bagels.Count - numberOfFreeBagels, coffees.Count);
        numberOfFreeBagels += coffeeDeals;
        int numberOfFreeCoffees = coffeeDeals;
        foreach (var item in coffees)
        {
            if (numberOfFreeCoffees > 0)
                numberOfFreeCoffees--;
            else
                price += _menu.getItem(item.Sku()).Item1;
        }
        foreach (var item in bagels)
        {
            if (numberOfFreeBagels > 0)
                numberOfFreeBagels--;
            else 
                price += _menu.getItem(item.Sku()).Item1;
            if (item.Filling != null)
            {
                price += _menu.getItem(item.Filling.Sku()).Item1;
            }
        }
        if (packsOf12 > 0) price += packsOf12 * 3.99;
        if (packOf6) price += 2.49;
        if (coffeeDeals > 0) price += coffeeDeals * 1.25;
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
            int packsOf12 = calculate12Packs(bagels.Count);
            bool packOf6 = calculate6Pack(bagels.Count);
            int numberOfFreeBagels = 12 * packsOf12;
            if (packOf6) numberOfFreeBagels += 6;
            int coffeeDeals = calculateCoffeDeals(bagels.Count - numberOfFreeBagels, coffees.Count);
            numberOfFreeBagels += coffeeDeals;
            int numberOfFreeCoffees = coffeeDeals;
            foreach (var item in bagels)
            {
                var bagelData = _menu.getItem(item.Sku());

                if (item.Filling != null)
                {
                    var fillingData = _menu.getItem(item.Filling.Sku());
                    if (numberOfFreeBagels > 0)
                    {
                        Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} Filling: {fillingData.Item3} price: {fillingData.Item1}");
                        numberOfFreeBagels--;
                    }
                    else
                    {
                        Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} Filling: {fillingData.Item3} price: {bagelData.Item1 + fillingData.Item1}");
                    }
                }
                else
                {
                    if (numberOfFreeBagels > 0)
                    {
                        Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} price: 0");
                        numberOfFreeBagels--;
                    }
                    else
                    {
                        Console.WriteLine($"Id: {item.Id()} Product: {bagelData.Item2} {bagelData.Item3} price: {bagelData.Item1}");
                    }
                }
            }
            foreach(var item in coffees)
            {
                var coffeeData = _menu.getItem(item.Sku());
                if(numberOfFreeCoffees > 0)
                {
                    Console.WriteLine($"Id: {item.Id()} Product: {coffeeData.Item2} {coffeeData.Item3} price: 0");
                    numberOfFreeCoffees--;
                }
                else
                {
                    Console.WriteLine($"Id: {item.Id()} Product: {coffeeData.Item2} {coffeeData.Item3} price: {coffeeData.Item1}");
                }
            }
            if (packsOf12 > 0) Console.WriteLine($"Discount {packsOf12} packs of 12 bagels totalling {packsOf12 * 3.99} (filling not included in price)");

            if (packOf6) Console.WriteLine("Discount 6 pack of bagels for 2.49 (filling not included in price)");

            if (coffeeDeals > 0) Console.WriteLine($"Discount {coffeeDeals} deals of one coffe and bagel totalling {coffeeDeals * 1.25} (filling not included in price)");

            Console.WriteLine($"Total price: {getBasketPrice()}");
        }
        Console.WriteLine("----------------------");
    }

    public int calculate12Packs(int bagels)
    {
        int rest = bagels % 12;
        int numberOfPacks = (bagels - rest) / 12;
        return numberOfPacks;
    }

    public bool calculate6Pack(int bagels)
    {
        int bagelsLeftAfter12Packs = bagels % 12;
        if (bagelsLeftAfter12Packs >= 6) return true;
        return false;
    }

    public int calculateCoffeDeals(int bagels, int coffees)
    {
        if(bagels <= coffees)
            return bagels;
        return coffees;
    }
}
