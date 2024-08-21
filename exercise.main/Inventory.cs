using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory 
    {

        private List<Discount> _discounts = new List<Discount> {
            new(){SKU="BGLO",  Name ="Bagel", Variant="Onion", Price= 0.49d, SpecialOffers = $"6 for {Discount.SixBagels}"},
            new(){SKU="BGLP",  Name ="Bagel", Variant="Plain", Price= 0.39d, SpecialOffers = $"6 for {Discount.SixBagels}"},
            new(){SKU="BGLE",  Name ="Bagel", Variant="Everything", Price= 0.49d, SpecialOffers = $"6 for {Discount.SixBagels}"},
            new(){SKU="BGLS",  Name ="Bagel", Variant="Sesame", Price= 0.49d, SpecialOffers = $"6 for {Discount.SixBagels}"},
            new(){SKU="BGLO",  Name ="Bagel", Variant="Onion", Price= 0.49d, SpecialOffers = $"12 for {Discount.TwelveBagels}"},
            new(){SKU="BGLP",  Name ="Bagel", Variant="Plain", Price= 0.39d, SpecialOffers = $"12 for {Discount.TwelveBagels}"},
            new(){SKU="BGLE",  Name ="Bagel", Variant="Everything", Price= 0.49d, SpecialOffers = $"12 for {Discount.TwelveBagels}"},
            new(){SKU="BGLS",  Name ="Bagel", Variant="Sesame", Price= 0.49d, SpecialOffers = $"12 for {Discount.TwelveBagels}"},
            new(){SKU="COFB",  Name ="Coffee", Variant="Black", Price= 0.99d, SpecialOffers = $"Coffe and Bagel for {Discount.CoffeeAndBagel}"}

        };

        private List<InventoryProducts> _products = new List<InventoryProducts> {

            new(){SKU="BGLO", Price= 0.49d, Name ="Bagel", Variant="Onion"},
            new(){SKU="BGLP", Price= 0.39d, Name ="Bagel", Variant="Plain"}, 
            new(){SKU="BGLE", Price= 0.49d, Name ="Bagel", Variant="Everything"}, 
            new(){SKU="BGLS", Price= 0.49d, Name ="Bagel", Variant="Sesame"}, 
            new(){SKU="COFB", Price= 0.99d, Name ="Coffee", Variant="Black"},
            new(){SKU="COFW", Price= 1.19d, Name ="Coffee", Variant="White"},
            new(){SKU="COFC", Price= 1.29d, Name ="Coffee", Variant="Capuccino"},
            new(){SKU="COFL", Price= 1.29d, Name ="Coffee", Variant="Latte"},
            new(){SKU="FILB", Price= 0.12d, Name ="Filling", Variant="Bacon"},
            new(){SKU="FILE", Price=0.12d, Name ="Filling", Variant="Egg"},
            new(){SKU="FILC", Price= 0.12d, Name="Filling", Variant="Cheese"},
            new(){SKU="FILX", Price=0.12d, Name ="Filling", Variant="Cream Cheese"},
            new(){SKU="FILS", Price=0.12d, Name ="Filling", Variant="Smoked Salmon"},
            new(){SKU="FILH", Price=0.12d, Name ="Filling", Variant="Ham"},

        };

        private string _storeName = "Bob's Bagels";
        private List<Basket> _baskets;
        private Basket _basket;

      

        public Inventory() { }





        public double BagelPrice(string variant)
        {

            double price = 0;
            foreach (var product in _products)
            {
                if(variant == product.Variant)
                {
                    price = product.Price;
                }
            }

            return price;
        }

        public double FillingPrice(string variant)
        {
            double price = 0;

            
                foreach (var product in _products)
                {
                    if (variant == product.Variant)
                    {
                        price = product.Price;
                    }
                }
            return price;
        }


        
    

        public List<InventoryProducts> ShowList()
        {
            

            return _products;
        }

        //Extension task 2
        public string GetStoreName()
        {
            return _storeName;
        }

        public List<Discount> ShowDiscountList()
        {
            return _discounts;
        }

        public InventoryProducts GetItemBySKU(string SKU)
        {
            InventoryProducts product = null;

            foreach (var prod in _products)
            {
                if(prod.SKU == SKU)
                    product = prod;
            }

            return product;
        }

        public List<InventoryProducts> Products { get { return _products; } }
        public List<Basket> Baskets { get { return _baskets; } set { _baskets = value; } }
        public Basket Basket { get { return _basket; } set { _basket = value; } }


    }
}
