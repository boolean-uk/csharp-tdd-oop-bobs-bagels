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
    }
}
