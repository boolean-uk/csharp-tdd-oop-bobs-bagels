using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Filling
    {
        // Define fields:
        private string _SKU;
        private double _price;
        private string _name = "Filling"; // "Filling" by default
        private string _variant;

        // Constructor 1 (depent on the input string)
        public Filling(string variant)
        {
            if (variant == "Bacon")
            {
                set(0.12, "FILB");
                this._variant = variant;
            }
            else if (variant == "Egg")
            {
                set(0.12, "FILE");
                this._variant = variant;
            }
            else if (variant == "Cheese")
            {
                set(0.12, "FILC");
                this._variant = variant;
            }
            else if (variant == "Cream Cheese")
            {
                set(0.12, "FILX");
                this._variant = variant;
            }
            else if (variant == "Smoked Salmon")
            {
                set(0.12, "FILS");
                this._variant = variant;
            }
            else if (variant == "Ham")
            {
                set(0.12, "FILH");
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
