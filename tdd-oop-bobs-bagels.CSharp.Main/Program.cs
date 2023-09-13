// See https://aka.ms/new-console-template for more information

using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Core
    {
        public List<Object> Basket = new List<Object>();
        public int capacity = 5;
        private bool _isManager = false;


        /*bool bacon = false;
        bool egg = false;
        bool cheese = false;
        bool cream_cheese = false;
        bool smoked_salmon = false;
        bool ham = false;*/

        /*Bagel OnionBagel = new Bagel("BGLO", 0.49f, "Bagel", "Onion");
        Bagel PlainBagel = new Bagel("BGLP", 0.39f, "Bagel", "Plain");
        Bagel EverythingBagel = new Bagel("BGLE", 0.49f, "Bagel", "Everything");
        Bagel SesameBagel = new Bagel("BGLS", 0.49f, "Bagel", "Sesame");*/

        List<bool> Fillings = new List<bool>();

        public void AddFillings(bool filling)
        {
            Fillings.Add(filling);
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

        public double Sum(List<object> basket)
        {
            throw new NotImplementedException();
        }
    }
}