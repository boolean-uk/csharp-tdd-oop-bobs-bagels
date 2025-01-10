// See https://aka.ms/new-console-template for more information
using exercise.main;

Store store = new Store(5, new List<Item> {
    new Bagel("BGLE", "Bagel", 0.49, "Everything"),
    new Bagel("BGLS", "Bagel", 0.49, "Sesame"),
    new Coffee("COFB", "Coffee", 0.99, "Black"),
    new Coffee("COFW", "Coffee", 1.19, "White"),
    new Coffee("COFC", "Coffee", 1.29, "Cappuccino"),
    new Coffee("COFL", "Coffee", 1.29, "Latte"),
    new Filling("FILB", "Filling", 0.12, "Bacon"),
    new Filling("FILE", "Filling", 0.12, "Egg"),
    new Filling("FILC", "Filling", 0.12, "Cheese"),
    new Filling("FILX", "Filling", 0.12, "Cream Cheese"),
    new Filling("FILS", "Filling", 0.12, "Smoked Salmon"),
    new Filling("FILH", "Filling", 0.12, "Ham")
    });
Customer customer = new Customer("Steven", store);
store._customerList.Add(customer);

Console.WriteLine(customer.order("BGLE").CalculateTotalCost());


foreach(Item item in store._itemsInStock)
{
    Console.WriteLine($"{item.SKU} - {item.name} {item.variant}: {item.cost}");
    
}
