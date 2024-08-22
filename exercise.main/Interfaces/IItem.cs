using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    public interface IItem
    {
        string id { get; set; }
        double price { get; set; }
        string name { get; set; }
        string variant { get; set; }
    }
}
