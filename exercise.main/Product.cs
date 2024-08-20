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

        public Product(Tuple<string, string, string, float> variant)
        {
            this.SKU = variant.Item1;
            this.name = variant.Item2;
            this.variant = variant.Item3;
            this.price = variant.Item4;
        }

        public string SKU { get; set; }
        public string name { get; set; }
        public string variant { get; set; }
        public float price { get; set; }
    }

    

    public class Bagel : Product
    {
        private List<Filling> fillings = new List<Filling>();

        public Bagel(Tuple<string, string, string, float>[] variants) 
            :base(variants)
        { 
                
        }

        public Bagel(Tuple<string, string, string, float> variant) 
            : base(variant)
        {

        }

        public List<Filling> getFillings() { return fillings; }

        //adds filling to bagel filling list and returns true or false
        //maybe in future, need bagel select otherwise
        public bool addFilling(Filling filling) { int fillingCount = fillings.Count; fillings.Add(filling); if (fillingCount < fillings.Count) { return true; }; return false; }

    }
    public class Coffee : Product
    {
        public Coffee(Tuple<string, string, string, float>[] variants)
            :base (variants)
        {

        }

        public Coffee(Tuple<string, string, string, float> variant)
    : base(variant)
        {

        }
    }
    public class Filling : Product
    {
        public Filling(Tuple<string, string, string, float>[] variants)
            :base(variants)
        {

        }

        public Filling(Tuple<string, string, string, float> variant)
    : base(variant)
        {

        }
    }
}
