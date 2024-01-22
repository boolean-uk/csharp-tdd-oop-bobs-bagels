using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    public class Bagel : Item
    {
        private List<Item> Contents = new List<Item>();
        
        public Bagel(string sku, string name, float price, string variant) : base(sku, name, price, variant) 
        {
            _SKU = sku;
            _Name = name;
            _Price = price;
            _Variant = variant;
        }

        public void AddFillingToBagel(Item item)
        {
            Contents.Add(item);
        }

        public List<Item> ListFillings()
        {
            return Contents;
        }
    }

}
