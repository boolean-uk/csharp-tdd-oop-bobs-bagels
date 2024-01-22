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
        private int _id = 0;
        
        
        public Product(string sku)
        {
            getItemMembers(sku);    

        }
        public Product()
        {
            _name = "Bagel";
            _SKU = "BGLO";
            _price = 0.49;
            _variant = "Onion";

        }


        public void getItemMembers(string sku)
        {
            Inventory inventory = new Inventory();
            foreach (InventoryProduct item in inventory.Items)
            {
                if (item.Sku == sku)
                {
                    Name = item.Name;
                    Price = item.Price;
                    Variant = item.Variant;

                };
            }

        }


        public string Name { get =>  _name; set => _name = value;}
        public string Sku { get=> _SKU; set => _SKU = value;}
        public double Price { get => _price; set => _price = value; }
        public string Variant { get => _variant; set => _variant = value; }
        public int ID { get => _id; set => _id = value; }

    }

}
