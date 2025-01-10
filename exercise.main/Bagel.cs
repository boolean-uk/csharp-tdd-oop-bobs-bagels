using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        private string variant;

        public struct Fillings
        {
   
            public string Id { get; }
            public string Variant { get; }
            public double Price { get { return Price; } set { Price = value; } }

            public Fillings(string id, string variant, double price)
            {
                Id = id;
                Variant = variant;
                Price = price;
            }
        }

        public Bagel(string id, string variant, double price) : base(id, price) 
        {
            this.variant = variant;
        }



        public override string getVariant()
        {
            return variant;
        }

        //public double getPrice(){
        //    return base.getPrice() + this.Fillings.Price;
        //}

    }
}
