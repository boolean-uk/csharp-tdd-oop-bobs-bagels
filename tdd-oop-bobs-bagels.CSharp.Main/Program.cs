// See https://aka.ms/new-console-template for more information
using csharp_tdd_oop_bobs_bagels.Source;

Main products = new Main();

products.SeedData();

foreach (Item x in products.Products)
{

    Console.WriteLine($"{x.SKU} {x.Price} {x.Name} {x.Variant}");

}

/*Item item = products.Products.ElementAt(0);

products.addBagel(item);

Console.WriteLine(products.Basket.ElementAt(0));*/