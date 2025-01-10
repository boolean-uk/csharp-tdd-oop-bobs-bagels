

using exercise.main;
using exercise.main.Items;

List<Item> items = [
    new Bagel("Everything", .49f),
    new Bagel("Everything", .49f),
    new Bagel("Sesame", .49f),
    new Coffee("Black", .99f),
    new Coffee("White", 1.19f),
];

Bagel bagel = new Bagel("Everything", .49f);
Filling filling = new Filling("Bacon", .12f);
bagel.AddFilling(filling);items.Add(bagel); 
Receipt r = Receipt.GetReceipt(items);

foreach (var item in r.ItemList)
{
    Console.WriteLine($"{item.Key} ||| {item.Value.Left.Name} - {item.Value.Right}");
}