using System    ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main.Class_Items
{
    public class Product
    {
        private string _sku;
        protected double _price;
        public enum ProdType
        {
            Bagle,
            Coffee,
            Filling
        }
        private ProdType _type;
        private string _varaiant;

        public string SKU { get { return _sku; } }
        virtual public double Price { get { return _price; } }
        public ProdType Type { get { return _type; } }
        public string Varaiant {  get { return _varaiant; } }

        public Product(string sku, double price, ProdType type, string varaiant)
        {
            _sku = sku;
            _price = price;
            _type = type;
            _varaiant = varaiant;
        }
    }
}
