using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public interface Item
    {
        string Name { get; set; }
        float Price { get; set; }

        void GetItemCost();
    }
}