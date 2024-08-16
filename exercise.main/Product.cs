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
        float price { get; set; }
    }

    

    public class Bagel : Product
    {

        public Bagel(Tuple<string, string, string, float>[] variants) 
            :base(variants)
        { 
                
        }

        public Bagel(Tuple<string, string, string, float> variant) 
            : base(null)
        {
            this.SKU = variant.Item1;
            this.name = variant.Item2;
            this.variant = variant.Item3;
            this.price = variant.Item4;
        }

        public string SKU { get ; set; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public float price { get ; set ; }

    }
    public class Coffee : Product
    {

        public Coffee(Tuple<string, string, string, float>[] variants)
            :base (variants)
        {

        }

        public Coffee(Tuple<string, string, string, float> variant)
    : base(null)
        {
            this.SKU = variant.Item1;
            this.name = variant.Item2;
            this.variant = variant.Item3;
            this.price = variant.Item4;
        }

        public string SKU { get ; set ; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public float price { get ; set ; }
    }
    public class Filling : Product
    {
        public Filling(Tuple<string, string, string, float>[] variants)
            :base(variants)
        {

        }

        public Filling(Tuple<string, string, string, float> variant)
    : base(null)
        {
            this.SKU = variant.Item1;
            this.name = variant.Item2;
            this.variant = variant.Item3;
            this.price = variant.Item4;
        }

        public string SKU { get ; set ; }
        public string name { get ; set ; }
        public string variant { get ; set ; }
        public float price { get ; set ; }
    }
}
