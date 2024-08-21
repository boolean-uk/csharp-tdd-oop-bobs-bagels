using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    internal interface IInventory
    {
        List<IProduct> inventory { get; set; }
        List<IProduct> discounts { get; set; }

    }
}
