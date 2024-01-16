using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public interface IFood
    {
        string Name { get; }
        string Sku { get; }
        float Price { get; }
    }
}
