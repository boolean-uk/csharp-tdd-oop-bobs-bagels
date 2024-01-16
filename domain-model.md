```C#
class Bagel {
    // Members
        public string _sku_ { get; set; }
        public float _price { get; set; }
        public string _name { get; set; }
        public string _varient { get; set; }
        public List<string> fillings { get; set; } 
}

class BobsGagels {
    // Members
        
        public List<Bagel> _inventory = new list<bagel> {
            // bobs inventory
        };
    // Methods 
        public bool IsItemInStock(string _sku); // return true if given bagel is in stock, else retuyrn false
}

class Basket {
    // Members
        private int _capacity { get; set; }
        public List<Bagel> _bagels = new List<Bagel>();
    
    //Methods
        public float CalculateBasketContent(); // returns total cost of _bagels content
        public float GetFillingCost(string _sku); // returns the price of the filling on a specified bagel 
        public int ChangeBasketCapacity(int newCapacity); // changes the mas capacity of basket
        public Basket CreateBasket(); // return new basket wich _capacity
    
    // Helper methods
        private ifFull(); // return true if basket is full, false if not
        private ContainsInBasket(string _sku); // return true if _bagels contains given bagel, else return false
}

class BagelOrderSys {
    // Members
        private Basket basket
    // Methods
        public bool AddToBasket(Basket basket, string _sku); // return true if 
        public bool RemoveFromBasket(Basket basket, string _sku);
}
```