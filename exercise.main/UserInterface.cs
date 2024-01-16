namespace exercise.main;

public class UserInterface
{
    public void run()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            printMenu();
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    running = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void printMenu()
    {
        Console.WriteLine("0. Exit");
    }
}
