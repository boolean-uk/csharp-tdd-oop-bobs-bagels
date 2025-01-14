using exercise.main.Discount;
using exercise.tests;

namespace exercise.main
{
    public class TerminalStoreFront : IStoreFront
    {
        public TerminalStoreFront(Inventory inventory, Basket basket, DiscountManager discountManager, CashRegister cashRegister)
        {
            this.inventory = inventory;
            this.basket = basket;
            this.discountManager = discountManager;
            this.cashRegister= cashRegister;
            
        }
        public delegate void basketOpFunc(string sku, int amount);
        public delegate void baskeSetFunc(int amount);
        public delegate void baskePayFunc();

        public Inventory inventory  {get; set;}
        public Basket    basket     { get; set; }
        public DiscountManager discountManager { get; set; }
        public CashRegister cashRegister { get; set; }

        private List<string> _messages = new List<string>();
        private List<string> Messages
        {
            get
            {
                var temp = _messages.ToList();
                _messages.Clear();
                return temp;
            }
        }
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
        public void pay()
        {
            cashRegister.registerBasket(basket);
            Console.WriteLine("Type y to confirm");
            string userInput = Console.ReadLine().ToLower();
            if (userInput.Length == 1 && userInput[0] == 'y')
            {
                _messages.Add("Thanks, here is your reciept:\n");
                _messages.Add("------------------------------------------------------\n");
                _messages.Add(cashRegister.finalizePurchase(true));
                _messages.Add("\n------------------------------------------------------\n");
            }
            else
            {
                _messages.Add(cashRegister.finalizePurchase(false));
            }
        }
        public void run()
        {

            basketOpFunc addTo = new basketOpFunc(addToBasket);
            basketOpFunc remFrom = new basketOpFunc(removeFromBasket);
            baskeSetFunc setCapF = new baskeSetFunc(changeCap);
            baskePayFunc payF = new baskePayFunc(pay);

            string exitCommand = "/q";
            string userInput = "";
            while (exitCommand != userInput)
            {
                presentDeals();
                presentProducts();

                if (basket.isNotEmpty())
                    showBasket();
                
                var currentWarnings = basket.Warnings;
                Console.WriteLine(string.Join("\n", currentWarnings));
                Console.WriteLine(string.Join("\n", Messages));

                
                Console.WriteLine("\nInstructions: \n\t/q : quit\n\t/add SKU NR: add items\n\t/rem SKU NR: remove items\n\t/cap NR : change basket capacity\n\t/pay : finalize order");

                userInput = Console.ReadLine();
                Console.Clear();

                var args = userInput.Split(" ");
                if (args.Length > 0)
                {

                    CheckPrefromBasketOp(args, "/add", addTo);
                    CheckPrefromBasketOp(args, "/rem", remFrom);
                    changeBasketSetting(args, "/cap", setCapF);
                    execBasketFunc(args, "/pay", payF);

                }
            }
        }
        void CheckPrefromBasketOp(string[] args, string commandWord,basketOpFunc f)
        {
            if (args[0].ToLower() != commandWord)
                return;
            
            if (args.Length >= 3)
            {
                int parsed = 0;
                if (int.TryParse(args[2], out parsed))
                    f(args[1].ToUpper(), parsed);
                    
            }
            else
            {
                f(args[1].ToUpper(), 1);
            }
            
        }
        void changeBasketSetting(string[] args, string commandWord,baskeSetFunc f)
        {
            if (args[0].ToLower() != commandWord)
                return;
            
            if (args.Length >= 2)
            {
                int parsed = 0;
                if (int.TryParse(args[1], out parsed))
                    f( parsed);
                
            }
        }
        void execBasketFunc(string[] args, string commandWord, baskePayFunc f)
        {
            if (args[0].ToLower() != commandWord)
                return;

            f();
        }

        public void changeCap(int amount )
        {
            basket.setCapacity(amount);
        }
    }

}
