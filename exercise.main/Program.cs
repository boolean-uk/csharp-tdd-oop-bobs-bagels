using exercise.main;
using exercise.main.Products;

Inventory inv = new Inventory();
var basket = new Basket();
List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
foreach (IProduct item in items)
{
    basket.Add(item);
    Console.WriteLine(item.ToString());

}
