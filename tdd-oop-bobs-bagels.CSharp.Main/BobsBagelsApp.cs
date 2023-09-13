using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsBagelsApp
    {
        private static Dictionary<string, float> _bagelsInventory = {
            "onion": 0.49,
            "plain": 0.39,
            "everything": 0.49,
            "sesame": 0.49
        };

        private static Dictionary<string, float> _coffeeInventory = {
            "black": 0.99,
            "white": 1.19,
            "capuccino": 1.29,
            "latte": 1.29
        };

        private static Dictionary<string, float> _fillingsInventory = {
            "bacon": 0.12,
            "egg": 0.12,
            "cheese": 0.12,
            "cream cheese": 0.12,
            "smoked salmon": 0.12,
            "ham": 0.12
        };

        private static int _basketCapacity = 3;

        private List<Bagel> _basket = new List<Bagel>();

        public bool AddBagel(string bagelType)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBagel(string bagelType)
        {
            throw new NotImplementedException();
        }

        public bool ChangeCapacity(int capacity, bool isManager)
        {
            throw new NotImplementedException();
        }

        public int GetTotalCost()
        {
            throw new NotImplementedException();
        }

        public int GetBagelCost(string bagelType)
        {
            throw new NotImplementedException();
        }

        public bool AddBagelWithFillings(string bagelType, string[] fillingTypes)
        {
            throw new NotImplementedException();
        }

        public int GetFillingCost(string fillingType)
        {
            throw new NotImplementedException();
        }
    }

    public class Bagel
    {
        private string _type;
        private List<Filling> _fillings;

        public Bagel(string bagelType)
        {
            _type = bagelType;
            _fillings = null;
        }

        public Bagel(string bagelType, string[] fillingTypes)
        {
            _type = type;
            _fillings = new List<Filling>();

            foreach (string fillingType in fillingTypes)
            {
                _fillings.Add(new Filling(fillingType));
            }
        }

        public string Type { get { return _type; } }
    }

    public class Filling
    {
        private string _type;

        public Filling(string type)
        {
            _type = type;
        }

        public string Type { get { return _type; } }
    }
}
