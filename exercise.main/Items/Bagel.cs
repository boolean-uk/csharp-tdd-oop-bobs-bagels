﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Bagel
    {
        // Define fields:
        private string _SKU;
        private double _price;
        private string _name = "Bagel"; // "Bagel" by default
        private string _variant;

        // Constructor 1 (depent on the input string)
        public Bagel(string variant)
        {
            if (variant == "Onion") {
                set(0.49, "BGLO");
                this._variant = variant;
            }
            else if(variant == "Plain") {
                set(0.39, "BGLP");
                this._variant = variant;
            }
            else if (variant == "Eveything")
            {
                set(0.49, "BGLE");
                this._variant = variant;
            }
            else if (variant == "Sesame")
            {
                set(0.49, "BGLS");
                this._variant = variant;
            }
            else {
                set(0, "Invalid"); 
                    };
        }

        internal void set(double price, string SKU) { 
            this._SKU = SKU; 
            this._price = price;
        }

        public double price { get => _price; }
        public string name { get => _name; }   
        public string variant { get => _variant; }
        public string SKU { get { return _SKU; } }

    }
}
