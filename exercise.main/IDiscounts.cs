using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IDiscounts
    {
        string Item { get; set; }
        string Item2 { get; set; }
        int Amount { get; set; }
        decimal Price { get; set; }
    }
}
