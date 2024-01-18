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
        private FillingType fillingType;
        public string SKU { get; }
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
            fillingType = filling;
            SKU = fillingToSKU[filling];
        }

        public string name() => fillingType.ToString();
    }

}
