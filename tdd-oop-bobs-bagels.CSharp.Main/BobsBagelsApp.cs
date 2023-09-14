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

        private bool AddBagel(Bagel bagel)
        {
            if (_basket.Count == _basketCapacity)
                return false;
            if (!_bagelsInventory.ContainsKey(bagel.Type))
                return false;
            _basket.Add(bagel);
            return true;
        }

        public bool AddBagel(string bagelType)
        {
            return AddBagel(new Bagel(bagelType));
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
            if (!_bagelsInventory.ContainsKey(bagelType))
                return Double.NaN;
            return _bagelsInventory[bagelType];
        }

        public bool AddBagelWithFillings(string bagelType, List<string> fillingTypes)
        {
            if (fillingTypes.Exists(t => !_fillingsInventory.ContainsKey(t)))
                return false;
            return AddBagel(new Bagel(bagelType, fillingTypes));
        }

        public double GetFillingCost(string fillingType)
        {
            if (!_fillingsInventory.ContainsKey(fillingType))
                return Double.NaN;
            return _fillingsInventory[fillingType];
        }

        public int BagelsNum { get => _basket.Count; }

        public int BasketCapacity { get => _basketCapacity; }
    }

    
}
