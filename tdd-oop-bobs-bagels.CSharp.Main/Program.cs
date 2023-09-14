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
        public List<Object> Basket = new List<Object>();
        public int capacity = 5;
        private bool _isManager = false;
        public float customerbudget = 10f;

        public List<string> Fillings = new List<string>();
        
        /*public string bacon= "bacon";
        public string egg = "egg";
        public string cheese = "cheese";
        public string cream_cheese = "cream_cheese";
        public string smoked_salmon = "smoked_salmon";
        public string ham = "ham";*/

        public bool hasbacon = false;
        public bool hasegg = false;
        public bool hascheese = false;
        public bool hascream_cheese = false;
        public bool hassmoked_salmon = false;
        public bool hasham = false;

        public int fillingscounter = 0;

        public Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        public Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        public Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        public Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");


        public void FillingsCounter()
        {
            if (hasbacon == true) { fillingscounter++; customerbudget = customerbudget - 0.12f;  hasbacon = false; }
            if (hasegg == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hasegg = false; }
            if (hascheese == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hascheese = false; }
            if (hascream_cheese == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hascream_cheese = false; }
            if (hassmoked_salmon == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hassmoked_salmon = false; }
            if (hasham == true) { fillingscounter++; customerbudget = customerbudget - 0.12f; hasham = false; }

        }

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
            if (Basket.Contains(Bagel))
            {
                Basket.Remove(Bagel);
                return "bagel removed!";
            }
            return "you haven't added this one!";
        }


        public void UpdateCapacity(List<Object> Basket, int newcap)
        {
            _isManager = true;
            capacity = newcap;
        }


        // this takes the properties of Bagel so that I can use Price below
        public PropertyInfo[] RetrieveProperties(object Bagel)
        {
            var type = Bagel.GetType();

            return type.GetProperties();
        }

        public float Sum(List<object> Basket)
        {
            float sum = 0;
            foreach (Bagel bagel in Basket)
            {
                RetrieveProperties(bagel);
                sum = sum + bagel.Price;

            }
            sum = sum + (fillingscounter * 0.12f );
            return sum;
        }
    }
}