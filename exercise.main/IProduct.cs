using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IProduct
    {
        public string getSku();
        public decimal getPrice();
    }
}