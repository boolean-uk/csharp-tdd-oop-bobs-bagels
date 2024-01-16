using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        public virtual bool AddFilling(string SKU)
        {
            throw new NotImplementedException();
        }
        public virtual float TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
