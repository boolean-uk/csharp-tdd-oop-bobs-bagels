using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes.Products
{
    public class Filling : Product
    {
        public Filling() { }

        public static decimal Cost() { return 0.12M;  }
    }
}
