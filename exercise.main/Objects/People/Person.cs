using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Core;
using exercise.main.Objects.Containers;

namespace exercise.main.Objects.People
{
    public class Person : PObject
    {
        protected Basket _basket = new Basket();

        public bool AddProduct(Ware ware)
        {
            return _basket.AddProduct(ware);
        }
        public bool RemoveProduct(Ware ware)
        {
            return _basket.RemoveProduct(ware);
        }
    }
}
