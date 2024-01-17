using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private string _name;
        private string _SKU;
        private double _price;
        private string _variant;


        public Product(string sku)
        {
            _name = getName(sku);
            _SKU = sku;
            _price = setPrice(sku);
            _variant = setVariant(sku);

        }

        public Product()
        {
            //  Information information = new Information();
            _name = "Bagel";
            _SKU = "BGLO";
            _price = setPrice(_SKU);
           _variant = setVariant(_SKU);

        }

        private double setPrice(string sku)
        {
            Inventory inventory = new Inventory();
            return inventory.Prices[sku];
        }

        private string setVariant(string sku)
        {
            Inventory inventory = new Inventory();
            return inventory.Variants[sku];
        }

        private string getName(string sku)
        {
            string productname = "";
            if (sku.StartsWith('B')){
                productname = "Bagel";
            }else if (sku.StartsWith('C'))
            {
                productname = "Coffe";
            }
            else if (sku.StartsWith('F'))
            {
                productname = "Filling";
            }
               
            return productname;
        }


        public string Name { get =>  _name; set => _name = value;}
        public string SKU { get=> _SKU; set => _SKU = value;}
        public double Price { get => _price;}
        public string Variant { get => _variant;}
    }
}
