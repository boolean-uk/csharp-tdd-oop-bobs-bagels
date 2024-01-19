// See https://aka.ms/new-console-template for more information


using exercise.main;

Person bob = new Person("Customer 1", true);
Basket basket = bob.GetBasket();

basket.AddItemToBasket(new string[] { "BGLO", "FILC" });
basket.AddItemToBasket(new string[] { "BGLO", "FILX" });
basket.AddItemToBasket(new string[] { "BGLO", "FILX" });
basket.AddItemToBasket(new string[] { "BGLO", "FILX" });
basket.AddItemToBasket(new string[] { "BGLP", "FILC" });
basket.AddItemToBasket(new string[] { "BGLP", "FILC", "FILX", "FILH" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "BGLE", "FILS" });
basket.AddItemToBasket(new string[] { "BGLE", "FILC" });
basket.AddItemToBasket(new string[] { "COFB" });

basket.PrintReceipt();