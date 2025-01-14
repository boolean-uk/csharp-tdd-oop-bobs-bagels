// See https://aka.ms/new-console-template for more information
using exercise.main.Products;
using exercise.main.UI;

List<Product> _products = new List<Product>();

for (int i = 0; i < 12; i++)
{
    _products.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
}

for (int i = 0; i < 6; i++)
{
    _products.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
}

for (int i = 0; i < 2; i++)
{
    _products.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
}


for (int i = 0; i < 3; i++)
{
    _products.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
}
Reciept rec = new Reciept(_products);
Console.WriteLine(rec.ToString());
