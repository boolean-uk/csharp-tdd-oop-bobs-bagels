using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class AddOn : IMenuItem
    {
        private string _itemID;
        private string _name;
        private decimal _price;
        private decimal _basketFootprint;


        public AddOn(string id, string name, decimal price, decimal basketFootprint)
        {
            throw new NotImplementedException();
        }

        public string ItemID { get => _itemID; }
        public string Name { get => _name; }
        public decimal Price { get => _price; }
        public decimal BasketFootprint { get => _basketFootprint; }

    }
}
