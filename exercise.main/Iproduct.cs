﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public interface Iproduct
    {
        public float GetPrice();
        public string GetName();
        public string GetVariant();
        public string GetSKU();
        public void AddFilling(Iproduct filling);
        public List<Iproduct> GetFillings();

    }
}
