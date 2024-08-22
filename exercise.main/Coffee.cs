using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee: Merchandise
    {
        private Dictionary<string, float> _allowedFlavor = new Dictionary<string, float>()
        {
            {"black",0.99f},
            {"white",1.19f},
            {"cappuccino",1.29f},
            {"latte",1.29f}
        };
        private bool _falseOrder = false;
        private string _type;
        private string _sku;
        private float _price;

        public Coffee(string type)
        {
            if (_allowedFlavor.ContainsKey(type.ToLower().Trim()))
            {
                this._price = _allowedFlavor[type.ToLower().Trim()];
                this._type = type;
                this._sku = "COF" + type.Substring(0, 1).ToUpper();
            }
            else
            {
                this._falseOrder = true;
            }
        }

        public float Price { get => _price; }
        public string Type { get => _type;}
        public string SKU { get => _sku;}
    }
}
