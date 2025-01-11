using exercise.main;

Inventory inv = new Inventory();
var basket = new Basket();
List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

foreach (Item item in items)
{
    basket.Add(item);
    Console.WriteLine(item.ToString());
}

