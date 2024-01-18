namespace exercise.main;

public class Menu
{
    Dictionary<string, Tuple<double, string, string>> _menu;

    public Menu()
    {
        _menu = new Dictionary<string, Tuple<double, string, string>>
        {
            { "BGLO", new Tuple<double, string, string>(0.49, "Bagel", "Onion") },
            { "BGLP", new Tuple<double, string, string>(0.39, "Bagel", "Plain") },
            { "BGLE", new Tuple<double, string, string>(0.49, "Bagel", "Everything") },
            { "BGLS", new Tuple<double, string, string>(0.49, "Bagel", "Sesame") },
            { "COFB", new Tuple<double, string, string>(0.99, "Coffee", "Black") },
            { "COFW", new Tuple<double, string, string>(1.19, "Coffee", "White") },
            { "COFC", new Tuple<double, string, string>(1.29, "Coffee", "Capuccino") },
            { "COFL", new Tuple<double, string, string>(1.29, "Coffee", "Latte") },
            { "FILB", new Tuple<double, string, string>(0.12, "Filling", "Bacon") },
            { "FILE", new Tuple<double, string, string>(0.12, "Filling", "Egg") },
            { "FILC", new Tuple<double, string, string>(0.12, "Filling", "Cheese") },
            { "FILX", new Tuple<double, string, string>(0.12, "Filling", "Cream Cheese") },
            { "FILS", new Tuple<double, string, string>(0.12, "Filling", "Smoked Salmon") },
            { "FILH", new Tuple<double, string, string>(0.12, "Filling", "Ham") }
        };
    }

    public Tuple<double, string, string> getItem(string sku)
    {
        if (_menu.ContainsKey(sku.Trim())) return _menu[sku.Trim()];

        return new Tuple<double, string, string>(0.00, "", "");
    }

    public void printSkuMenu(string type)
    {
        var items = _menu.SelectMany(x => x.Key.Contains(type) ? new[] { x } : Enumerable.Empty<KeyValuePair<string, Tuple<double, string, string>>>()).ToList();
        foreach (var item in items)
        {
            Console.WriteLine($"Sku: {item.Key} Product: {item.Value.Item2} {item.Value.Item3} Price: {item.Value.Item1}");
        }
    }
}
