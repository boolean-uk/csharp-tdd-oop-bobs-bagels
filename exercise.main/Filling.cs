﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item
    {
        public Filling(string type) : base(type) { }
        public Filling(string sku, double cost, string name, string type) : base(sku, cost, name, type) { }

    }
}


