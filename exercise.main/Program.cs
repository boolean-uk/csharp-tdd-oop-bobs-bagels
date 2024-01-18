using exercise.main;

Basket basket = new Basket(3);
basket.addItem("BGLO");
basket.addItem("BGLP");
basket.addItem("COFB");

Console.WriteLine(basket.receipt.printTotal());