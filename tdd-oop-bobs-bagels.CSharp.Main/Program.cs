// See https://aka.ms/new-console-template for more information

using tdd_oop_bobs_bagels.CSharp.Main;

bool start = true;

BagelsShop bagelsShop = new BagelsShop();


Console.WriteLine("Our menu \n");

foreach (var item in bagelsShop.Items)
{
    Console.WriteLine($"{item.Sku}: {item.Name} with {item.Description}, Cost: {item.Price} $");
}


while (true)
{
    Console.WriteLine("Place an order");

    Console.WriteLine("Choose a product");
    string choise = Console.ReadLine();

    foreach (var item in bagelsShop.Items)
    {

        if (item.Sku == choise.ToUpper() && item.Name != "Filling")
        {
            Console.WriteLine($"{item.Name} with {item.Description}, Cost: {item.Price} $");
            Items newItem = new Items(item.Sku, item.Price, item.Name, item.Description);
            bagelsShop.addBagel(newItem, Roles.Shopper);
            break;



        }
        else if (item.Sku == choise.ToUpper() && item.Name == "Filling")
        {
            //Console.WriteLine("test");

            Items newItem = new Items(item.Sku, item.Price, item.Name, item.Description);
            bool success = bagelsShop.AddFillings(newItem, Roles.Shopper);
            if (success)
            {

                Console.WriteLine($"{item.Name} with {item.Description}, Cost: {item.Price} $");
            }
            else
            {
                Console.WriteLine("You cant add a filling with no bagels in your basket");
            }
            break;



        }
        else if (choise == "q")
        {

            Console.WriteLine("Invalid product try again");
            break;

        }
    }
    Console.WriteLine("Do you add more ?");
    string order = Console.ReadLine();
    if (order == "n")
    {
        break;
    }



}


Console.WriteLine($"Your order costs {bagelsShop.TotalCost(Roles.Shopper)} $");