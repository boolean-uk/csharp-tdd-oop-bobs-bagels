
using exercise.main;

Inventory inventory = new Inventory();

inventory.getInventory().ForEach(x => Console.WriteLine(x.id + " " + x.price + " " + x.name + " " + x.variant));

Person person = new Person("Bob", Role.MANAGER);
Basket basket = new Basket();

Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");
Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");

basket.changeBasketCapacity(7, person.role);
basket.addItem(plainBagel);

//basket.removeBagelOrItem(plainBagel);


basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);



Console.WriteLine("Hello, World!");
