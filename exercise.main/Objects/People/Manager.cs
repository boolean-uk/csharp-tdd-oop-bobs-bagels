using exercise.main.Interface;
using exercise.main.Objects.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects.People
{
    public class Manager : Customer//, IBasketOperator
    {
        public bool AlterSize(Basket basket, int newSize)
        {
            return basket.AlterSize(newSize);
        }
    }
}
