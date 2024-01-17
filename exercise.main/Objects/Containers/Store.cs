using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;
using exercise.main.Objects.Products;
using Microsoft.VisualBasic;


namespace exercise.main.Objects.Containers
{
    public class Store
    {   
        private List<Product> _stock = new List<Product>();
        /// <summary>
        /// Tuple contains SKU of an item and the amount 
        /// </summary>
        private List<Tuple<string, int, double>> _discounts = new List<Tuple<string, int, double>>();
        public Store()
        {
            _stock.Add(new Bagel(   "BGLO", 0.49d, "Onion"));
            _stock.Add(new Bagel(   "BGLP", 0.39d, "Plain"));
            _stock.Add(new Bagel(   "BGLE", 0.49d, "Everything"));
            _stock.Add(new Bagel(   "BGLS", 0.49d, "Sesame"));
            _stock.Add(new Coffee(  "COFB", 0.99d, "Black"));
            _stock.Add(new Coffee(  "COFW", 1.19d, "White"));
            _stock.Add(new Coffee(  "COFC", 1.29d, "Capuccino"));
            _stock.Add(new Coffee(  "COFL", 1.29d, "Latte"));
            _stock.Add(new Filling( "FLIB", 0.12d, "Bacon"));
            _stock.Add(new Filling( "FILE", 0.12d, "Egg"));
            _stock.Add(new Filling( "FILC", 0.12d, "Cheese"));
            _stock.Add(new Filling( "FILX", 0.12d, "Cream Cheese"));
            _stock.Add(new Filling( "FILS", 0.12d, "Smoked Salmon"));
            _stock.Add(new Filling( "FILH", 0.12d, "Ham"));
        }

        public Product GetProduct(string productSKU)
        {
            if (_stock.Where(x => x.SKU == productSKU).ToList().Count() == 0)
            {
                return null;
            }

            return _stock.Where(x => x.SKU == productSKU).ToList().First();
        }
        public double GetPrice(string productSKU)
        {
            
            if (_stock.Where(x => x.SKU == productSKU).ToList().Count() == 0)
            {
                return -1.0d;
            }

            return _stock.Where(x => x.SKU == productSKU).ToList().First().GetPrice();
        }

    }
}
