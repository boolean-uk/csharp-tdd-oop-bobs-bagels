using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Bagel : Item
    {
        public string actualname;
        public override string name => actualname;
        public List<Filling> fillings = new List<Filling>();
        public double actualtotalcost = 0;
        public override double totalcost => actualtotalcost;

        public Bagel(string id)
        {
            actualname = id;

        }
        public override Dictionary<string, double> prices => new Dictionary<string, double>()
        { {"BGLO", 0.49}, {"BGLP", 0.39}, {"BGLE", 0.49}, {"BGLS", 0.49}};

        

        public void AddFilling(Filling filling)
        {
            fillings.Add(filling);
            actualtotalcost += filling.prices[filling.actualname];
        }

        

    }
}


