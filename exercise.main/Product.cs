using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Product
    {
        string SKU { get; set; }
        string name { get; set; }
        string variant { get; set; }
        int price { get; set; }
    }

    public class Bagel : Product
    {
        Tuple<string, string, string, float>[] variants = 
        { 
            Tuple.Create("BGLO", "Bagel", "Onion", 0.49f),
            Tuple.Create("BGLP", "Bagel", "Plain", 0.39f),
            Tuple.Create("BGLE", "Bagel", "Everything", 0.49f),
            Tuple.Create("BGLS", "Bagel", "Sesame", 0.49f),
        };
        public string SKU { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string variant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //Tuple<string, string, string, float>[] Product.variants => throw new NotImplementedException();
    }
    public class Coffee : Product
    {
        Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("COFB", "Coffee", "Black", 0.99f),
            Tuple.Create("COFW", "Coffee", "White", 1.19f),
            Tuple.Create("COFC", "Coffee", "Capuccino", 1.29f),
            Tuple.Create("COFL", "Coffee", "Latte", 1.29f),
        };

        public string SKU { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string variant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    public class Filling : Product
    {
        Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("FILB", "Filling", "Bacon", 0.12f),
            Tuple.Create("FILE", "Filling", "Egg", 0.12f),
            Tuple.Create("FILC", "Filling", "Cheese", 0.12f),
            Tuple.Create("FILX", "Filling", "Cream Cheese", 0.12f),
            Tuple.Create("FILS", "Filling", "Smoked Salmon", 0.12f),
            Tuple.Create("FILH", "Filling", "Ham", 0.12f),
        };

        public string SKU { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string variant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
