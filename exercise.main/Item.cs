using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Item
    {
        private float price;
        private string SKU;
        private string type;
        private string variant;
        private List<Item> subItems;
        private Dictionary<string, float>priceList = new Dictionary<string, float>();
    }
}
