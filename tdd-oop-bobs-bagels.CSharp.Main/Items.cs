using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Items
    {
        private string _sku;
        private decimal _price;
        private string _name;
        private string _description;

        public Items(string SKU, decimal price, string name, string description)
        {
            _sku = SKU;
            _price = price;
            _name = name;
            _description = description;
        }
        public string Sku { get { return _sku; } }
        public decimal Price { get { return _price;} }
        public string Name { get { return _name; } }
        public string Description { get { return _description;} }

    }
}
