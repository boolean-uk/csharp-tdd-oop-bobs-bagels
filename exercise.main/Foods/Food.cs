﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public abstract class Food<E> : IFood
    {
        private readonly E? _variant;

        public Food(E variant)
        {
            _variant = variant;
        }

        public Food()
        {

        }

        public E Variant => _variant!;

        public abstract string Sku { get; }

        public abstract string Name { get; }
        public abstract float Price { get; }

        public string FullName => $"{Name} {_variant}";
    }
}
