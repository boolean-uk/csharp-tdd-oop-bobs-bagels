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

        public Filling(string fillingName)
        {
            this._fillingName = fillingName;
            if (_allowedFillings.Contains(fillingName.ToLower()))
            {
                this._price = 0.12f;
                this._sku += fillingName.Substring(0, 1).ToUpper();
            }
            else
            {
                throw new InvalidDataException("Non existent filling, please check the spelling of the filling");
            }
        }

        public float Price { get => _price;}
    
    }
}
