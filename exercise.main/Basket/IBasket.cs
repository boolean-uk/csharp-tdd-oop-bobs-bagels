using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main.Basket
{
    internal interface IBasket
    {
        int Capacity { get; }

        void AddItem(Product p);
        void RemoveItem(Product o);
        bool IsFull();
        double GetTotalCost();
        void SetCapacity(int newCapacity);
        bool Contains(Product p);
    }
}
