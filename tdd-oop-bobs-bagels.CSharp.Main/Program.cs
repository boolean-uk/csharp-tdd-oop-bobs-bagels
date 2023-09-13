// See https://aka.ms/new-console-template for more information

using NUnit.Framework.Constraints;
using System.Reflection;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Core
    {
        public List<Object> Basket = new List<Object>();
        public int capacity = 5;
        private bool _isManager = false;

        public List<bool> Fillings = new List<bool>();
        bool bacon = false;
        bool egg = false;
        bool cheese = false;
        bool cream_cheese = false;
        bool smoked_salmon = false;
        bool ham = false;


        Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");


        public void AddFillings(bool filling)
        {
            Fillings.Add(bacon);
            Fillings.Add(egg);
            Fillings.Add(cheese);
            Fillings.Add(cream_cheese);
            Fillings.Add(smoked_salmon);
            Fillings.Add(ham);
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
            // RetrieveProperties(OnionBagel); if I do this
            // I can then use item.Price and add it to the sum, but because 
            // its not yet inside I cannot use Price.
            // I cannot populate the Sum() here because its not called here
            // I want some help in this.
            
            float sum = 0.49f + 0.39f;
            foreach (Object item in Basket)
            {
                RetrieveProperties(item);
                // item.Price
            }
            return sum;
        }
    }
}