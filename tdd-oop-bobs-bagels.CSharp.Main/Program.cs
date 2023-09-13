// See https://aka.ms/new-console-template for more information

using NUnit.Framework.Constraints;
using System.Linq.Expressions;
using System.Reflection;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Core
    {
        public List<Object> Basket = new List<Object>();
        public int capacity = 5;
        private bool _isManager = false;

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

        int fillingscounter = 0;

        public Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        public Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        public Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        public Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");


        public void FillingsCounter()
        {
            if (hasbacon == true) { fillingscounter++; hasbacon = false; }
            if (hasegg == true) { fillingscounter++; hasegg = false; }
            if (hascheese == true) { fillingscounter++; hascheese = false; }
            if (hascream_cheese == true) { fillingscounter++; hascream_cheese = false; }
            if (hassmoked_salmon == true) { fillingscounter++; hassmoked_salmon = false; }
            if (hasham == true) { fillingscounter++; hasham = false; }

        }

        public void AddFillings(string filling)
        {
            if (filling == "bacon") { hasbacon = true; } else { hasbacon = false; }
            if (filling == "egg") { hasegg = true; } else { hasegg = false; }
            if (filling == "cheese") { hascheese = true; } else { hascheese = false; }
            if (filling == "cream_cheese") { hascream_cheese = true; } else { hascream_cheese = false; }
            if (filling == "smoked_salmon") { hassmoked_salmon = true; } else { hassmoked_salmon = false; }
            if (filling == "ham") { hasham = true; } else { hasham = false; }
            FillingsCounter();
        }
        

        public string AddBagel(List<Object> Basket, object Bagel)
        {
            this.Basket = Basket;
            if (Basket.Count < capacity)
            {
                Basket.Add(Bagel);
                return "bagel added!";
            }
            return "basket is full!";
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