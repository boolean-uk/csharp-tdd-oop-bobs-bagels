using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface IFillable : IProduct
    {
        List<Tuple<string, decimal>> _fillings { get; set; }
    }
}