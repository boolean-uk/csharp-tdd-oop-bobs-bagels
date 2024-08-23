using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Merchandise
    {
        private string _name;
        private string _sku;

        //private float _price;
        private List<string> _allowedFillings;
        private bool _falseOrder = false;


        public string Sku { get => _sku; }

        public List<string> AllowedFillings { get => _allowedFillings; }
        public bool FalseOrder { get => _falseOrder; set => _falseOrder = value; }
        //public float Price { get => _price; set => _price = value; }
    }
}
