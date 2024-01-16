using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Foods
{
    public abstract class Food<E> : IFood<E>
    {
        private readonly E? _variant;
        public Food(E variant) 
        {
            _variant = variant;
        }

        public Food() { }

        public string Name => "Food";

        public E Variant => _variant;
    }
}
