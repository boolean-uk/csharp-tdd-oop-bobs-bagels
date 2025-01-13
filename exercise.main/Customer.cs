using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer : Iperson
    {
        public Basket Basket { get; set; }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Customer()
        {
            Basket = new Basket();
            Type = "Customer";
        }

        public Basket GetBasket()
        {
            return Basket;
        }
        public void ChangeBasketCapacity(int capacity)
        {
            return; //Not authorized to make changes
        }


    }
}
