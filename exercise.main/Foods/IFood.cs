using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public interface IFood<E>
    {
        string Name { get; }
        E Variant { get; }
        string Sku { get; }
    }
}
