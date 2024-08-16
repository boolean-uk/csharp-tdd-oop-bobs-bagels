
using exercise.main;

Inventory inventory = new Inventory();

inventory.getInventory().ForEach(x => Console.WriteLine(x.id + " " + x.price + " " + x.name + " " + x.variant));



Console.WriteLine("Hello, World!");
