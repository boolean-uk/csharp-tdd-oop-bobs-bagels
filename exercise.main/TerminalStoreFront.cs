using exercise.main.Discount;

namespace exercise.main
{
    public class TerminalStoreFront : IStoreFront
    {
        public TerminalStoreFront(Inventory inventory, Basket basket, DiscountManager discountManager)
        {
            this.inventory = inventory;
            this.basket = basket;
            this.discountManager = discountManager;
            
        }
        public delegate void basketOpFunc(string sku, int amount);
        public delegate void baskeSetFunc(int amount);

        public Inventory inventory  {get; set;}
        public Basket    basket     { get; set; }
        public DiscountManager discountManager { get; set; }

        public void addToBasket(string sku, int amount = 1 )
        {
            basket.addProduct(sku, amount);
        }

        public void presentDeals()
        {
            Console.WriteLine("Deals: -----------------------------------------------");
            Console.Write(discountManager.stringify());
            Console.WriteLine("\n------------------------------------------------------\n");
        }

        public void presentProducts()
        {
            Console.WriteLine("Menu: ------------------------------------------------");
            Console.Write(inventory.stringify());
            Console.WriteLine("------------------------------------------------------");
        }

        public void removeFromBasket(string sku, int amount = 1)
        {
            basket.removeProduct(sku, amount);
        }

        public void showBasket()
        {
            Console.WriteLine("\nBasket: ----------------------------------------------");
            Console.WriteLine(basket.stringify(discountManager));
            Console.WriteLine("------------------------------------------------------");
        }
        public void exit()
        {
            throw new NotImplementedException();
        }
        public void run()
        {

            basketOpFunc addTo = new basketOpFunc(addToBasket);
            basketOpFunc remFrom = new basketOpFunc(removeFromBasket);
            baskeSetFunc setCapF = new baskeSetFunc(changeCap);

            string exitCommand = "/q";
            string userInput = "";
            while (exitCommand != userInput)
            {
                presentDeals();
                presentProducts();
                if (basket.isNotEmpty())
                {
                    showBasket();
                }
                var currentWarnings = basket.Warnings;
                Console.WriteLine(string.Join("\n", currentWarnings));
                
                Console.WriteLine("\nInstructions: \n\t/q : quit\n\t/add SKU NR: add items\n\t/rem SKU NR: remove items\n\t/cap NR : change basket capacity");

                userInput = Console.ReadLine();
                Console.Clear();

                var args = userInput.Split(" ");
                if (args.Length > 0)
                {

                    CheckPrefromBasketOp(args, "/add", addTo);
                    CheckPrefromBasketOp(args, "/rem", remFrom);
                    changeBasketSetting(args, "/cap", setCapF);

                }
            }

        }
        void CheckPrefromBasketOp(string[] args, string commandWord,basketOpFunc f)
        {
            if (args[0].ToLower() == commandWord)
            {
                if (args.Length >= 3)
                {
                    int parsed = 0;
                    if (int.TryParse(args[2], out parsed))
                    {
                        f(args[1].ToUpper(), parsed);
                    }
                }
                else
                {
                    f(args[1].ToUpper(), 1);
                }
            }
        }
        void changeBasketSetting(string[] args, string commandWord,baskeSetFunc f)
        {
            if (args[0].ToLower() == commandWord)
            {
                if (args.Length >= 2)
                {
                    int parsed = 0;
                    if (int.TryParse(args[1], out parsed))
                    {
                        f( parsed);
                    }
                }

            }
        }

        public void changeCap(int amount )
        {
            basket.setCapacity(amount);
        }
    }

}
