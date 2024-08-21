using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {

        private int _id;
        public int Id
        { 
            get { return _id; } 
            set {  _id = value; }       
        }
        private string _sku;
        public string Sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        private string _name;
        public string Name
        {
            get => _name; set => _name = value;
        }
        private double _price;
        public double Price
        {
            get => _price; set => _price = value;
        }
        private string _variant;
        public string Variant
        {
            get => _variant; set => _variant = value;
        }

        private List<Filling> _fillings;
        public List<Filling> Fillings
        {
            get => _fillings; set => _fillings = value;
        }

        public Bagel(string sku, double price, string variant, string name)
        {
            this._sku = sku;
            this._name = name;
            this._price = price;
            this._variant = variant;
            this._fillings = new List<Filling>();
        }


        public List<Filling> GetFillings()
        {
            return this._fillings;
        }
        public string AddFilling(string nameFilling)
        {
            List<Item> inventory = Inventory.GetInventory();

            foreach (var item in inventory)
            {
                if (item.Name.Equals(nameFilling))
                {
                    Filling filling = (Filling)item;
                    _fillings.Add(filling);
                    return "Filling added";
                }
            }
            return "Filling not in inventory";
        }

        public bool RemoveFilling(string filling1)
        {
            foreach (var item in _fillings)
            {
                if (item.Name.Equals(filling1))
                {
                    _fillings.Remove(item);
                    return true;
                }
            }
            return false;  
        }

        public double GetPrice()
        {
            double price = this._price;

            foreach (var item in _fillings)
            {
                price += item.Price;
            }
            return price;
        }
    }
}
