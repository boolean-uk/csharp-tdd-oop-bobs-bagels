using exercise.main.Products;
using exercise.main;

Inventory inv = new Inventory();
var basket = new Basket();

// two bagel onions
basket.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
basket.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));


// six bagel everything
for (int i = 0; i < 5; i++)
{
    basket.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
}

// twelve bagel plain
for (int i = 0; i < 11; i++)
{
    basket.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
}

// three coffee black
basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));

