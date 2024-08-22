using exercise.main;

Basket basket =  new Basket();
basket.AddItem(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
basket.AddItem(new Coffee("COFC", 1.29, "Coffee", "Cappucino"));
basket.AddItem(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
basket.AddItem(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
basket.AddItem(new Coffee("COFC", 1.29, "Coffee", "Cappucino"));

Console.WriteLine(basket.PrintReceipt);



//var counted = basket.BasketItems.GroupBy(x => x.SKU).ToDictionary(g => g.Key, g => g.Count());

//foreach (var item in counted)
//{
//    Console.WriteLine($"{item.Key} - {item.Value}");
//}
    