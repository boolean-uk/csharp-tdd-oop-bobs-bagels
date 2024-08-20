// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");
Inventory inventory = new Inventory();
Basket basket = new Basket();
Item expectedItem = new Item("BGLO", "Bagel", 0.49, "Onion");
Person flier = new Person("Flier", Role.MANAGER);
basket.changeCapacity(12, flier);
basket.addItem("Bagel", "Onion");
basket.addItem("Bagel", "Onion");
basket.addItem("Bagel", "Onion");
basket.addItem("Bagel", "Onion");
basket.addItem("Coffee", "Black");
basket.addItem("Bagel", "Onion");
basket.addItem("Bagel", "Plain");
basket.addItem("Bagel", "Onion");
basket.addItem("Coffee", "White");
basket.addItem("Coffee", "Black");

basket.reciept();

basket.Discount();
Dictionary<Item, int> itemCount = basket.itemCount;


