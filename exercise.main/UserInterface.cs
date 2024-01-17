namespace exercise.main;

public class UserInterface
{
    private Basket _basket;
    private Menu _menu;
    private int _id = 1;

    public UserInterface()
    {
        _basket = new Basket();
        _menu = new Menu();
    }

    public void run()
    {
        bool running = true;
        while (running)
        {
            printMenu();
            string selection = Console.ReadLine().Trim();
            switch (selection)
            {
                case "0":
                    running = false;
                    break;
                    case "1":
                        addBagel();
                    break;
                    case "2":
                        addCoffee();
                    break;
                    case "3":
                        removeItem();
                    break;
                    case "4":
                        printReciept();
                    break;
                    case "5":
                        changeBasketSize();
                    break;
                default:
                    Console.WriteLine("Enter a number between 0 and 4");
                    break;
            }
        }
    }

    public void printMenu()
    {
        _basket.printProducts();
        Console.WriteLine("1. Add Bagel");
        Console.WriteLine("2. Add Coffee");
        Console.WriteLine("3. Remove item");
        Console.WriteLine("4. Print reciept");
        Console.WriteLine("5. Change basket size");
        Console.WriteLine("0. Exit");
    }

    public void addBagel()
    {
        throw new NotImplementedException();
    }

    public void addCoffee()
    {
        _menu.printCoffeeMenu();
        Console.WriteLine("Enter the Sku of the desired product: ");
        string input = Console.ReadLine().ToUpper().Trim();
        bool result = _basket.add(_id, input);
        Console.Clear();
        if (!result)
        {
            Console.WriteLine("Could not add coffee, make sure the Sku is correct and the basket has space for more items.");
        }
        else
        {
            _id++;
            Console.WriteLine("Coffee added");
        }
    }

    public void removeItem()
    {
        Console.WriteLine("Remove an item by entering it's id: ");
        string input = Console.ReadLine().Trim();
        int toRemove;
        if (int.TryParse(input, out toRemove))
        {
            Console.Clear();
            Console.WriteLine($"You entered: {toRemove}");

            bool result = _basket.remove(toRemove);
            if (!result)
            {
                Console.WriteLine("Failed to remove. Make sure the id you entered is correct.");
            }
            else
            {
                Console.WriteLine("Item removed.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    public void printReciept()
    {
        throw new NotImplementedException();
    }

    public void changeBasketSize()
    {
        Console.WriteLine("Set new basket size: ");
        string input = Console.ReadLine().Trim();
        int newSize;
        if (int.TryParse(input, out newSize))
        {
            Console.Clear();
            Console.WriteLine($"You entered: {newSize}");

            _basket.setCapacity(newSize);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }
}
