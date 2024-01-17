using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private string _name = "Bagel";
        private string _SKU = "BGLO";
        private double _price = 0.49;
        private string _variant = "Onion";
        private List<Filling> _Fillings = new List<Filling>();


        public Product(string sku)
        {
                _name = getName(sku);
                _SKU = sku;
             _price = setPrice(sku); 
                _variant = setVariant(sku);         

        }
        public Product()
        {
            _name = "Bagel";
            _SKU = "BGLO";
            _price = 0.49;
            _variant = "Onion";

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

        public bool AddFilling(string skuFilling)
        {
            if (_name == "Bagel") {
                Filling filling = new Filling(skuFilling);
                _Fillings.Add(filling);
                return true;
            }
            else
            {
                return false;
            }

        }

        public string Name { get =>  _name; set => _name = value;}
        public string SKU { get=> _SKU; set => _SKU = value;}
        public double Price { get => _price;}
        public string Variant { get => _variant;}

        public List<Filling> Fillings { get => _Fillings; }
    }

    public class Filling
    {
        public Filling(string sku) {
            _SKU = sku;
            _variant = setVariant(sku);
        }
        private string setVariant(string sku)
        {
            Inventory inventory = new Inventory();
            return inventory.Fillings[sku];
        }

        private string _name = "Filling";
        private string _SKU = "FILB";
        private double _price = 0.12;
        private string _variant = "Bacon";


        public string Name { get => _name; }
        public string SKU { get => _SKU; }
        public double Price { get => _price; }
        public string Variant { get => _variant; }


    }
}
