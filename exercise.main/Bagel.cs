using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Product
    {
        private List<Filling> _fillings = [];

        public void AddFilling(Filling filling)
        {   if(ConfirmFilling(filling))
            {
                Fillings.Add(filling);
            }
        }

        public bool ConfirmFilling(Filling filling)
        {
            Console.WriteLine($"The price of the product is {filling.Price}, would you like to add to basket? y/n");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                return true;
            }
            Console.WriteLine("Hope you find something else you'd like");
            return false;
        }

        public Bagel(string sku, float price, ProductType type, string variant) : base(sku, price, type, variant)
        {
        }

        public List<Filling> Fillings { get { return _fillings; } set { _fillings = value; } }
    }
}
