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
        private string _id;
        private float _price;
        private List<string> _allowedFillings;
        private bool _falseOrder = false;

        public string Id { get => _id; }
        public string Sku { get => _sku; }
        public string Id1 { get => _id; }
        public List<string> AllowedFillings { get => _allowedFillings; }
        public bool FalseOrder { get => _falseOrder; set => _falseOrder = value; }
        public float Price { get => _price; set => _price = value; }
    }
}
