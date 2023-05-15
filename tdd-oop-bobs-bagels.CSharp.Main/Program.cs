using tdd_oop_bobs_bagels.CSharp.Main;

Inventory inventory = new Inventory();
var categories = inventory.GetUniqueNames();

Console.WriteLine("Welcome in Bob's (Burgers) Bagels!");
Console.WriteLine("MENU: ");
foreach (var category in categories)
{
    Console.WriteLine($"\t{category}: ");
    var items = inventory.getByName(category);
    foreach (var item in items)
    {
        
        Console.WriteLine($"\t{item.SKU}\t{item.Variant}: {item.Price}");
    }
    Console.WriteLine("");
}

var response = Console.ReadLine();