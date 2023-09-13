using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsBagelsApp
    {
        private static Dictionary<string, double> _bagelsInventory = new Dictionary<string, double>
        {
            {"onion", 0.49},
            {"plain", 0.39},
            {"everything", 0.49},
            {"sesame", 0.49}
        };

        private static Dictionary<string, double> _coffeeInventory = new Dictionary<string, double>
        {
            {"black", 0.99},
            {"white", 1.19},
            {"capuccino", 1.29},
            {"latte", 1.29}
        };

        private static Dictionary<string, double> _fillingsInventory = new Dictionary<string, double>
        {
            {"bacon", 0.12},
            {"egg", 0.12},
            {"cheese", 0.12},
            {"cream cheese", 0.12},
            {"smoked salmon", 0.12},
            {"ham", 0.12}
        };

        private static int _basketCapacity = 3;

        private List<Bagel> _basket = new List<Bagel>();

        public bool AddBagel(string bagelType)
        {
            if (_basket.Count == _basketCapacity)
                return false;
            if (!_bagelsInventory.ContainsKey(bagelType))
                return false;
            _basket.Add(new Bagel(bagelType));
            return true;
        }

        public bool RemoveBagel(string bagelType)
        {
            return _basket.Remove(_basket.Find(b => b.Type == bagelType));
        }

        public bool ChangeCapacity(int capacity, bool isManager)
        {
            if (!isManager)
                return false;
            _basketCapacity = capacity;
            return true;
        }

        public double GetTotalCost()
        {
            double total = 0.0;
            foreach (Bagel bagel in _basket)
            {
                total += _bagelsInventory[bagel.Type];
            }
            return total;
        }

        public double GetBagelCost(string bagelType)
        {
            return _bagelsInventory[bagelType];
        }

        public bool AddBagelWithFillings(string bagelType, string[] fillingTypes)
        {
            throw new NotImplementedException();
        }

        public double GetFillingCost(string fillingType)
        {
            throw new NotImplementedException();
        }

        public int BagelsNum { get => _basket.Count; }

        public int BasketCapacity { get => _basketCapacity; }
    }

    public class Bagel
    {
        private string _type;
        private List<Filling> _fillings = new List<Filling>();

        public Bagel(string bagelType)
        {
            _type = bagelType;
        }

        public Bagel(string bagelType, string[] fillingTypes)
        {
            _type = bagelType;

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
