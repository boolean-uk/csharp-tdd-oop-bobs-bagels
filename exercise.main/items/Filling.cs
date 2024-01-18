using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Filling
    {
        public string Sku {  get; set; }
        public double Price { get; set; }
        public FillingVariant Variant { get; set; }

        public Filling(FillingVariant variant)
        {
            Variant = variant;
            Sku = _fillingToData[variant].Sku;
            Price = _fillingToData[variant].Price;
        }

        private Dictionary<FillingVariant, (string Sku, double Price)> _fillingToData = new Dictionary<FillingVariant, (string Sku, double Price)>()
        {
            { FillingVariant.Bacon, ("FILB", 0.12d) }, { FillingVariant.Egg, ("FILE", 0.12d) },
            { FillingVariant.Cheese, ("FILC", 0.12d) }, { FillingVariant.CreamCheese, ("FILX", 0.12d) },
            { FillingVariant.SmokedSalmon, ("FILS", 0.12d) }, { FillingVariant.Ham, ("FILH", 0.12d) },
        };

        public double Cost() { return Price;  }
    }
}

public enum FillingVariant
{
    Bacon, Egg, Cheese, CreamCheese, SmokedSalmon, Ham
}
