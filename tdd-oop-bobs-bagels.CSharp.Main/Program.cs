// See https://aka.ms/new-console-template for more information

using NUnit.Framework.Constraints;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Core
    {
        // The Basket where all items are added
        public List<Object> Basket = new List<Object>();
        public int capacity = 20;

        private bool _isManager = false;

        // The budget the customer has so that he does not overspend
        public float customerbudget = 10f;

        // Here I never added the fillings that would be able to add because it didn't work out
        public List<string> Fillings = new List<string>();

        //I never used this list in the end
        /*public string bacon= "bacon";
        public string egg = "egg";
        public string cheese = "cheese";
        public string cream_cheese = "cream_cheese";
        public string smoked_salmon = "smoked_salmon";
        public string ham = "ham";*/

        // These are the Fillings that are used for the FillingsCounter() and AddFillings() methods.
        public bool hasbacon = false;
        public bool hasegg = false;
        public bool hascheese = false;
        public bool hascream_cheese = false;
        public bool hassmoked_salmon = false;
        public bool hasham = false;

        // Counter for Fillings
        public int fillingscounter = 0;

        // Instantiate the Bagels
        public Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        public Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        public Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        public Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");

        // Instantiate the Coffees
        public Coffee BlackCoffee = new Coffee("COFB", 0.99f, "Coffee", "Black");
        public Coffee WhiteCoffee = new Coffee("COFW", 1.19f, "Coffee", "White");
        public Coffee Capuccino = new Coffee("COFC", 1.29f, "Coffee", "Capuccino");
        public Coffee Latte = new Coffee("COFL", 1.29f, "Coffee", "Latte");


        // This FillingsCounter() below is called from the AddFillings() down below so see that first.
        public void FillingsCounter()
        {
            if (hasbacon == true) { fillingscounter++; customerbudget = customerbudget - 0.12f;  hasbacon = false; }
            if (hasegg == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hasegg = false; }
            if (hascheese == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hascheese = false; }
            if (hascream_cheese == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hascream_cheese = false; }
            if (hassmoked_salmon == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hassmoked_salmon = false; }
            if (hasham == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hasham = false; }

        }

        // AddFillings() makes the chosen Filling true after the customer choose it and then calls FillingsCounter();
        // FillingsCounter(); then increases float fillingscounter, changes the customerbudget and do the bool false again.

        public void AddFillings(string filling)
        {
            Console.WriteLine("Each filling cost 0.12");
            if (customerbudget >= 0.12f)
            {
                if (filling == "bacon") { hasbacon = true; } else { hasbacon = false; }
                if (filling == "egg") { hasegg = true; } else { hasegg = false; }
                if (filling == "cheese") { hascheese = true; } else { hascheese = false; }
                if (filling == "cream_cheese") { hascream_cheese = true; } else { hascream_cheese = false; }
                if (filling == "smoked_salmon") { hassmoked_salmon = true; } else { hassmoked_salmon = false; }
                if (filling == "ham") { hasham = true; } else { hasham = false; }
            }
            
            FillingsCounter();
        }


        // these take the properties of Bagel or Coffee so that I can use the Price property below
        public PropertyInfo[] RetrieveProperties(object Bagel)
        {
            var type = Bagel.GetType();

            return type.GetProperties();
        }
        public PropertyInfo[] RetrievePropertiesCoffee(object Coffee)
        {
            var type = Coffee.GetType();

            return type.GetProperties();
        }


        public string AddCoffee(List<object> Basket, object Coffee)
        {
            this.Basket = Basket;
            if (Coffee == BlackCoffee)
            {
                if (Basket.Count < capacity) // check if I have room in the basket
                {
                    RetrievePropertiesCoffee(BlackCoffee); // so that I can use .Price of bagel.
                    if (BlackCoffee.Price <= customerbudget) // check if I have enough money
                    {
                        Console.WriteLine($"Price of BlackCoffee is {BlackCoffee.Price}");
                        Basket.Add(Coffee);
                        customerbudget = customerbudget - BlackCoffee.Price; // update budget
                        return "Coffee added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Coffee == WhiteCoffee)
            {
                if (Basket.Count < capacity)
                {
                    RetrievePropertiesCoffee(WhiteCoffee);
                    if (WhiteCoffee.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of WhiteCoffee is {WhiteCoffee.Price}");
                        Basket.Add(Coffee);
                        customerbudget = customerbudget - WhiteCoffee.Price;
                        return "Coffee added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Coffee == Capuccino)
            {
                if (Basket.Count < capacity)
                {
                    RetrievePropertiesCoffee(Capuccino);
                    if (Capuccino.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of Capuccino is {Capuccino.Price}");
                        Basket.Add(Coffee);
                        customerbudget = customerbudget - Capuccino.Price;
                        return "Coffee added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Coffee == Latte)
            {
                if (Basket.Count < capacity)
                {
                    RetrievePropertiesCoffee(Latte);
                    if (Latte.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of Latte is {Latte.Price}");
                        Basket.Add(Coffee);
                        customerbudget = customerbudget - Latte.Price;
                        return "Coffee added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            return "Anything else?";
        }


        // same as AddCoffee for the Bagellllssss
        public string AddBagel(List<Object> Basket, object Bagel)
        {
            this.Basket = Basket;
            if (Bagel == OnionBagel)
            {
                if (Basket.Count < capacity)
                {
                    RetrieveProperties(OnionBagel); // so that I can use .Price of bagel.
                    if (OnionBagel.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of OnionBagel is {OnionBagel.Price}");
                        Basket.Add(Bagel);
                        customerbudget = customerbudget - OnionBagel.Price;
                        return "bagel added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Bagel == PlainBagel)
            {
                if (Basket.Count < capacity)
                {
                    RetrieveProperties(PlainBagel);
                    if (PlainBagel.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of OnionBagel is {PlainBagel.Price}");
                        Basket.Add(Bagel);
                        customerbudget = customerbudget - PlainBagel.Price;
                        return "bagel added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Bagel == EverythingBagel)
            {
                if (Basket.Count < capacity)
                {
                    RetrieveProperties(EverythingBagel);
                    if (EverythingBagel.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of OnionBagel is {EverythingBagel.Price}");
                        Basket.Add(Bagel);
                        customerbudget = customerbudget - EverythingBagel.Price;
                        return "bagel added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            else if (Bagel == SesameBagel)
            {
                if (Basket.Count < capacity)
                {
                    RetrieveProperties(SesameBagel);
                    if (SesameBagel.Price <= customerbudget)
                    {
                        Console.WriteLine($"Price of OnionBagel is {SesameBagel.Price}");
                        Basket.Add(Bagel);
                        customerbudget = customerbudget - SesameBagel.Price;
                        return "bagel added!";
                    }
                }
                else { return "Basket is full or budget is low!"; }
            }
            return "Anything else?";
        }


        public string RemoveBagel(List<Object> Basket, object Bagel)
        {
            this.Basket = Basket;
            if (Basket.Contains(Bagel)) // Check if they are inside Basket
            {
                Basket.Remove(Bagel);
                return "bagel removed!";
            }
            return "you haven't added this one!";
        }
        public string RemoveCoffee(List<Object> Basket, object Coffee)
        {
            this.Basket = Basket;
            if (Basket.Contains(Coffee)) // Check if they are inside Basket
            {
                Basket.Remove(Coffee);
                return "Coffee removed!";
            }
            return "you haven't added this one!";
        }


        public void UpdateCapacity(List<Object> Basket, int newcap)
        {
            _isManager = true;
            capacity = newcap;
        }

        // Total cost of Bagels in basket
        public float Sum(List<object> Basket)
        {
            float sum = 0;
            foreach (Bagel bagel in Basket)
            {
                RetrieveProperties(bagel); // so that i can use property Price
                sum = sum + bagel.Price;
            }
            
            sum = sum + (fillingscounter * 0.12f ); // if there are fillings added
            return sum;
        }

        // same for coffee
        public float SumCoffee(List<object> Basket)
        {
            float sum = 0;
            foreach (Coffee coffee in Basket)
            {
                RetrievePropertiesCoffee(coffee);
                sum = sum + coffee.Price;
            }

            return sum;
        }

        // this does not work I dont know why.
        // I tried making one some for bagel and coffee together above but it throws the same error
        /*public float SumAll(List<object> Basket)
        {
            float sumall = 0f;
            sumall = Sum(Basket) + SumCoffee(Basket);
            return sumall;
        }*/

        public float SumAll(List<object> Basket)
        {
            float sum = 0f;
            foreach (var item in Basket)
            {
                if (item.GetType() == typeof(Bagel))
                {
                    sum += ((Bagel)item).Price;
                }
                if (item.GetType() == typeof(Coffee))
                {
                    sum += ((Coffee)item).Price;
                }

            }
            int baggelcount = DiscountBagel(Basket);
            int coffeecount = DiscountCoffee(Basket);
            if (baggelcount >= 12)
            {
                sum = sum - 1.89f;
            }else if (baggelcount >= 6)
            {
                sum = sum - 0.45f;
            }
            if (coffeecount >= 1 && baggelcount >= 1)
            {
                sum = sum - 0.53f;
            }

            return sum;
        }

        public int DiscountBagel(List<object> Basket)
        {
            int bagelcount = 0;
            foreach (var item in Basket)
            {
                if (item.GetType() == typeof(Bagel))
                {
                    bagelcount += 1;
                }
            }
            return bagelcount;
        }
        public int DiscountCoffee(List<object> Basket)
        {
            int coffeecount = 0;
            foreach (var item in Basket)
            {
                if (item.GetType() == typeof(Coffee))
                {
                    coffeecount += 1;
                }
            }
            return coffeecount;
        }


    }
}