```C#
interface IProduct {
    // Members
        stirng Sku { get; }
        decimal Price { get; }
        stirng Category { get; }
        string Variant { get; }
}

interface IInventory {
    // Members
        bool IsItemInStock(string sku); // return true if it is, false if not
        decimal GetProductPrice(string sku); // return the price  of given product sku
        Product GetFilling(string sku); // return the Product obj with right sku, throw new Exeprion else
        Product GetProduct(string sku); // return the Product obj with right sku, throw new Exeprion else
}

interface IFillable : IProduct {
    // Members
        List<Tuple<string, decimal>> _fillings { get; set; }
}

class Product : IProduct, IFillable {
    // Constructor
        public Product() {
            // set
        }
}

class Inventory : IInventory {
    // Members
        private Dictionary<string, Product> _inventory = new Dictionary<string, Product> {
            // Create
        };
}

class basket {
    // Members
        private IInventory Inventory;
        private int Capacity;
        private List<IProduct> _product new List<IProduct>();

    //Constructor    
        public basket() {
            // set
        }
        
    // Methods
        public bool AddToBasketIfExists(string sku, List<stirng> fillins, out IProduct product); // adds sku product in basket if it exists and add fillings if it is a bagel, throw exeption for invalid sku
        public bool RemoveFromBasket(string sku); // remove given product from _product, throw new Exxeption if product is not in the the list
        public void ChangeBasketCapacity(int newCapacity); // changes the basket size by given index if over 0, throw new Exception if it is lower or equal to 0
        public int GetCapacity(); // returns the capacity on the basket
    
    //Helper methods
        private bool isFill(); // return true if full, else false

}



```