using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum FillingType { Bacon, Egg, Cheese, CreamedCheese, SmokedSalmon, Ham }

    public class Filling
    {
        private FillingType _filling;
        public double price { get; } = 0.12;
        Dictionary<FillingType, string> fillingToSKU = new Dictionary<FillingType, string>()
        {
            { FillingType.Bacon, "FILB" },
            { FillingType.Egg, "FILE" },
            { FillingType.Cheese, "FILC" },
            { FillingType.CreamedCheese, "FILX" },
            { FillingType.SmokedSalmon, "FILS" },
            { FillingType.Ham, "FILH" },
        };

        public Filling(FillingType filling)
        {
            _filling = filling;
        }
    }

    /*
    public class Bacon : Filling { public Bacon() { SKU = "FILB"; } }
    public class Egg : Filling { public Egg() { SKU = "FILE"; } }
    public class Cheese : Filling { public Cheese() { SKU = "FILC"; } }
    public class CreamCheese : Filling { public CreamCheese() { SKU = "FILX"; } }
    public class SmokedSalmon : Filling { public SmokedSalmon() { SKU = "FILS"; } }
    public class Ham : Filling { public Ham() { SKU = "FILH"; } } */

}
