using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Merchandise
    {
        private float _price;
        private string _fillingName;
        private string _sku = "FIL"; 
        private List<string> _allowedFillings = new()
        {
            "bacon",
            "egg",
            "cheese",
            "cream cheese",
            "smoked salmon",
            "ham"
        };
        private bool _falseOrder = false;

        public Filling(string fillingName)
        {
            this.FillingName = fillingName;
            if (_allowedFillings.Contains(fillingName.ToLower()))
            {
                if (fillingName == "cream cheese")
                {
                    this._sku += 'X';
                }
                else
                {
                this._price = 0.12f;
                this._sku += fillingName.Substring(0, 1).ToUpper();
                }
            }

            else
            {
                this._falseOrder = true;
            }

        }

        public float Price { get => _price;}
        public string FillingName { get => _fillingName; set => _fillingName = value; }
        public string SKU { get => _sku;  }
    }
}
