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

        private List<Fillings> fillings_list; 

        public List<Fillings> Fillings_list { get { return fillings_list; } set { fillings_list = value; } }

        public struct Fillings
        {
            public string Id { get; }
            public string Variant { get; }
            public double Price { get; } 

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

        public override double getPrice()
        {
            if (fillings_list != null && fillings_list.Count > 0) 
            {
                double total_filling = 0;
                foreach (Fillings filling in fillings_list) { total_filling += filling.Price; }

                return base.Price + total_filling;
            }
            return base.Price;
        }

    }
}
