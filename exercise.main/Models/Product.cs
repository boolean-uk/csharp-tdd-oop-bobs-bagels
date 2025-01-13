using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public abstract class Product
    {
        private decimal price;

        public string SKU { get; set; }
        public string Variant { get; set; }
        public decimal Price
        {
            get => price;
            set => price = Math.Round(value, 2);
        }

        public override string ToString()
        {
            return $"{Variant} - ${Price}";
        }
    }
}
