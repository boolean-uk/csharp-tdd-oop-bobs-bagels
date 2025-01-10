using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Item
    {

        public string actualname;
        public override string name => actualname;
        public Coffee(string id)
        {
            actualname = id;
        }

        public override Dictionary<string, double> prices => new Dictionary<string, double>()
        { {"COFB", 0.99}, {"COFW", 1.19}, {"COFC", 1.29}, {"COFL", 1.29}};

        public override double totalcost => 0;

        public override Dictionary<string, int> itemcount => Initialization(prices);

        public List<Filling> useless = new List<Filling>();
        public override List<Filling> bagelfillings => throw new NotImplementedException();

        public Dictionary<string, int> Initialization(Dictionary<string, double> pricess)
        {
            Dictionary<string, int> returndict = new Dictionary<string, int>();
            foreach (string key in pricess.Keys)
            {
                if (returndict.ContainsKey(key))
                {
                    returndict[key] += 1;
                }
                else
                {
                    returndict.Add(key, 1);
                }



            }
            return returndict;
        }
    }
}
