using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        public Base info; //product information
        List<Base> fillings = new List<Base>(); //product fillings

        public Product(Base info) 
        {
            this.info = info;
        }
    }
}
