// See https://aka.ms/new-console-template for more information
using exercise.main;
using exercise.main.Communication;
using exercise.main.Models;
ICommunicator communicator = new ConsoleCommunicator();
OrderHandler orderHandler = new OrderHandler();


bool isRunning = true;
Console.WriteLine("Welcome to Bobs Bagels! \n" +
    "What would you like to do?");

Console.WriteLine("1. Place an order");
Console.WriteLine("2. Exit");


string input = Console.ReadLine();
if (input == "2")
{
    isRunning = false;
}
Basket yourBasket = new Basket(30);

Console.WriteLine("You have selected: " + input);
while (isRunning)
{
    if(HandleOrder(out Product orderedProduct))
    {
        yourBasket.Add(orderedProduct);
    }
    else
    {
        yourBasket.Add(orderedProduct);

        Console.WriteLine("Your order is: ");
        foreach (Product product in yourBasket.Products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine("Your total price is: " + yourBasket.GetPriceWithDiscounts());
        Console.WriteLine("Would you like to place your order? (y/n)");

        string placeOrder = Console.ReadLine();
        if (placeOrder == "y")
        {
            yourBasket.GetPriceWithDiscounts();
            orderHandler.PlaceOrder(yourBasket, communicator);
            isRunning = false;
        }
    }
}

bool HandleOrder(out Product orderedProduct)
{
    Console.WriteLine("What would you like to order?");
    List<Product> products = Inventory.GetStandaloneProducts();

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(i + 1 + ". " + products[i].ToString());
    }

    string order = Console.ReadLine();
    int orderNumber = int.Parse(order);
    Product selectedProduct = products[orderNumber - 1];
    Console.WriteLine("You have selected: " + selectedProduct.Variant);
    if (selectedProduct is Bagel bagel)
    {
        Console.WriteLine("Would you like to add fillings? (y/n)");
        string addFillings = Console.ReadLine();
        if (addFillings == "y")
        {
            List<Filling> fillings = Inventory.GetFillings();
            for (int i = 0; i < fillings.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + fillings[i].Variant + " - " + fillings[i].Price);
            }
            string fillingOrder = Console.ReadLine();
            int fillingOrderNumber = int.Parse(fillingOrder);
            Product selectedFilling = fillings[fillingOrderNumber - 1];
            bagel.AddFilling((Filling)selectedFilling);
        }
    }
    orderedProduct = selectedProduct;
    
    Console.WriteLine("Would you like to add another product? (y/n)");
    string addAnother = Console.ReadLine();
   
    return addAnother == "y";
}