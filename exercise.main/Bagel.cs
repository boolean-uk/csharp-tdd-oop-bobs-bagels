using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Iproduct
    {

        public string Name { get; set; }
        public string SKU { get; set; }
        public float Price { get; set; }
        public string Variant { get; set; }
        public List<Iproduct> fillings { get; set; }
        public Bagel(string name, string sKU, float price, string variant)
        {
            Name = name;
            SKU = sKU;
            Price = price;
            Variant = variant;
            fillings = new List<Iproduct>();
        }

        public float GetPrice()
        {
            return Price;
        }
        public void AddFilling(Iproduct filling)
        {
            fillings.Add(filling);
        }

        public string GetVariant()
        {
            return this.Variant;
        }
        public string GetName()
        {
            return this.Name;
        }
        public string GetSKU()
        {
            return SKU;
        }

        public List<Iproduct> GetFillings()
        {
            return fillings;
        }
    }
}
