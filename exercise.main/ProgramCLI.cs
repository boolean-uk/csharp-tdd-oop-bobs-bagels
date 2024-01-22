using exercise.main.Products;
using exercise.main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class ProgramCLI
    {
        private Person? _customer;
        private Basket? _basket;
        private string _currency = "£";

        private Dictionary<string, float> _bagels;
        private Dictionary<string, float> _coffees;
        private Dictionary<string, float> _fillings;

        public ProgramCLI()
        {
            _fillings = PrintingUtils.GetAllFillingSKUs();
            _bagels = PrintingUtils.GetAllBagelSKUs();
            _coffees = PrintingUtils.GetAllCoffeeSKUs();

            Console.WriteLine("Excuse me, what is your name?");
            string? customerName = Console.ReadLine();

            if (customerName == null) 
            { 
                Console.WriteLine("Everyone here is deaf, so we cant server you if you are unable to enter your name"); 
            }
            else if (customerName.ToLower() == "bob")
            {
                Console.WriteLine("Oh hello there boss");
                _customer = new Person(customerName, true);
                _basket = _customer.GetBasket();
                Console.WriteLine("What would you like to order?");
                CoreProgramLoop();
            } else 
            {
                Console.WriteLine($"Hello {customerName}, welcome to Bob's Bagels!\n");
                _customer = new Person(customerName);
                _basket = _customer.GetBasket();
                Console.WriteLine("Bob's Bagels use a numerical ordering system.\nNow what would you like to order?");
                CoreProgramLoop();
            }


        }

        private void CoreProgramLoop() 
        {
            string? input;
            while (true) 
            {
                Console.WriteLine("[1] - Order a bagel");
                Console.WriteLine("[2] - Order a coffee");
                Console.WriteLine("[3] - Remove an item from my basket");
                Console.WriteLine("[4] - Pay for your order");
                Console.WriteLine("[0] - Exit the store");
                input = Console.ReadLine();

                if (input == null) 
                { 
                    CoreProgramLoop(); 
                    break; 
                }

                if (input == "0") 
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                IProduct? prod;
                switch (input) 
                {
                    case ("1"):
                        prod = AddBagel();
                        AddToBasket(prod);
                        break;

                    case ("2"):
                        prod = AddCoffee();
                        AddToBasket(prod);
                        break;
                    case ("3"):
                        RemoveProductFromBasket();
                        break;
                    case ("4"):
                        if (_basket.GetProducts().Count == 0)
                        {
                            Console.WriteLine("Your basket is empty...");
                            break;
                        }
                        else 
                        {
                            _basket.PrintReceipt();
                            return;
                        }
                    default:
                        CoreProgramLoop();
                        break;
                }

            }

        }

        private IProduct? AddBagel() 
        {
            int i = 0;
            List<Tuple<string, float>> SKUs = new List<Tuple<string, float>>();
            foreach (KeyValuePair<string, float> bagel in _bagels)
            {
                Tuple<string, string> fillDetail = TranslateSKU.GetNameAndVariantFromSKU(bagel.Key);
                Console.WriteLine($"[{i}] - {fillDetail.Item2} {fillDetail.Item1} for {bagel.Value}{_currency}");
                SKUs.Add(new Tuple<string, float>(bagel.Key, bagel.Value));
                i++;
            }
            Console.WriteLine("Which one would you like?");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return AddBagel();
            }
            else if (int.Parse(input) > i)
            {
                Console.WriteLine("Sorry, we don't offer off-menu fillings.");
                return AddBagel();
            }
            else
            {
                Console.WriteLine("Would you like a filling? (yes/no)");
                string? input2 = Console.ReadLine();
                if (input2 == null) 
                {
                    return null;
                } 
                else if (input2 == "no" || input2 == "n") 
                {
                    return ProductFactory.GenerateProduct(new string[] { SKUs[int.Parse(input)].Item1 });
                }

                Tuple<string, float> info = SKUs[int.Parse(input)];

                string[] fillings = GetBagelFillings(new string[] { });
                string[] completeItem = new string[] { info.Item1 };
                completeItem = [.. completeItem, .. fillings];
                IProduct tempProd = ProductFactory.GenerateProduct(completeItem);
                Tuple<string, string> item = TranslateSKU.GetNameAndVariantFromSKU(tempProd.GetSKUName());

                Console.Write($"Please confirm that you want a {item.Item2} {item.Item1.ToLower()}");
                if ((tempProd as Bagel).GetFilling().Count != 0) { Console.Write(" with "); }
                List<Filling> fillingList = (tempProd as Bagel).GetFilling();
                for (int j = 0; j < fillingList.Count; j++)
                {
                    Tuple<string, string> fillItem = TranslateSKU.GetNameAndVariantFromSKU(fillingList[j].SKUName);
                    if ((j+1 < fillingList.Count))
                    {
                        Console.Write($"{fillItem.Item2}, ");
                    }
                    else 
                    {
                        Console.Write($"{fillItem.Item2} ");
                    }
                    
                }
                Console.Write($"for {tempProd.GetPrice()} by writing 'yes' or 'no'.\n");
                string? input3 = Console.ReadLine();
                if (input3 != null && (input3.ToLower() == "yes" || input3.ToLower() == "y"))
                {
                    return ProductFactory.GenerateProduct(completeItem);
                }
                else
                {
                    return null;
                }
            }
        }

        private string[] GetBagelFillings(string[] others) 
        {
            string? res = AddFilling();
            string[] resArray;
            if (res != null)
            {
                resArray = new string[] { res };
            }
            else 
            {
                resArray = new string[] { };
            }

            Console.WriteLine("Would you like to add another filling? (yes/no)");
            string? input = Console.ReadLine();
            if (input != null && (input == "yes" || input == "y")) 
            {
                return GetBagelFillings(others.Concat(resArray).ToArray());
            }
            else if (res == null)
            {
                return others;
            }
            else
            {
                return others.Concat(resArray).ToArray();
            }
        }

        private IProduct? AddCoffee() 
        {
            int i = 0;
            List<Tuple<string, float>> SKUs = new List<Tuple<string, float>>();
            foreach (KeyValuePair<string, float> coffee in _coffees)
            {
                Tuple<string, string> fillDetail = TranslateSKU.GetNameAndVariantFromSKU(coffee.Key);
                Console.WriteLine($"[{i}] - {fillDetail.Item2} {fillDetail.Item1} for {coffee.Value}{_currency}");
                SKUs.Add(new Tuple<string, float>(coffee.Key, coffee.Value));
                i++;
            }
            Console.WriteLine("Which one would you like?");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return AddCoffee();
            }
            else if (int.Parse(input) > i)
            {
                Console.WriteLine("Sorry, we don't offer off-menu fillings.");
                return AddCoffee();
            }
            else 
            {
                Tuple<string, float> info = SKUs[int.Parse(input)];
                Tuple<string, string> item = TranslateSKU.GetNameAndVariantFromSKU(info.Item1);
                Console.WriteLine($"Please confirm that you want a {item.Item2} {item.Item1.ToLower()} for {info.Item2} by writing 'yes' or 'no'.");
                string? input2 = Console.ReadLine();
                if (input2 != null && (input2.ToLower() == "yes" || input2.ToLower() == "y"))
                {
                    return ProductFactory.GenerateProduct(new string[] { info.Item1 });
                }
                else 
                {
                    return null;
                }
            }
        }

        private string? AddFilling()
        {
            int i = 0;
            List<Tuple<string, float>> SKUs = new List<Tuple<string, float>>();
            foreach (KeyValuePair<string, float> fill in _fillings)
            {
                Tuple<string, string> fillDetail = TranslateSKU.GetNameAndVariantFromSKU(fill.Key);
                Console.WriteLine($"[{i}] - {fillDetail.Item2} {fillDetail.Item1} for {fill.Value}{_currency}");
                SKUs.Add(new Tuple<string, float>(fill.Key, fill.Value));
                i++;
            }
            Console.WriteLine("Which one would you like?");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return AddFilling();
            }
            else if (int.Parse(input) > i)
            {
                Console.WriteLine("Sorry, we don't offer off-menu fillings.");
                return AddFilling();
            }
            else 
            {
                Tuple<string, float> info = SKUs[int.Parse(input)];
                Tuple<string, string> item = TranslateSKU.GetNameAndVariantFromSKU(info.Item1);
                Console.WriteLine($"Please confirm that you want a {item.Item2} filling for {info.Item2}{_currency} by writing 'yes' or 'no'.");
                string? input2 = Console.ReadLine();
                if (input2 != null && (input2.ToLower() == "yes" || input2.ToLower() == "y"))
                {
                    return info.Item1;
                }
                else 
                {
                    return AddFilling();
                }
            }
        }

        private void AddToBasket(IProduct? prod) 
        {
            if (prod == null)
            {
            }
            else
            {
                _basket.AddItemToBasket(prod);
            }
        }

        private void RemoveProductFromBasket() 
        {
            Console.WriteLine("Your basket contains the following items:");
            List<IProduct> prods = _basket.GetProducts();
            for (int i = 0; i < prods.Count; i++) 
            {
                Tuple<string, string> details = TranslateSKU.GetNameAndVariantFromSKU(prods[i].GetSKUName());
                Console.WriteLine($"[{i}] - {details.Item2} {details.Item1.ToLower()} for {prods[i].GetPrice()}{_currency}");
            }
            Console.WriteLine("Indicate which you would like to remove by writing the associated number");
            string? input = Console.ReadLine();
            int val = int.Parse(input);
            if (input == null)
            {
                return;
            }
            else if (val > prods.Count) 
            {
                Console.WriteLine("You can't remove non-existant items...");
                return;
            }
            else
            {
                IProduct prod = prods[val];
                Tuple<string, string> details = TranslateSKU.GetNameAndVariantFromSKU(prod.GetSKUName());
                bool res = _basket.RemoveProductFromBasket(prod);
                if (res)
                {
                    Console.WriteLine($"Removed {details.Item2} {details.Item1.ToLower()} from your basket.");
                    return;
                }
                else 
                {
                    Console.WriteLine($"Could not remove {details.Item2} {details.Item1.ToLower()} from your basket.");
                    return;
                }
            }


        }
    }
}
