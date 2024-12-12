using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        private List<string> _products {  get; set; }

        public List<string> Products { get {  return _products; } }
        public double price { get; set; }
        
        public string ?DiscountDescription { get; set; }

        public Discount (List<string> products, double price)
        {
            this._products= products;
            this.price = price;
        }
    }
}
