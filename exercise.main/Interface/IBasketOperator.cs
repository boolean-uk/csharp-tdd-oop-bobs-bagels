using exercise.main.Objects.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interface
{
    public interface IBasketOperator
    {   
        public bool AlterSize(Basket basket, int newSize)
        {
            return true;
        }
    }
}
