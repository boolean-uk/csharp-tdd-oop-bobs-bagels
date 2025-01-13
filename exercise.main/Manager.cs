using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Manager : Iperson
    {
        public Basket Basket { get; set; }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Manager()
        {
            Basket = new Basket();
            Type = "Manager";

        }

        public Basket GetBasket()
        {
            return Basket;
        }
        public void ChangeBasketCapacity(int capacity)
        {
            Basket.Capacity = capacity;
        }


    }
}
