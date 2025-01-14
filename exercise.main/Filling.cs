using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling
    {

        public string actualname;
        public Filling(string id)
        {
            actualname = id;
        }

        public Dictionary<string, double> prices => new Dictionary<string, double>()
             { {"FILB", 0.12}, {"FILE", 0.12}, {"FILC", 0.12}, {"FILX", 0.12}, {"FILS", 0.12}, {"FILH", 0.12 } };
    }
}
