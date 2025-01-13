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

        public Dictionary<string, Fillings> StockItems = new Dictionary<string, Fillings>()
        {
            {"FILB", new Fillings("Filling", "Bacon", 0.12)},
            {"FILE", new Fillings("Filling", "Egg", 0.12)},
            {"FILC", new Fillings("Filling", "Cheese", 0.12)},
            {"FILX", new Fillings("Filling", "Cream Cheese", 0.12)},
            {"FILS", new Fillings("Filling", "Smoked Salmon", 0.12)},
            {"FILH", new Fillings("Filling", "Ham", 0.12)},
        };

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

        public Bagel(string name, string variant, double price) : base(name, variant, price) { }


        public void addFillingByID(string id)
        {
            if (StockItems.ContainsKey(id)) { fillings_list.Add(StockItems[id]); }
            else { throw new Exception("Order not in stock"); }
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
