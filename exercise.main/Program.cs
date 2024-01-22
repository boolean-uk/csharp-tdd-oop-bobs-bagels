// See https://aka.ms/new-console-template for more information
using exercise.main;
using exercise.main.Products;
using System.Diagnostics;
using System.Reflection.Emit;
Basket basket1 = new Basket();

Person manager = new Person("admin");
Basket basket = new Basket();
basket.changeCapacity(manager, 100);
Dictionary<string, int> order = new Dictionary<string, int>();
order.Add("BGLO", 4);
order.Add("BGLP", 12);
order.Add("BGLE", 22);

Coffee coffeBlack = new Coffee("COFB");
basket.AddProduct(coffeBlack);
basket.AddProduct(coffeBlack);
basket.AddProduct(coffeBlack);
Bagel bagel = new Bagel("BGLO");
Filling bacon = new Filling("FILB");
Bagel bagel2 = new Bagel("BGLP");
Filling cheese = new Filling("FILC");
bagel.AddFilling(bacon);
bagel2.AddFilling(cheese);
basket.AddProduct(bagel);
basket.AddProduct(bagel2);

foreach (string key in order.Keys)
{
    for (int i = 0; i < order[key]; i++)
    {
        Bagel product = new Bagel(key);
        basket.AddProduct(product);
    }
}
basket.PrintReciept();


