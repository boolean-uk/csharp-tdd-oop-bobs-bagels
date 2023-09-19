using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public interface IProduct
    {
        string SKU { get; }
        string Name { get; }
        decimal GetPrice();
    }
}