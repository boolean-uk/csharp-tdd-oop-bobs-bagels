using exercise.main;

Console.WriteLine("Welcome to Bobs Bagel\nMenu:");
DefaultInventory.Inventory.ForEach(Item =>
{
    Console.WriteLine($"{Item.Name} {Item.Variant} - {Item.Price}");
});
Console.WriteLine("What do you want to add to your basket?");
string itemVariant = Console.ReadLine();
Item item = DefaultInventory.Inventory.Find(i => i.Variant == itemVariant);
if (item.Name == Name.Filling)
{
    Console.WriteLine($"Price for filling is {item.Price}");
}

