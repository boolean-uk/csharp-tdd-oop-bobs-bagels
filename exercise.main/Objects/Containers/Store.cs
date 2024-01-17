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
        public Store()
        {
            _stock.Add(new Bagel("BGLO",0.49d,"Onion"));
            _stock.Add(new Bagel("BGLP",0.49d,"Plain"));
            _stock.Add(new Bagel("BGLE",0.49d,"Everything"));
            _stock.Add(new Bagel("BGLS",0.49d,"Sesame"));
            _stock.Add(new Coffee("COFB",0.49d,"Black"));
            _stock.Add(new Coffee("COFW",0.49d,"White"));
            _stock.Add(new Coffee("COFC",0.49d,"Capuccino"));
            _stock.Add(new Coffee("COFL",0.49d,"Latte"));
            _stock.Add(new Filling("FLIB",0.49d,"Bacon"));
            _stock.Add(new Filling("FILE",0.49d,"Egg"));
            _stock.Add(new Filling("FILC",0.49d,"Cheese"));
            _stock.Add(new Filling("FILX",0.49d,"Cream Cheese"));
            _stock.Add(new Filling("FILS",0.49d,"Smoked Salmon"));
            _stock.Add(new Filling("FILH",0.49d,"Ham"));
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
