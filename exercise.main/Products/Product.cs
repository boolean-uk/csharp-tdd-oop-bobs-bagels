﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public interface Product
    {
        float GetPrice();

        float GetBasePrice();

        string GetSKUName();
    }
}
