using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coupon
    {
        /*
        Discounts is stored as X amount of items in the discounts list. 
        If a basket contains all the items in the discounts list, the discount is applied. 
         */
        public List<Iproduct> items { get; set; }
        public float discount { get; set; }
        public Coupon(List<Iproduct> discountItems, float price) 
        {
            items = discountItems;
            discount = price;   
        } 

    }
}
