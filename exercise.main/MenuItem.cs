using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IMenuItem
    {
        string ItemID { get; }
        string Name { get; }
        decimal Price { get; }
        decimal BasketFootprint { get; }
    }
}
