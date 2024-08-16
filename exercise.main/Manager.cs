using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager : Person
    {
        private int _currentBasketCapacityInStore;
        private Product _bagel;
        private Product _coffee;
        private Product _filling;

        public Manager(string firstName, string lastName)
            :base(firstName, lastName)
        { 
            _currentBasketCapacityInStore = 3;
            _bagel = new Bagel(getBagelMenu());
            _coffee = new Coffee(getCoffeMenu());
            _filling = new Filling(getFillingMenu());
        }

        private object getFillingMenu()
        {
            throw new NotImplementedException();
        }

        private object getCoffeMenu()
        {
            throw new NotImplementedException();
        }

        public int getCurrentBasketSize() { return _currentBasketCapacityInStore;}
        public void getProduct(string SKU) {
            Tuple<string, string, string, float> bagel = _bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU);
            
            Product product = null;
            if (SKU.Contains("BGL"))
            {
                product = _bagel.getVariants().FirstOrDefault(item => item.Item1 == SKU);
            } else if (SKU.Contains("COF")) {
            
            }
            else if (SKU.Contains("FIL"))
            {
                 
            }
        }

        private Tuple<string, string, string, float>[] getBagelMenu()
        {
            Tuple<string, string, string, float>[] variants =
{
            Tuple.Create("BGLO", "Bagel", "Onion", 0.49f),
            Tuple.Create("BGLP", "Bagel", "Plain", 0.39f),
            Tuple.Create("BGLE", "Bagel", "Everything", 0.49f),
            Tuple.Create("BGLS", "Bagel", "Sesame", 0.49f),
        };
            return variants;
        }

    }
}
