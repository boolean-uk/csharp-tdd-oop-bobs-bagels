using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public abstract class Item
    {
        #region Properties
        private string _sku;
        private double _price;
        private string _variant;
        private int _quantity;

        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
        #endregion

        protected Item()
        {
        }
        
        protected Item(string skuID, double price, string variant)
        {
            _sku = skuID;
            _price = price;
            _variant = variant;
        }

        protected Item(string skuID) 
        {
        }
    }
}
