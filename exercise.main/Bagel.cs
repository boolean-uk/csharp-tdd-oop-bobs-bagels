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

        private List<Filling> fillings_list; 

        public List<Filling> Fillings_list { get { return fillings_list; } set { fillings_list = value; } }

        public static List<Filling> StockItems = new List<Filling>()
        {
             new Filling("FILB", "Filling", "Bacon", 0.12),
             new Filling("FILE", "Filling", "Egg", 0.12),
             new Filling("FILC", "Filling", "Cheese", 0.12),
             new Filling("FILX", "Filling", "Cream Cheese", 0.12),
             new Filling("FILS", "Filling", "Smoked Salmon", 0.12),
             new Filling("FILH", "Filling", "Ham", 0.12)
        };

        public struct Filling
        {
            public string Id { get; }
            public string Variant { get; }
            public string Name { get; }
            public double Price { get; } 

            public Filling(string id, string variant, string name, double price)
            {
                Id = id;
                Variant = variant;
                Name = name;
                Price = price;
            }

            public string getFillingToString()
            {
                return $"{Id}, {Name}, {Variant}, {Price}";
            }
        }

        public Bagel(string id, string name, string variant, double price) : base(id, name, variant, price) { }

        public Bagel(string id, string name, string variant, double price, List<Filling> fillings) : base(id, name, variant, price) 
        {
            fillings_list = fillings;
        }


        public override List<Filling> getFillings() 
        {
            return fillings_list;
        }

        public override void addFilling(string order)
        {
            var fillingOrder = StockItems.FirstOrDefault(x => x.Id == order);

            if (fillingOrder.Id == null) { throw new Exception("Order not in stock"); }
            else { fillings_list.Add(fillingOrder); }
        }


        public override void removeFilling(string order)
        {
            var fillingOrder = fillings_list.FirstOrDefault(x => x.Id == order);

            if (fillingOrder.Id == null) { throw new Exception("No such item in basket"); }
            else { fillings_list.Remove(fillingOrder); } 
        }


        public override double getPrice()
        {
            if (fillings_list != null && fillings_list.Count > 0) 
            {
                return base.Price + fillings_list.Sum(f => f.Price);
            }
            return base.Price;
        }


    }
}
