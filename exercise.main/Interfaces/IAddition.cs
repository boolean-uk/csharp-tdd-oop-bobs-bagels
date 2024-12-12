﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    public interface IAddition
    {
        string SKU { get; set; }
        double Price { get; set; }
        string Name { get; set; }
        string Variant { get; set; }

        string AvailableToProduct { get; set; }
    }
}
