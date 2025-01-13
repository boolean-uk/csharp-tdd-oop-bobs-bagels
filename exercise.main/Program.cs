// See https://aka.ms/new-console-template for more information
using exercise.main;

Store store = new Store(25, new List<Item> {
    new Bagel("BGLP", "Bagel", 0.39, "Plain"),
    new Bagel("BGLO", "Bagel", 0.49, "Onion"),
    new Bagel("BGLE", "Bagel", 0.49, "Everything"),
    new Bagel("BGLS", "Bagel", 0.49, "Sesame"),
    new Coffee("COFB", "Coffee", 0.99, "Black"),
    new Coffee("COFW", "Coffee", 1.19, "White"),
    new Coffee("COFC", "Coffee", 1.29, "Cappuccino"),
    new Coffee("COFL", "Coffee", 1.29, "Latte"),
    new Filling("FILB", "Filling", 0.12, "Bacon"),
    new Filling("FILC", "Filling", 0.12, "Cheese"),
    new Filling("FILX", "Filling", 0.12, "Cream Cheese"),
    new Filling("FILE", "Filling", 0.12, "Egg"),
    new Filling("FILS", "Filling", 0.12, "Smoked Salmon"),
    new Filling("FILH", "Filling", 0.12, "Ham")
    });
Customer customer = new Customer("Steven", store);
store._customerList.Add(customer);

store._customerList[0].order("COFB");
store._customerList[0].order("BGLP");
store._customerList[0].order("FILS");
store._customerList[0].order("COFE");
store._customerList[0].order("BGLO");
store._customerList[0].order("COFB");
store._customerList[0].order("BGLP");
store._customerList[0].order("FILX");
store._customerList[0].order("BGLP");
store._customerList[0].order("COFB");
store._customerList[0].order("BGLO");
store._customerList[0].order("FILC");
store._customerList[0].order("COFL");
store._customerList[0].order("FILH");
store._customerList[0].order("BGLS");
store._customerList[0].order("BGLO");
store._customerList[0].order("BGLO");
store._customerList[0].order("FILE");
store._customerList[0].order("BGLP");
store._customerList[0].order("COFL");


store._customerList[0]._basket.applyDiscounts();

store._customerList[0]._basket.applyDiscounts();
foreach (Item item in store._customerList[0]._basket._items)
{
    Console.WriteLine($"{item.SKU} - {item.name} {item.variant}: {item.cost}");
}

Console.WriteLine(store._customerList[0]._basket.CalculateTotalCost());
