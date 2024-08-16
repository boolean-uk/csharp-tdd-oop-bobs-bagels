using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        Tuple<string, string, string, float>[] variants;

        public Tuple<string, string, string, float>[] getVariants() { return variants; }

        public Product(Tuple<string, string, string, float>[] variants) 
        { 
            this.variants = variants;
        }

        string SKU { get; set; }
        string name { get; set; }
        string variant { get; set; }
        int price { get; set; }
    }

    

    public class Bagel : Product
    {

        public Bagel(Tuple<string, string, string, float>[] variants) 
            :base(variants)
        { 
                
        }

        Tuple<string, string, string, float>[] variants =
        {
            Tuple.Create("BGLO", "Bagel", "Onion", 0.49f),
            Tuple.Create("BGLP", "Bagel", "Plain", 0.39f),
            Tuple.Create("BGLE", "Bagel", "Everything", 0.49f),
            Tuple.Create("BGLS", "Bagel", "Sesame", 0.49f),
        };

        public string SKU { get ; set; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public int price { get ; set ; }

    }
    public class Coffee : Product
    {

        public Coffee(Tuple<string, string, string, float>[] variants)
            :base (variants)
        {

        }
        Tuple<string, string, string, float>[] variants =
        {
            Tuple.Create("COFB", "Coffee", "Black", 0.99f),
            Tuple.Create("COFW", "Coffee", "White", 1.19f),
            Tuple.Create("COFC", "Coffee", "Capuccino", 1.29f),
            Tuple.Create("COFL", "Coffee", "Latte", 1.29f),
        };

        public string SKU { get ; set ; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public int price { get ; set ; }
    }
    public class Filling : Product
    {
        public Filling(Tuple<string, string, string, float>[] variants)
            :base(variants)
        {

        }

        Tuple<string, string, string, float>[] variants =
        {
            Tuple.Create("FILB", "Filling", "Bacon", 0.12f),
            Tuple.Create("FILE", "Filling", "Egg", 0.12f),
            Tuple.Create("FILC", "Filling", "Cheese", 0.12f),
            Tuple.Create("FILX", "Filling", "Cream Cheese", 0.12f),
            Tuple.Create("FILS", "Filling", "Smoked Salmon", 0.12f),
            Tuple.Create("FILH", "Filling", "Ham", 0.12f),
        };

        public string SKU { get ; set ; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public int price { get ; set ; }
    }
}
