using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Coffe
    {
        // Define fields:
        private string _SKU;
        private double _price;
        private string _name = "Coffe"; // "Filling" by default
        private string _variant;

        // Constructor 1 (depent on the input string)
        public Coffe(string variant)
        {
            if (variant == "Black")
            {
                set(0.99, "COFB");
                this._variant = variant;
            }
            else if (variant == "White")
            {
                set(1.19, "COFW");
                this._variant = variant;
            }
            else if (variant == "Capuccino")
            {
                set(1.29, "COFC");
                this._variant = variant;
            }
            else if (variant == "Latte")
            {
                set(1.29, "COFL");
                this._variant = variant;
            }
            else
            {
                set(0, "Invalid");
            };
        }

        internal void set(double price, string SKU)
        {
            this._SKU = SKU;
            this._price = price;
        }

        public double price { get => _price; }
        public string name { get => _name; }
        public string variant { get => _variant; }
        public string SKU { get => _SKU; }
    }
}
