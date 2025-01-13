using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Interfaces
{
    using System;

        public interface IProduct
        {
            double GetPrice();
            void SetPrice();
            string GetName();
            string GetSKU();
            void AddDiscount(double amount);
        }

}
